using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace Editor_de_Gafos
{
    public class CDijkstra
    {
        private CGrafo G;
        private int n;
        private int[,] C;
        private List<CNodoVertice> V;
        private const int INFINITO = int.MaxValue;

        public CDijkstra(CGrafo grafo)
        {
            G = grafo;
            n = grafo.getNumeroVertices();
            V = grafo.getListaAdyacencia();
            C = construyeC();
        }

        public void calculaCaminoMasCorto(CNodoVertice origen)
        {
            List<CNodoVertice> S = new List<CNodoVertice>();
            List<CNodoVertice> P = new List<CNodoVertice>();
            List<CNodoVertice> VS;
            int[] D = new int[n];

            S.Add(origen);

            for (int i = 0; i < n; i++)
            {
                D[i] = C[V.IndexOf(origen), i];
                P.Add(origen);
            }

            for (int j = 0; j < n-1; j++)
            {
                VS = VminusS(S);
                CNodoVertice w = menorVminusS(D,VS);
                S.Add(w);
                VS = VminusS(S);
                foreach (CNodoVertice cnv in VS)
                { 
                    if(G.sonVerticesAdyacentes(cnv.getVertice(),w.getVertice()))
                    {
                        int aux = D[V.IndexOf(cnv)];
                        if (C[V.IndexOf(w), V.IndexOf(cnv)] == INFINITO)
                            C[V.IndexOf(w), V.IndexOf(cnv)] -= D[V.IndexOf(w)];

                        D[V.IndexOf(cnv)] = minimoDe(D[V.IndexOf(cnv)], D[V.IndexOf(w)] + C[V.IndexOf(w), V.IndexOf(cnv)]);
                        if (aux != D[V.IndexOf(cnv)])
                            P[V.IndexOf(cnv)] = w;
                    }
                }
            }

            muestraResultado(D, P, origen);
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
            {
                c[V.IndexOf(G.buscaNodoVertice(a.getVOrigen())), V.IndexOf(G.buscaNodoVertice(a.getVDestino()))] = a.getPeso();
            }
            return c;
        }

        public List<CNodoVertice> VminusS(List<CNodoVertice> LS)
        {
            List<CNodoVertice> res = new List<CNodoVertice>();
            //V-S
            foreach (CNodoVertice cnv in V)
            {
                if (!LS.Contains(cnv))
                    res.Add(cnv);
            }

            return res;
        }

        public CNodoVertice menorVminusS(int[] DW,List<CNodoVertice> VS)
        {
            int minimo = INFINITO,indx = 0;

            foreach (CNodoVertice cnv in VS)
            {
                if (DW[V.IndexOf(cnv)] < minimo)
                {
                    minimo = DW[V.IndexOf(cnv)];
                    indx = V.IndexOf(cnv);
                }
            }

            return V[indx];
        }

        public int minimoDe(int n1, int n2)
        {
            int nmenor = n1;

            if (n2 < n1)
                nmenor = n2;

            return nmenor;
        }

        public void muestraResultado(int[] pesos_totales, List<CNodoVertice> caminos,CNodoVertice origen)
        {
            string camaux = "";
            DataTable dt = new DataTable();
            object[] values = new object[3];
            int ind = 0;
            List<int> camino = new List<int>();
            bool sincamino = false;

            dt.Columns.Add("Destino");
            dt.Columns.Add("Camino");
            dt.Columns.Add("Peso Total");

            for (int i = 0; i < pesos_totales.Length; i++)
            {
                ind = i;
                values[0] = V[i].getVertice().getId().ToString();

                if (pesos_totales[i] != INFINITO && pesos_totales[i] >= 0)
                    values[2] = " " + pesos_totales[i].ToString();
                else
                {
                    sincamino = true;
                    values[2] = " - ";
                }

                while (origen.getVertice().getId() != caminos[ind].getVertice().getId())
                {
                    camino.Add(caminos[ind].getVertice().getId());
                    ind = V.IndexOf(caminos[ind]);
                }

                camaux += origen.getVertice().getId().ToString()+", ";
                for(int y = camino.Count-1;y>=0;y--)
                    camaux += camino[y].ToString() + ", ";

                camaux += V[i].getVertice().getId().ToString();

                if (sincamino)
                {
                    values[1] = " No existe";
                    sincamino = false;
                }
                else
                    values[1] = camaux;

                dt.Rows.Add(values);
                camaux = "";
                camino.Clear();
            }

            DDijkstra dij = new DDijkstra(dt, origen.getVertice().getId());
            dij.ShowDialog();
        }

    }
}
