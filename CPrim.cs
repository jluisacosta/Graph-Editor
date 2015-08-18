using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Editor_de_Gafos
{
    public class CPrim
    {
        private CGrafo G;
        private List<CNodoVertice> V;
        private List<CArista> E;
        private List<CVertice> U;
        private TabPage tp;

        public CPrim(CGrafo grafo,TabPage t)
        {
            V = grafo.getListaAdyacencia();
            E = grafo.getListaAristas();
            U = new List<CVertice>();
            G = grafo;
            tp = t;
        }

        public void prim()
        {
            Graphics g = Graphics.FromImage(G.getBMP());
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            List<CArista> T = new List<CArista>();
            CArista uv = null;

            U.Add(V[0].getVertice());
            while (!UigualaV())
            {
                uv = buscaAristaCostoMin();
                T.Add(uv);
                U.Add(uv.getVDestino());
            }

            T.Sort(comparaAristas);
            string cad = " Conjunto de Aristas\n\n T : {";
            foreach (CArista a in T)
            {
                a.dibujateAACM(g, G.getBMP(), tp);
                cad += " (" + a.getVOrigen().getId().ToString() +","+a.getVDestino().getId().ToString()+") ";
            }
            cad+="}.    ";

            MessageBox.Show(cad,"Árbol Abarcador de Costo Mínimo (Algoritmo de PRIM)",MessageBoxButtons.OK,MessageBoxIcon.Information);

            g.Clear(Color.White);
            G.dibujate(tp, G.getBMP());
        }

        public bool UigualaV()
        {
            bool igual = true;
            if (U.Count == V.Count)
            {
                foreach (CNodoVertice cnv in V)
                {
                    if (!U.Contains(cnv.getVertice()))
                        igual = false;
                }
            }
            else
                igual = false;

            return igual;
        }

        public List<CVertice> VmenosU()
        {
            List<CVertice> vmu = new List<CVertice>();

            foreach (CNodoVertice cnv in V)
            {
                if (!U.Contains(cnv.getVertice()))
                    vmu.Add(cnv.getVertice());
            }

            return vmu;
        }

        public CArista buscaAristaCostoMin()
        {
            List<CArista> posibles = new List<CArista>();
            List<CVertice> umv = VmenosU();

            foreach (CArista ar in E)
            {
                if ((U.Contains(ar.getVOrigen()) && umv.Contains(ar.getVDestino())) /*||
                    (U.Contains(ar.getVDestino()) && umv.Contains(ar.getVOrigen()))*/)
                {
                    posibles.Add(ar);
                }
            }

            posibles.Sort(comparaAristas);
            CArista amc = posibles[0];

            foreach (CArista ar in posibles)
            {
                if (ar.getPeso() < amc.getPeso())
                    amc = ar;
            }

            return amc;
        }

        public int comparaAristas(CArista a1, CArista a2)
        {
            return a1.getPeso().CompareTo(a2.getPeso());
        }
    }
}
