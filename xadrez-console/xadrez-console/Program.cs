using System;
using tabuleiro;
using Xadrez;

namespace xadrez_console {
    class Program {
        static void Main(string[] args) {
            try {
                PartidadeXadrez Partida = new PartidadeXadrez();

                while (!Partida.Terminada) {
                    Console.Clear();
                    Tela.imprimirTabuleiro(Partida.tab);

                    Console.WriteLine();
                    Console.Write("Digite a posição de origem :");
                    Posicao PosOrigem = Tela.LerPosicaoXadrez().ToPosicao();

                    bool[,] posicoesPossiveis = Partida.tab.Peca(PosOrigem).MovimentosPossiveis();

                    Console.Clear();
                    Tela.imprimirTabuleiro(Partida.tab, posicoesPossiveis);

                    Console.Write("Digite a posição de destino :");
                    Posicao PosDestino = Tela.LerPosicaoXadrez().ToPosicao();

                    Partida.executaMovimento(PosOrigem, PosDestino);
                }


            }
            catch (TabuleiroException e) {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
