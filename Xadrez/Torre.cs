﻿using Tabuleiro;

namespace Xadrez
{
    class Torre : Peca
    {

        public Torre(Tabuleiro.Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {

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

            Posicao posicao = new Posicao(0, 0);
            // acima
            posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            while(Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;

                if(Tabuleiro.Peca(posicao) != null && Tabuleiro.Peca(posicao).Cor != Cor) // forçar a para do while se encontrar uma peça adversária
                {
                    break;
                }
                posicao.Linha -= 1;
            }
            // direita
            posicao.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;

                if (Tabuleiro.Peca(posicao) != null && Tabuleiro.Peca(posicao).Cor != Cor)
                {
                    break;
                }
                posicao.Coluna += 1;
            }
            // abaixo
            posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            while (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;

                if (Tabuleiro.Peca(posicao) != null && Tabuleiro.Peca(posicao).Cor != Cor)
                {
                    break;
                }
                posicao.Linha += 1;
            }
            // esquerda
            posicao.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;

                if (Tabuleiro.Peca(posicao) != null && Tabuleiro.Peca(posicao).Cor != Cor)
                {
                    break;
                }
                posicao.Coluna -= 1;
            }
            return mat;
        }
        public override string ToString()
        {
            return "T";
        }
    }
}
