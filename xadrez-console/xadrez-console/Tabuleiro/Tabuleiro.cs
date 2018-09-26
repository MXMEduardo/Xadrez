namespace tabuleiro {
    class Tabuleiro {
        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas { get; set; }

        public Tabuleiro(int linhas, int colunas) {
            this.linhas = linhas;
            this.colunas = colunas;

            pecas = new Peca[linhas, colunas];
        }

        public Peca getPeca(int linha, int coluna) {
            return pecas[linha, coluna];
        }

        public Peca Peca (Posicao pos) {
            return pecas[pos.linha, pos.coluna];
        }

        public bool posicaoValida(Posicao pos) {
            if (pos.linha < 0 || pos.linha >= this.linhas || pos.coluna < 0 || pos.coluna >= this.colunas) {
                return false;
            }
            return true;
        }

        public void ValidarPosicao(Posicao Pos) {
            if (!posicaoValida(Pos)) {
                throw new TabuleiroException("Posição inválida.");
             } 
        }

        public bool existePeca(Posicao pos) {
            ValidarPosicao(pos);
            return Peca(pos) != null;
        }

        public void ColocarPeca(Peca p, Posicao pos) {
            if (existePeca(pos)) {
                throw new TabuleiroException("Existe uma peça nessa posição");
            }
            pecas[pos.linha, pos.coluna] = p;
            p.posicao = pos;
        }

        public Peca RetirarPeca(Posicao pos) {
            //Peca(pos).posicao = null;
            //pecas[pos.linha, pos.coluna] = null;
            //return Peca(pos);
                        if (Peca(pos) == null) {
                            return null;
                        } else {
                            Peca aux = Peca(pos);
                            aux.posicao = null;
                            pecas[pos.linha, pos.coluna] = null;
                            return aux;
                        }
            
        }
    }
}
