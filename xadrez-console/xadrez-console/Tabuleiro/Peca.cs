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

        public abstract bool[,] MovimentosPossiveis();
    }
}