using System;
using Tabuleiro;

namespace xadrez_console {
    class Program {
        static void Main(string[] args) {
            Posicao P = new Posicao(1,3);

            Console.WriteLine("Posição : " + P);

            Console.ReadLine();
        }
    }
}
