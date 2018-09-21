namespace tabuleiro {
    class Peca {
        public Tabuleiro tabuleiro { get; protected set; }
        public Posicao posicao { get; set; }
        public Cor cor { get; set; }
        public int QtdMovimento { get; protected set; }

        public Peca(Posicao posicao, Tabuleiro tabuleiro, Cor cor) {
            this.tabuleiro = tabuleiro;
            this.posicao = posicao;
            this.cor = cor;
            QtdMovimento = 0;
        }
    }
}