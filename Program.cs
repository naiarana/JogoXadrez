using JogoXadrez;
using Tabuleiro;
using Xadrez;

try
{


    PartidaDeXadrez partida = new PartidaDeXadrez();

    while (!partida.Terminada)
    {
        try
        {
            Console.Clear();
            Tela.ImprimirPartida(partida);

            Console.WriteLine();
            Console.Write("Origem: ");
            Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
            partida.ValidarPosicaoDeOrigem(origem);

            bool[,] posicoesPossiveis = partida.Tabuleiro.Peca(origem).MovimentosPossiveis();

            Console.Clear();

            Tela.ImprimirTabuleiro(partida.Tabuleiro, posicoesPossiveis);
            Console.WriteLine();
            Console.Write("Destino: ");
            Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();
            partida.ValidarPosicaoDestino(origem, destino);

            partida.RealizarJogada(origem, destino);
        }
        catch (TabuleiroException e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine();
            Console.WriteLine("ENTER para Continuar!");
            Console.ReadLine();
        }
    }

}

catch (TabuleiroException e)
{
    Console.WriteLine(e.Message);
}

Console.ReadLine();

