using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace Xadrez {
    class PartidadeXadrez {

        public Tabuleiro tab { get; private set; }
        private int turno;
        private Cor jogadorAtual;
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
    }
}
