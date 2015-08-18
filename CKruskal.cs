using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Editor_de_Gafos
{
    public class CKruskal
    {
        private CGrafo G;
        private List<CNodoVertice> V;
        private List<CArista> E;
        private List<List<CVertice>> componentes;
        private List<CArista> Q;
        private List<CArista> T;
        private TabPage tp;

        public CKruskal(CGrafo grafo,TabPage tpx)
        {
            G = grafo;
            V = G.getListaAdyacencia();
            E = G.getListaAristas();
            Q = new List<CArista>();
            T = new List<CArista>();
            tp = tpx;
            componentes = new List<List<CVertice>>();

            foreach (CArista a in E)
                Q.Add(a);

            Q.Sort(comparaArista);
        }

        public void kruskal()
        {
            Graphics g = Graphics.FromImage(G.getBMP());
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            int n = G.getNumeroVertices();
            CArista uv = null;
            List<CVertice> cv = null;
            List<CVertice> cu = null;

            foreach (CNodoVertice cnv in V)
            { 
                List<CVertice> C = new List<CVertice>();
                C.Add(cnv.getVertice());
                componentes.Add(C);
            }

            while (T.Count <= (n - 1) && Q.Count != 0)
            {
                uv = Q[0];
                Q.RemoveAt(0);
                cv = componenteQueContiene(uv.getVDestino());
                cu = componenteQueContiene(uv.getVOrigen());
                if (!cvIgualcu(cv, cu))
                {
                    T.Add(uv);
                    foreach (CVertice v in cu)
                        cv.Add(v);
                    cu.Clear();
                }

            }

            T.Sort(comparaArista);
            string cad = " Conjunto de Aristas\n\n T : {";
            foreach (CArista a in T)
            {
                a.dibujateAACM(g, G.getBMP(), tp);
                cad += " (" + a.getVOrigen().getId().ToString() + "," + a.getVDestino().getId().ToString() + ") ";
            }
            cad += "}.    ";

            MessageBox.Show(cad, "Árbol Abarcador de Costo Mínimo (Algoritmo de KRUSKAL)", MessageBoxButtons.OK, MessageBoxIcon.Information);

            g.Clear(Color.White);
            G.dibujate(tp, G.getBMP());
        }

        public int comparaArista(CArista a,CArista b)
        {
            return a.getPeso().CompareTo(b.getPeso());
        }

        public List<CVertice> componenteQueContiene(CVertice v)
        {
            List<CVertice> cv = null;

            foreach (List<CVertice> comp in componentes)
            {
                if (comp.Contains(v))
                {
                    cv = comp;
                    break;
                }
            }

            return cv;
        }

        public bool cvIgualcu(List<CVertice> cv, List<CVertice> cu)
        {
            bool band = true;

            if (cv.Count == cu.Count)
            {
                foreach (CVertice v in cv)
                {
                    if (!cu.Contains(v))
                        band = false;
                }
            }
            else
                band = false;

            return band;
        }
    }
}
