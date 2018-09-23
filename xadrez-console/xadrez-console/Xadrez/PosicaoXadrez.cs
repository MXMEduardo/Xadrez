using System;
using tabuleiro;

namespace Xadrez {
    class PosicaoXadrez {
        public char coluna { get; set; }
        public int linha { get; private set; }

        public PosicaoXadrez (char coluna, int linha) {
            this.coluna = coluna;
            this.linha = linha;
        }

        public Posicao ToPosicao() {
            return new Posicao(8 - linha, coluna - 'a');
        }        
    }
}
