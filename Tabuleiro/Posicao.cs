

namespace Tabuleiro
{
    class Posicao
    {
        public int Linha { get; set; }
        public int Coluna { get; set; }


     
        public Posicao(int linha, int coluna)
        {
            Linha = linha;
            Coluna = coluna;
        }
        public void DefinirValores(int linha, int coluna) // para usar os valores do objeto em uma unica linha de comando
        {
            Linha = linha;
            Coluna = coluna;
        }

        public override string ToString()
        {
            return  Linha +
                     ", " +
                    Coluna;
        }
    }
}
