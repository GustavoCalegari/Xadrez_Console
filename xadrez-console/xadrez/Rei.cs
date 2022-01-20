using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {
        public Rei(Tabuleiro tab, Cor cor) : base(tab, cor) { }

        public override string ToString()
        {
            return "R";
        }

        private bool PodeMover(Posicao pos)
        {
            Peca p = tab.Peca(pos);
            return p == null || p.cor != cor;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);

            // Acima
            pos.DefinirValores(posicao.linha - 1, posicao.coluna);

            if (tab.isPosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            // Nordeste
            pos.DefinirValores(posicao.linha - 1, posicao.coluna + 1);

            if (tab.isPosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            // Direita
            pos.DefinirValores(posicao.linha, posicao.coluna + 1);

            if (tab.isPosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            // Sudeste
            pos.DefinirValores(posicao.linha + 1, posicao.coluna + 1);

            if (tab.isPosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            // Abaixo
            pos.DefinirValores(posicao.linha + 1, posicao.coluna);

            if (tab.isPosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            // Sudoeste
            pos.DefinirValores(posicao.linha + 1, posicao.coluna - 1);

            if (tab.isPosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            // Esquerda
            pos.DefinirValores(posicao.linha, posicao.coluna - 1);

            if (tab.isPosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            // Noroeste
            pos.DefinirValores(posicao.linha - 1, posicao.coluna - 1);

            if (tab.isPosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            return mat;
        }
    }
}
