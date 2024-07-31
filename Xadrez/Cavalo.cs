using Tabuleiro;

namespace Xadrez
{
    class Cavalo : Peca
    {

        public Cavalo(Tabuleiro.Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {

        }
        private bool PodeMover(Posicao posicao)
        {
            Peca p = Tabuleiro.Peca(posicao);
            return p == null || p.Cor != Cor; // retorna true se a posição estiver vazia ou for de cor adversária.
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao posicao = new Posicao(0, 0);
            posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 2);
            if(Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }
            posicao.DefinirValores(Posicao.Linha - 2, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }
            posicao.DefinirValores(Posicao.Linha - 2, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }
            posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 2);
            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }
            posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 2);
            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }
            posicao.DefinirValores(Posicao.Linha + 2, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }
            posicao.DefinirValores(Posicao.Linha + 2, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }
            posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 2);
            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }

            return mat;


        }

        public override string ToString()
        {
            return "C";
        }
    }
}
