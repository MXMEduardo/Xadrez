using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace Xadrez {
    class PartidadeXadrez {

        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool Terminada { get; private set; }

        public PartidadeXadrez() {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branco;

            MontaTabuleiro();
            Terminada = false;
        }

        private void MontaTabuleiro() {
            tab.ColocarPeca(new Torre(tab, Cor.Preto), new PosicaoXadrez('a', 8).ToPosicao());
            tab.ColocarPeca(new Torre(tab, Cor.Preto), new PosicaoXadrez('c', 4).ToPosicao());
            tab.ColocarPeca(new Rei(tab, Cor.Branco), new PosicaoXadrez('b', 5).ToPosicao());
        }

        public void executaMovimento(Posicao PosicaoOrigem, Posicao PosicaoDestino) {
            Peca p = tab.RetirarPeca(PosicaoOrigem);
            p.IncrementarQtdMovimentos();
            Peca PecaCapturada = tab.RetirarPeca(PosicaoDestino);
            tab.ColocarPeca(p, PosicaoDestino);
        }

        public void realizaJogada(Posicao PosicaoOrigem, Posicao PosicaoDestino) {
            executaMovimento(PosicaoOrigem, PosicaoDestino);
            turno++;
            mudaJodador();
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
    }
}
