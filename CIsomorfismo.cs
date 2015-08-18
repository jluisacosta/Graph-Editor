using System;
using System.Collections.Generic;
using System.Text;

namespace Editor_de_Gafos
{
    class CIsomorfismo : CAlgoritmo
    {
        private CGrafo G;
        private CGrafo H;
        
        public CIsomorfismo(CGrafo grafo_1, CGrafo grafo_2): base()
        {
            G = grafo_1;
            H = grafo_2;
        } 

        //Principal
        public bool sonIsomorficos()
        {
            bool band = false;
            if (!G.getListaAdyacencia().Exists(hayVerticeGradoCero) 
                && !H.getListaAdyacencia().Exists(hayVerticeGradoCero) 
                && mismosNVyNA(G,H) && mismasRelacionesGrafo()
                && algoritmoMatrices())
            {
                band = true;
            }
            return band;
        }
        
        //Verificacion de Relaciones (basico)
        public bool mismasRelacionesGrafo()
        {
            List<List<CVertice>> lg = new List<List<CVertice>>();
            List<List<CVertice>> lh = new List<List<CVertice>>();
            bool band = false;
            int cont = 0;
            getGrados(G);
            foreach (int i in grados)
            { 
                lg.Add(buscaVertConNVecinos(G.getListaAdyacencia(),i));
            }
            lg.Sort(ordenaPorlongitud);
            foreach (int i in grados)
            { 
                lh.Add(buscaVertConNVecinos(H.getListaAdyacencia(),i));
            }
            lh.Sort(ordenaPorlongitud);

            for(int i = 0;i<lg.Count;i++)
            {
                if(lg[i].Count == lh[i].Count)
                    cont++;
            }

            if (cont == lg.Count && cont == lh.Count)
                band = true;

            return band;
        }

        public void getGrados(CGrafo gx) //Obtiene los grados (sin repetirse) que tiene el grafo
        {
            foreach (CNodoVertice cnv in gx.getListaAdyacencia())
            {
                if (!existeItem(grados, cnv.getVertice().getVecinos().Count))
                {
                    grados.Add(cnv.getVertice().getVecinos().Count);
                }
            }
            grados.Sort();
        }

        public bool existeItem(List<int> lint, int buscado)
        {
            bool band = false;
            foreach (int xn in lint)
            {
                if (xn == buscado)
                {
                    band = true;
                    break;
                }
            }
            return band;
        } //Utilizado getgrados para verificar si se repiten grados

        public List<CVertice> buscaVertConNVecinos(List<CNodoVertice> lady, int n)
        {
            List<CVertice> verts = new List<CVertice>();
            foreach (CNodoVertice cnv in lady)
            {
                if (cnv.getVertice().getVecinos().Count == n)
                    verts.Add(cnv.getVertice());
            }
            return verts;
        }

        public int ordenaPorlongitud(List<CVertice> lg, List<CVertice> lh)
        {
            int comp = 0;
            comp = lg.Count.CompareTo(lh.Count);
            return comp;
        }


        //Algoritmo de matrices de G y H
        public bool algoritmoMatrices()
        {
            bool isomorficos = false,continua = true;
            int colG = 0, n = G.getListaAdyacencia().Count;

            CMatrizAdyacencia MG = G.getMatrizAdyacencia();
            CMatrizAdyacencia MH = new CMatrizAdyacencia(n);
            MH.setMatriz(copiaMatriz(H.getMatrizAdyacencia().getMatriz(), n));

            while (colG < n && continua)
            {
                if (encuentraSemejante(MG, ref MH, colG, n))
                {
                    if (matricesIguales(MG, MH, n))
                    {
                        isomorficos = true;
                        continua = false;
                    }
                    else
                        colG++;
                }
                else
                    continua = false;
            }
                
            if (colG == n || !matricesIguales(MG, MH,n))//Si se recorrieron todas las columnas de G
            {
                isomorficos = false;
            }

            return isomorficos;
        }

