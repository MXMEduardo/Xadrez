using tabuleiro;

namespace Xadrez {
    class Torre : Peca {
        public Torre(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor) {
        }

        public override string ToString() {
            return "T";
        }

        public override bool[,] MovimentosPossiveis() {
            bool[,] mat = new bool[tabuleiro.linhas, tabuleiro.colunas];

            Posicao pos = new Posicao(0, 0);

            // norte
            pos.definirValores(posicao.linha - 1, posicao.coluna);
            while (tabuleiro.posicaoValida(pos) && PodeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.Peca(pos) != null && tabuleiro.Peca(pos).cor != cor) {
                    break;
                }
                pos.linha--;
            }

            // leste
            pos.definirValores(posicao.linha, posicao.coluna + 1);
            while (tabuleiro.posicaoValida(pos) && PodeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.Peca(pos) != null && tabuleiro.Peca(pos).cor != cor) {
                    break;
                }
                pos.coluna++;
            }

            // Sul
            pos.definirValores(posicao.linha + 1, posicao.coluna);
            while (tabuleiro.posicaoValida(pos) && PodeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.Peca(pos) != null && tabuleiro.Peca(pos).cor != cor) {
                    break;
                }
                pos.linha++;
            }


            // Oeste
            pos.definirValores(posicao.linha, posicao.coluna - 1);
            while (tabuleiro.posicaoValida(pos) && PodeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.Peca(pos) != null && tabuleiro.Peca(pos).cor != cor) {
                    break;
                }
                pos.coluna--;
            }

            return mat;
        }
    }
}