using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {
        private PartidaDeXadrez partida;

        public Rei(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor)
        {
            this.partida = partida;
        }

        public override string ToString()
        {
            return "R";
        }

        private bool PodeMover(Posicao pos)
        {
            Peca p = tab.Peca(pos);
            return p == null || p.cor != cor;
        }

        private bool TesteTorreParaRoque(Posicao pos)
        {
            Peca p = tab.Peca(pos);
            return p != null && p is Torre && p.cor == cor && p.qteMovimentos == 0;
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

            // #jogadaespecial Roque
            if (qteMovimentos == 0 && !partida.xeque)
            {
                // #jogadaespecial roque pequeno
                Posicao posT1 = new Posicao(posicao.linha, posicao.coluna + 3);
                if (TesteTorreParaRoque(posT1))
                {
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna + 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna + 2);
                    if (tab.Peca(p1) == null && tab.Peca(p2) == null)
                    {
                        mat[posicao.linha, posicao.coluna + 2] = true;
                    }
                }

                // #jogadaespecial roque grande
                Posicao posT2 = new Posicao(posicao.linha, posicao.coluna - 4);
                if (TesteTorreParaRoque(posT2))
                {
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna - 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna - 2);
                    Posicao p3 = new Posicao(posicao.linha, posicao.coluna - 3);
                    if (tab.Peca(p1) == null && tab.Peca(p2) == null && tab.Peca(p3) == null)
                    {
                        mat[posicao.linha, posicao.coluna - 2] = true;
                    }
                }
            }

            return mat;
        }
    }
}