        public int claculaUnosFila(int[,] matriz, int fila,int n)
        {
            int unos = 0;
            for (int columna = 0; columna < n; columna++)
            {
                if (matriz[fila, columna] == 1)
                    unos++;
            }
            return unos;
        }

        public int calculaUnosColumna(int[,] matriz, int columna,int n,ref List<int> numunosenfila)
        {
            int unos = 0;
            for (int fila = 0; fila < n ; fila++)
            {
                if (matriz[fila, columna] == 1)
                {
                    numunosenfila.Add(claculaUnosFila(matriz, fila, n));
                    unos++;
                }
            }
            return unos;
        }

        public bool encuentraSemejante(CMatrizAdyacencia m1,ref CMatrizAdyacencia m2, int col_m1,int n)
        {
            int ic2 = col_m1 + 1;
            bool semejante = false;

            if (ic2 == n)
                ic2 = 0;

            while (col_m1 != ic2)
            {
                if ((semejante = columnaYRenglonesIguales(m1, m2, col_m1, ic2, n)))
                {
                    aplicarIntercambioDeFilasYColumnas(ref m2, col_m1, ic2, n);
                    return semejante;
                }

                ic2++;
                if (ic2 == n)
                    ic2 = 0;
            }

            return semejante;
        }
        
        public bool matricesIguales(CMatrizAdyacencia m1, CMatrizAdyacencia m2,int tam_mat)
        {
            bool band = true;

            for (int fila = 0; fila < tam_mat && band !=  false; fila++)
            {
                for (int columna = 0; columna < tam_mat; columna++)
                {
                    if (m1.getMatriz()[fila, columna] != m2.getMatriz()[fila, columna])
                    {
                        band = false;
                        break;
                    }
                }
            }

            return band;
        } //Valida matrices isomorficas

        public bool columnaYRenglonesIguales(CMatrizAdyacencia m1, CMatrizAdyacencia m2, int col_m1, int col_m2, int n)
        {
            bool iguales = false;
            int num_unos_columna_m1 = 0, num_unos_columna_m2 = 0;
            List<int> nuef_m1 = new List<int>();
            List<int> nuef_m2 = new List<int>();

            num_unos_columna_m1 = calculaUnosColumna(m1.getMatriz(), col_m1, n, ref nuef_m1);
            num_unos_columna_m2 = calculaUnosColumna(m2.getMatriz(), col_m2, n, ref nuef_m2);

            if (num_unos_columna_m1 == num_unos_columna_m2 && igualNuef(nuef_m1,nuef_m2))
                iguales = true;

            return iguales;
        }

        public bool igualNuef(List<int> nuef1, List<int> nuef2)
        {
            bool band = false;
            int cont = 0;
            List<int> n1aux = copiaNuef(nuef1);
            List<int> n2aux = copiaNuef(nuef2);
            n1aux.Sort();
            n2aux.Sort();

            if (n1aux.Count == n2aux.Count)
            {
                for (int i = 0; i < n1aux.Count; i++)
                {
                    if (n1aux[i] == n2aux[i])
                        cont++;
                    else
                        break;
                }
            }

            if (cont == n1aux.Count)
                band = true;

            return band;
        }

        public List<int> copiaNuef(List<int> nuef)
        {
            List<int> copia = new List<int>();
            foreach (int i in nuef)
            {
                copia.Add(i);
            }
            return copia;
        }

        public void aplicarIntercambioDeFilasYColumnas(ref CMatrizAdyacencia m, int col_m1,int col_m2, int n)
        {
            int[,] maux = copiaMatriz(m.getMatriz(), n);

            //Cambio columnas
            for (int i = 0; i < n; i++)
            {
                m.getMatriz()[i, col_m1] = maux[i, col_m2];
                m.getMatriz()[i, col_m2] = maux[i, col_m1];
            }

            maux = copiaMatriz(m.getMatriz(), n);

            //Cambio renglones
            for (int i = 0; i < n; i++)
            {
                m.getMatriz()[col_m1, i] = maux[col_m2, i];
                m.getMatriz()[col_m2, i] = maux[col_m1, i];
            }
        }
    }
}
