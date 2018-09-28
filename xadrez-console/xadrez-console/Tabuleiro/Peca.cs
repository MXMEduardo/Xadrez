namespace tabuleiro {
    abstract class Peca {
        public Tabuleiro tabuleiro { get; protected set; }
        public Cor cor { get; set; }
        public Posicao posicao { get; set; }
        public int QtdMovimento { get; protected set; }

        public Peca(Tabuleiro tabuleiro, Cor cor) {
            this.tabuleiro = tabuleiro;
            this.cor = cor;
            QtdMovimento = 0;
        }

        protected bool PodeMover(Posicao pos) {
            Peca p = tabuleiro.Peca(pos);
            return p == null || p.cor != cor;
        }

        public void IncrementarQtdMovimentos() {
            QtdMovimento++;
        }

        public void decrementarQtdMovimentos() {
            QtdMovimento--;
        }

        public abstract bool[,] MovimentosPossiveis();

        public bool ExisteMovimentosPossiveis() {
            bool[,] mat = MovimentosPossiveis();
            for (int l=0; l < tabuleiro.linhas; l++) {
                for (int c = 0; c < tabuleiro.colunas; c++) {
                    if (mat[l,c]) {
                        return true;
                    }   
                }
            }
            return false;
        }

        public bool podeMoverPara(Posicao pos) {
            return MovimentosPossiveis()[pos.linha, pos.coluna];
        }
    }
}