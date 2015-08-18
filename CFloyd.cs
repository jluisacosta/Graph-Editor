using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Editor_de_Gafos
{
    public class CFloyd
    {
        private CGrafo G;
        private int n;
        private int[,] C;
        private List<CNodoVertice> V;
        private const int INFINITO = 10000;
        private int[,] P;
        private int[,] D;

        public CFloyd(CGrafo grafo)
        {
            G = grafo;
            n = grafo.getNumeroVertices();
            V = grafo.getListaAdyacencia();
            C = construyeC();
            P = new int[n, n];
            D = new int[n, n];
        }

        public int[,] construyeC()
        {
            int[,] c = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                        c[i, j] = 0;
                    else
                        c[i, j] = INFINITO;
                }
            }

            foreach (CArista a in G.getListaAristas())
                c[V.IndexOf(G.buscaNodoVertice(a.getVOrigen())), V.IndexOf(G.buscaNodoVertice(a.getVDestino()))] = a.getPeso();

            return c;
        }

        public void Floyd()
        {
            int i=0,j=0,k=0;

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    D[i, j] = C[i, j];
                    P[i, j] = -1;
                }
            }

            for (i = 0; i < n; i++)
                D[i, i] = 0;

            for(k=0;k<n;k++)
                for(i=0;i<n;i++)
                    for (j = 0; j < n; j++)
                    {
                        if ((D[i, k] + D[k, j]) < D[i, j])
                        {
                            D[i, j] = (D[i, k] + D[k, j]);
                            P[i, j] = k;
                        }
                    }
        }

        public void recuperaCamino(int i, int j,ref string cad)
        {
            cad += V[i].getVertice().getId().ToString() + ", ";
            camino(i, j,ref cad);
            cad += V[j].getVertice().getId().ToString();
        }

        public bool camino(int i, int j, ref string cad)
        {
            int k = P[i, j],kstr=0;
            if (k == -1)
                return true;

            camino(i, k,ref cad);
            kstr = k+1;
            cad += kstr.ToString() + ", ";
            camino(k, j,ref cad);
            return false;
        }

        public void muestraResultado()
        {
            string camino_ij = "";
            object[] values = new object[4];
            DataTable dt = new DataTable();
            dt.Columns.Add("Origen");
            dt.Columns.Add("Destino");
            dt.Columns.Add("Camino");
            dt.Columns.Add("Peso Total");
            
            for(int i = 0;i<n;i++)
                for (int j = 0; j < n; j++)
                {
                    values[0] = V[i].getVertice().getId().ToString();
                    values[1] = V[j].getVertice().getId().ToString();
                    if (D[i, j] == INFINITO)
                    {
                        values[3] = " - ";
                        camino_ij = "No existe";
                    }
                    else
                    {
                        values[3] = D[i, j].ToString();
                        recuperaCamino(i, j, ref camino_ij);
                    }
                    values[2] = camino_ij;
                    
                    dt.Rows.Add(values);
                    camino_ij = "";
                }
            DDFloyd df = new DDFloyd(dt);
            df.ShowDialog();
        }

        public CNodoVertice dameCentro()
        {
            int[] exc = new int[n];
            int i=0,min=0,ind=0;

            for(i=0;i<n;i++)
                for (int j = 0; j < n; j++)
                {
                    if (D[j, i] != INFINITO && D[j, i] > exc[i])
                        exc[i] = D[j, i];
                }

            min = exc[0];
            ind = 0;
            for (i = 1; i < n; i++)
                if (exc[i] < min)
                {
                    min = exc[i];
                    ind = i;
                }

            return V[ind];
        }
    }
}
