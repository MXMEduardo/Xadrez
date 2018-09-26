using System;
using tabuleiro;
using Xadrez;


namespace xadrez_console {
    class Tela {
        public static void imprimirTabuleiro(Tabuleiro tab) {
            for (int l = 0; l < tab.linhas; l++) {
                Console.Write(8 - l + " ");
                for (int c = 0; c < tab.colunas; c++) {
                    ImprimirPeca(tab.getPeca(l, c));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.WriteLine();
        }
        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis) {

            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;


            for (int l = 0; l < tab.linhas; l++) {
                Console.Write(8 - l + " ");
                for (int c = 0; c < tab.colunas; c++) {

                    if (posicoesPossiveis[l, c]) {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else {
                        Console.BackgroundColor = fundoOriginal;
                    }

                    ImprimirPeca(tab.getPeca(l, c));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = fundoOriginal;
            Console.WriteLine();
        }

        public static void ImprimirPeca(Peca p) {
            if (p == null) {
                Console.Write("- ");
            }
            else {
                if (p.cor == Cor.Branco) {
                    Console.Write(p);
                }
                else {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(p);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }

        public static PosicaoXadrez LerPosicaoXadrez() {
            string s = Console.ReadLine();

            char coluna = s[0];
            int linha = int.Parse(s[1] + "");

            return new PosicaoXadrez(coluna, linha);
        }
    }
}
