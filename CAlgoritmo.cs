using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Editor_de_Gafos
{
    public class CAlgoritmo
    {
        public List<int> grados;

        public CAlgoritmo()
        {
            grados = new List<int>();
        }

        public bool mismosNVyNA(CGrafo G,CGrafo H)
        {
            bool iguales = false;
            if (G.getNumeroAristas() == H.getNumeroAristas() && G.getNumeroVertices() == H.getNumeroVertices())
                iguales = true;

            return iguales;
        }

        public  static bool hayVerticeGradoCero(CNodoVertice cnv)
        {
            if (cnv.getVertice().getGrado() == 0)
                return true;
            else
                return false;
        } //Delegado para List<CNodoVertice>.Exist

        public int[,] copiaMatriz(int[,] matorg, int n)
        {
            int[,] mat = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    mat[i, j] = matorg[i, j];
            }
            return mat;
        }

        public CGrafo construyeK5()
        {
            CGrafo k5 = new CGrafo(1, 0);

            for (int i = 0; i < 5; i++)
            { 
                CVertice v = new CVertice(i+1,0,0,Color.White,Color.Black);
                v.setGrado(4);
                CNodoVertice cnv = new CNodoVertice(v);
                k5.getListaAdyacencia().Add(cnv);
            }

            foreach (CNodoVertice nv in k5.getListaAdyacencia())
            {
                foreach (CNodoVertice nv2 in k5.getListaAdyacencia())
                {
                    if (nv.getVertice().getId() != nv2.getVertice().getId())
                    {
                        nv.getRelaciones().Add(nv2);
                        nv.getVertice().getVecinos().Add(nv2.getVertice());
                        if (!k5.aristaRepetida(nv.getVertice(), nv2.getVertice()))
                        { 
                            CArista ar = new CArista(nv.getVertice(), nv2.getVertice(),new Point(0,0),new Point(0,0),0);
                            k5.getListaAristas().Add(ar);
                        }
                    }
                }
            }

            k5.setNumeroAristas(10);
            k5.setNumeroVertices(5);

            return k5;
        }

        public CGrafo construyeK33()
        {
            CGrafo k33 = new CGrafo(1, 0);

            for (int i = 0; i < 6; i++)
            {
                CVertice v = new CVertice(i + 1, 0, 0, Color.White, Color.Black);
                v.setGrado(3);
                CNodoVertice cnv = new CNodoVertice(v);
                k33.getListaAdyacencia().Add(cnv);
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 3; j < 6; j++)
                {
                    k33.getListaAdyacencia()[i].getRelaciones().Add(k33.getListaAdyacencia()[j]);
                    k33.getListaAdyacencia()[i].getVertice().getVecinos().Add(k33.getListaAdyacencia()[j].getVertice());
                    k33.getListaAdyacencia()[j].getRelaciones().Add(k33.getListaAdyacencia()[i]);
                    k33.getListaAdyacencia()[j].getVertice().getVecinos().Add(k33.getListaAdyacencia()[i].getVertice());
                    CArista ar = new CArista(k33.getListaAdyacencia()[i].getVertice(), k33.getListaAdyacencia()[j].getVertice(), new Point(0, 0), new Point(0, 0), 0);
                    k33.getListaAristas().Add(ar);
                }
            }

            k33.setNumeroAristas(9);
            k33.setNumeroVertices(6);

            return k33;
        }
    }
}
