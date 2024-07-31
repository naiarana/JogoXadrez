
namespace Tabuleiro
{
    class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }

        private Peca[,] Pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            Pecas = new Peca[Linhas, Colunas]; // instanciando uma matriz, que conterá o tabuleiro em si com as posições
        }
        // método para pegar o elemento da matriz peças, já que a mesma só pode ser acessada na própria classe
        public Peca Peca(int linha, int coluna)
        {
            return Pecas[linha, coluna];
        }
        //sobrecarga
        public Peca Peca(Posicao posicao) 

        {
           
            if (posicao == null)
            {
                throw new TabuleiroException( "Posição não pode ser nula.");
            }
            return Pecas[posicao.Linha, posicao.Coluna];
        }

        public bool PosicaoValida(Posicao posicao)
        {
            if(posicao.Linha < 0 || posicao.Linha > 7 || posicao.Coluna < 0 || posicao.Coluna > 7)
                return false;
            return true;
        }
        public void ValidarPosicao(Posicao posicao)
        {
            if (!(PosicaoValida(posicao)))
            {
                throw new TabuleiroException("Posição inválida");
            }
        }

        //public bool ExistePeca(Posicao posicao)
        //{
        //    if (Pecas[posicao.Linha, posicao.Coluna] == null)
        //    {
        //        return false;
        //    }
        //    return true;
        //}
        public bool ExistePeca(Posicao posicao)
        {
            ValidarPosicao(posicao);
            return Peca(posicao) != null;
        }

        public void ColocarPeca(Peca peca, Posicao posicao)
        {
            if (ExistePeca(posicao))
            {
                throw new TabuleiroException("Já existe uma peça nessa posição");
            }
            Pecas[posicao.Linha, posicao.Coluna] = peca;
            peca.Posicao = posicao;

        }

        public Peca RetirarPeca(Posicao posicao)
        {
            if(Peca(posicao) == null)
            {
                return null;
            }
            Peca aux = Peca(posicao);
            aux.Posicao = null; // marcar a posição como null
            Pecas[posicao.Linha, posicao.Coluna] = null; // marcar a posição que a peça estava no tabuleiro como nula
            return aux; // retorna a peça sem posição atribuida
        }



    }
}
