using System;
using tabuleiro;

namespace xadrez_console {
    class Tela {
        public static void imprimirTabuleiro(Tabuleiro tab) {
            for (int l = 0; l < tab.linhas; l++) {
                Console.Write(8 - l + " ");
                for (int c = 0; c < tab.colunas; c++) {
                    if (tab.getPeca(l, c) == null) {
                        Console.Write("- ");
                    }
                    else {
                        ImprimirPeca(tab.getPeca(l, c));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.WriteLine();
        }

        public static void ImprimirPeca(Peca p) {
            if (p.cor == Cor.Branco) {
                Console.Write(p);
            }
            else {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(p);
                Console.ForegroundColor = aux;
            }

        }
    }
}
