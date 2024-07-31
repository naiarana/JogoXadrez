using System.Reflection.Metadata.Ecma335;
using Tabuleiro;

namespace Xadrez
{
    /*
     * Classe para o usuário utilizar as posições como no xadrez
     * internamente a posição será da matriz de inteiros da classe Tabuleiro.Posição
     */
    class PosicaoXadrez
    {
        public char Coluna { get; set; }
        public int Linha { get; set; }

        public PosicaoXadrez(char coluna, int linha)
        {
            Coluna = coluna;
            Linha = linha;
        }

        // Convertendo a posição na posição correspondente na matriz
        public Posicao ToPosicao()
        {
            return new Posicao(8 - Linha, Coluna - 'a');
        }

        public override string ToString()
        {
            return "" + Coluna + Linha;
        }
    }
}
