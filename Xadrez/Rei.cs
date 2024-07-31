using Tabuleiro;

namespace Xadrez
{
    class Rei : Peca
    {
        private PartidaDeXadrez Partida; // propriedade para que o Rei tenha acesso a partida e saiba se está em xeque 
        public Rei(Tabuleiro.Tabuleiro tabuleiro, Cor cor, PartidaDeXadrez partida) : base(tabuleiro, cor)
        {
            Partida = partida;
        }
        // método para verificar se a torre está apta para o roque
        private bool TesteTorreParaRoque(Posicao posicaoTorre1)
        {
            Peca p = Tabuleiro.Peca(posicaoTorre1);
            return p != null && p is Torre && p.Cor == Cor && p.QteMovimentos == 0; // retorna true se tiver uma torre do mesmo jogador(cor) e for o primeiro movimento 
        }
        private bool PodeMover(Posicao posicao)
        {
            Peca p = Tabuleiro.Peca(posicao);
            return p == null || p.Cor != Cor; // retorna true se a posição estiver vazia ou for de cor adversária.
        }
        public override bool[,] MovimentosPossiveis()
        {
            // matriz de boleanos do tamanho do tabuleiro
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];  

            Posicao posicao = new Posicao(0,0);

            // verificar possibilidade de movimento acima 
            posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            if(Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }
            // nordeste
            posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }
            // direita
            posicao.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }
            // sudeste
            posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }
            // abaixo
            posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }
            // sudoeste
            posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }
            // esquerda
            posicao.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }
            // noroeste
            posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }
            // #jogadaespecial roque
            if (QteMovimentos == 0 && !Partida.Xeque)
            {
                // #jogadaespecial roque pequeno
                Posicao posicaoTorre1 = new Posicao(Posicao.Linha, Posicao.Coluna + 3);
                if (TesteTorreParaRoque(posicaoTorre1))
                {
                    Posicao posicao1 = new Posicao(Posicao.Linha, Posicao.Coluna + 1); // posicao da peca 1 casa a direita
                    Posicao posicao2 = new Posicao(Posicao.Linha, Posicao.Coluna + 2); // posicao da peca 2 casas a direira
                    if (Tabuleiro.Peca(posicao1) == null && Tabuleiro.Peca(posicao2) == null) // se as duas casas estiverem livre 
                    {
                        mat[Posicao.Linha, Posicao.Coluna + 2] = true; // a segunda casa da direita recebe true
                    }
                }
                // #jogadaespecial roque grande
                Posicao posicaoTorre2 = new Posicao(Posicao.Linha, Posicao.Coluna - 4);
                if (TesteTorreParaRoque(posicaoTorre2))
                {
                    Posicao posicao1 = new Posicao(Posicao.Linha, Posicao.Coluna - 1); // posicao da peca 1 casa a esquerda
                    Posicao posicao2 = new Posicao(Posicao.Linha, Posicao.Coluna - 2); // posicao da peca 2 casas a esquerda
                    Posicao posicao3 = new Posicao(Posicao.Linha, Posicao.Coluna - 3); // posicao da peca 3 casas a esquerda
                    if (Tabuleiro.Peca(posicao1) == null && Tabuleiro.Peca(posicao2) == null && Tabuleiro.Peca(posicao3) == null) // se as duas casas estiverem livre 
                    {
                        mat[Posicao.Linha, Posicao.Coluna + 2] = true;
                    }
                }

            }
            return mat;
        }
        
        public override string ToString()
        {
            return "R";
        }

    }
}
