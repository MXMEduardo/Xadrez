using System;
using System.Collections.Generic;
using tabuleiro;

namespace Xadrez {
    class PartidadeXadrez {

        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool Terminada { get; private set; }
        private HashSet<Peca> Pecas;
        private HashSet<Peca> Capturadas;
        public bool xeque { get; private set; }

        public PartidadeXadrez() {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branco;
            Terminada = false;
            Pecas = new HashSet<Peca>();
            Capturadas = new HashSet<Peca>();
            xeque = false;

            MontaTabuleiro();
        }

        public void colocarNovaPeca(char coluna, int linha, Peca peca) {
            tab.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            Pecas.Add(peca);
        }

        private void MontaTabuleiro() {
            colocarNovaPeca('c', 1, new Torre(tab, Cor.Branco));
            colocarNovaPeca('c', 2, new Torre(tab, Cor.Branco));
            colocarNovaPeca('d', 2, new Torre(tab, Cor.Branco));
            colocarNovaPeca('e', 2, new Torre(tab, Cor.Branco));
            colocarNovaPeca('e', 1, new Torre(tab, Cor.Branco));
            colocarNovaPeca('d', 1, new Rei(tab, Cor.Branco));

            colocarNovaPeca('c', 7, new Torre(tab, Cor.Preto));
            colocarNovaPeca('c', 8, new Torre(tab, Cor.Preto));
            colocarNovaPeca('d', 7, new Torre(tab, Cor.Preto));
            colocarNovaPeca('e', 7, new Torre(tab, Cor.Preto));
            colocarNovaPeca('e', 8, new Torre(tab, Cor.Preto));
            colocarNovaPeca('d', 8, new Rei(tab, Cor.Preto));
        }

        public Peca executaMovimento(Posicao PosicaoOrigem, Posicao PosicaoDestino) {
            Peca p = tab.RetirarPeca(PosicaoOrigem);
            p.IncrementarQtdMovimentos();
            Peca PecaCapturada = tab.RetirarPeca(PosicaoDestino);
            tab.ColocarPeca(p, PosicaoDestino);
            if (PecaCapturada != null) {
                Capturadas.Add(PecaCapturada);
            }
            return PecaCapturada;
        }

        public void realizaJogada(Posicao PosicaoOrigem, Posicao PosicaoDestino) {
            Peca pecaCapturada = executaMovimento(PosicaoOrigem, PosicaoDestino);

            if (estaEmXeque(jogadorAtual)) {
                desfazoMovimento(PosicaoOrigem, PosicaoDestino, pecaCapturada);
                throw new TabuleiroException("Você não pode fazer esse movimento");
            }

            if (estaEmXeque(adversaria(jogadorAtual))) {
                xeque = true;
            }
            else {
                xeque = false;
            }

            turno++;
            mudaJodador();
        }

        private void desfazoMovimento(Posicao PosicaoOrigem, Posicao  PosicaoDestino, Peca pecaCapturada) {
            Peca p = tab.RetirarPeca(PosicaoDestino);
            p.decrementarQtdMovimentos();
            if (pecaCapturada != null) {
                tab.ColocarPeca(pecaCapturada, PosicaoDestino);
                Capturadas.Remove(pecaCapturada);
            }
            tab.ColocarPeca(p, PosicaoOrigem);

        }

        private void mudaJodador() {
            if (jogadorAtual == Cor.Branco) {
                jogadorAtual = Cor.Preto;
            }
            else {
                jogadorAtual = Cor.Branco;
            }
        }

        public void ValidaPosicaodeOrigem(Posicao pos) {
             if (tab.Peca(pos) == null) {
                throw new TabuleiroException("Não existe peça nessa posição");
            }

            if (tab.Peca(pos).cor != jogadorAtual) {
                throw new TabuleiroException("A peça selecionada é do jogador "+ jogadorAtual);
            }

            if (!tab.Peca(pos).ExisteMovimentosPossiveis()) {
                throw new TabuleiroException("Não existem movimentos possíveis para essa peça");
            }
        }

        public void ValidaPosicaodeDestino(Posicao posOrigem, Posicao posDestino) {
            if (!tab.Peca(posOrigem).podeMoverPara(posDestino)) {
                throw new TabuleiroException("Posição de destino inválida");
            }
        }

        public HashSet<Peca> PecasCapturadas(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in Capturadas) {
                if (x.cor == cor) {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in Pecas) {
                if (x.cor == cor) {
                    aux.Add(x);
                }
            }

            aux.ExceptWith(PecasCapturadas(cor));

            return aux;
        }

        private Cor adversaria(Cor cor) {
            if (cor == Cor.Branco) {
                return Cor.Preto;
            }
            else {
                return Cor.Branco;

            }
        }

        private Peca rei(Cor cor) {
            foreach (Peca x in PecasEmJogo(cor)) {
                if (x is Rei) {
                    return x;
                }
            }
            return null;
        }

        public bool estaEmXeque(Cor cor) {
            Peca r = rei(cor);

            foreach (Peca x in PecasEmJogo(adversaria(cor))) {
                bool[,] mat = x.MovimentosPossiveis();
                if (mat[r.posicao.linha, r.posicao.coluna]) {
                    return true;
                }
            }
            return false;
        }
    }
}
