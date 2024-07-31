using System;
using Tabuleiro;
using Xadrez;

namespace JogoXadrez
{

    
    class Tela
    {
        public static int IDENTACAO = 50;// identação para centralizar o tabuleiro na tela do console
        // método para imprimir o tabuleiro
        public static void ImprimirTabuleiro(Tabuleiro.Tabuleiro tabuleiro)
        {
            Console.WriteLine();
            Console.WriteLine();
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(string.Concat(Enumerable.Repeat(" ", IDENTACAO)) + "    TABULEIRO");
            Console.WriteLine();
            Console.WriteLine(string.Concat(Enumerable.Repeat(" ", IDENTACAO)) + "  a b c d e f g h ");
            for (int i = 0; i < tabuleiro.Linhas; i++)
            {
                Console.Write(string.Concat(Enumerable.Repeat(" ", IDENTACAO)) + (8 - i) + " ");// enumarar o tabuleiro como no xadrez

                for (int j = 0; j < tabuleiro.Colunas; j++)
                {
                    Console.ForegroundColor = aux;
                    ImprimirPeca(tabuleiro.Peca(i, j));
              
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
            }
            
            Console.WriteLine(string.Concat(Enumerable.Repeat(" ", IDENTACAO)) + "  a b c d e f g h "); // visualizar as letras como no xadrez
            Console.ForegroundColor = aux;
        }

        // método para imprimir o tabuleiro com as posições possíveis para a peça selecionada 
        public static void ImprimirTabuleiro(Tabuleiro.Tabuleiro tabuleiro, bool[,] posicoesPossiveis)
        {
            Console.WriteLine();
            Console.WriteLine();
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(string.Concat(Enumerable.Repeat(" ", IDENTACAO)) + "    TABULEIRO");
            Console.WriteLine();
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;
            Console.WriteLine(string.Concat(Enumerable.Repeat(" ", IDENTACAO)) + "  a b c d e f g h ");
            for (int i = 0; i < tabuleiro.Linhas; i++)
            {
                Console.Write(string.Concat(Enumerable.Repeat(" ", IDENTACAO)) + (8 - i) + " ");// enumarar o tabuleiro como no xadrez

                for (int j = 0; j < tabuleiro.Colunas; j++)
                {
                    if (posicoesPossiveis[i, j])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    Console.ForegroundColor = aux;
                    ImprimirPeca(tabuleiro.Peca(i, j));
                    Console.BackgroundColor = fundoOriginal;

                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
            }
           
            Console.WriteLine(string.Concat(Enumerable.Repeat(" ", IDENTACAO)) + "  a b c d e f g h "); // visualizar as letras como no xadrez
            Console.ForegroundColor = aux;
            Console.BackgroundColor = fundoOriginal;
        }
        public static void ImprimirPartida(PartidaDeXadrez partida)
        {
            ImprimirTabuleiro(partida.Tabuleiro);
            Console.WriteLine();
            ImprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.Turno);
            if (!partida.Terminada)
            {
                Console.WriteLine("Aguardando jogada peça: " + partida.JogadorAtual);
                if (partida.Xeque)
                {
                    Console.WriteLine("XEQUE!");
                }
            }
            else
            {
                Console.WriteLine("XEQUEMATE!");
                Console.WriteLine("Vencedor: " + partida.JogadorAtual);
            }
            
        }
        public static void ImprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine("Peças capturadas:");
            Console.Write("Brancas: ");
            ImprimirConjunto(partida.PecasCapturadas(Cor.Branca));
            Console.WriteLine();
            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            ImprimirConjunto(partida.PecasCapturadas(Cor.Preta));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        private static void ImprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach (Peca peca in conjunto)
            {
                Console.Write(peca + " ");
            }
            Console.Write("]");
        }

        public static void ImprimirPeca(Peca peca)
        {
            if(peca == null)
            {
                Console.Write("- ");
            }
            else { 
                if (peca.Cor == Cor.Branca)
                {
                    Console.Write(peca);
                }

                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string s = Console.ReadLine().ToLower();
            
            if (s.Length == 2 && !string.IsNullOrWhiteSpace(s) && Char.IsLetter(s[0]) && Char.IsDigit(s[1]) )
            {
                if (!(s[1] >= '1' && s[1] <= '8' && s[0] >= 'a' && s[0] <= 'h'))
                {
                    throw new TabuleiroException("Coordenadas incorretas");

                   
                }
                char coluna = s[0];
                int linha = int.Parse(s[1] + "");
                return new PosicaoXadrez(coluna, linha);
            }
            else
            {
                throw new TabuleiroException("Coordenadas incorreta");
            }
            


           
           
             
            
            
           
        }
    }
}

