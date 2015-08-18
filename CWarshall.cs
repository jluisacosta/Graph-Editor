using System;
using System.Collections.Generic;
using System.Text;

namespace Editor_de_Gafos
{
    public class CWarshall
    {
        private CGrafo G;
        private int n;
        private int[,] C;
        private const int INFINITO = 10000;
        private bool[,] D;

        public CWarshall(CGrafo grafo)
        {
            G = grafo;
            n = grafo.getNumeroVertices();
            C = G.getMatrizAdyacencia().getMatriz();
            D = new bool[n, n];
        }

        public void Warshall()
        {
            int i = 0, j = 0, k = 0;

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    if (C[i, j] == 1)
                        D[i, j] = true;
                    else
                        D[i, j] = false;
                }
            }

            for (k = 0; k < n; k++)
                for (i = 0; i < n; i++)
                    for (j = 0; j < n; j++)
                        D[i, j] = (D[i, j] || (D[i, k] && D[k, j]));
        }

        public bool tieneCerraduraTransitiva()
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (!(D[i, j]))
                        return false;

            return true;
        }
    }
}
