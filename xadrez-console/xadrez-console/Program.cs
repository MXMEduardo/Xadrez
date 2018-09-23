using System;
using tabuleiro;
using Xadrez;

namespace xadrez_console {
    class Program {
        static void Main(string[] args) {
            Tabuleiro tab = new Tabuleiro(8, 8);

            tab.ColocarPeca(new Torre(tab, Cor.Preto), new PosicaoXadrez('a', 1).ToPosicao());
            tab.ColocarPeca(new Torre(tab, Cor.Preto), new PosicaoXadrez('c', 4).ToPosicao());
            tab.ColocarPeca(new Rei(tab, Cor.Preto), new PosicaoXadrez('b', 5).ToPosicao());

            Tela.imprimirTabuleiro(tab);

            Console.ReadLine();
        }
    }
}
