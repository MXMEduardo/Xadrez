using System;
using tabuleiro;
using Xadrez;

namespace xadrez_console {
    class Program {
        static void Main(string[] args) {
            try {
                PartidadeXadrez Partida = new PartidadeXadrez();

                while (!Partida.Terminada) {
                    try {
                        Console.Clear();
                        Tela.imprimirTabuleiro(Partida.tab);
                        Console.WriteLine("Turno :" + Partida.turno);
                        Console.WriteLine("Aguardando a jogada do jogador :" + Partida.jogadorAtual);

                        Console.WriteLine();
                        Console.Write("Digite a posição de origem :");
                        Posicao PosOrigem = Tela.LerPosicaoXadrez().ToPosicao();
                        Partida.ValidaPosicaodeOrigem(PosOrigem);

                        bool[,] posicoesPossiveis = Partida.tab.Peca(PosOrigem).MovimentosPossiveis();

                        Console.Clear();
                        Tela.imprimirTabuleiro(Partida.tab, posicoesPossiveis);

                        Console.Write("Digite a posição de destino :");
                        Posicao PosDestino = Tela.LerPosicaoXadrez().ToPosicao();

                        Partida.ValidaPosicaodeDestino(PosOrigem, PosDestino);

                        Partida.realizaJogada(PosOrigem, PosDestino);
                    }
                    catch (TabuleiroException e) {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
            }
            catch (TabuleiroException e) {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
