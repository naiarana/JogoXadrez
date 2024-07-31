
using System.Reflection.PortableExecutable;
using System.Runtime.ConstrainedExecution;

namespace Tabuleiro
{
    abstract class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }

        public int QteMovimentos { get; protected set; }

        public Tabuleiro Tabuleiro { get; protected set; }

        public Peca(Tabuleiro tabuleiro, Cor cor )
        {
            Posicao = null;
            Tabuleiro = tabuleiro;
            Cor = cor;
            QteMovimentos = 0; // a jogada inicia com zero
        }
        public void IncremetarQteMovimentos()
        {
            QteMovimentos++;
        }
        public void DecrementarQteMovimentos()
        {
            QteMovimentos--;
        }
        public bool ExisteMovimentosPossiveis()
        {
            bool[,] mat = MovimentosPossiveis();
            for (int i = 0; i < Tabuleiro.Linhas; i++)
            {
                for (int j = 0; j < Tabuleiro.Colunas; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false; 
        }
        public bool MovimentoPossivel(Posicao posicao)
        {
            return MovimentosPossiveis()[posicao.Linha, posicao.Coluna];
        }
        /*
         * Metódo abstrato que definirá em cada Tipo de peça os movimentos possiveis 
         * marcando com true as posições que podem ser ocupadas por cada tipo de peça
         */
        public abstract bool[,] MovimentosPossiveis();


    }
}
