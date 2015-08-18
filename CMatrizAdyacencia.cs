using System;
using System.Collections.Generic;
using System.Text;

namespace Editor_de_Gafos
{
    [Serializable]
    public class CMatrizAdyacencia
    {
        private int n;
        private int[,] matriz;

        //Constructor
        public CMatrizAdyacencia(int nvert)
        {
            n = nvert;
            matriz = new int[n,n];
            for(int i = 0;i<n;i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matriz[i, j] = 0;
                }
            }
        }

        public void creaMatriz(List<CNodoVertice> la)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if(estaEnListaRelaciones(la[i],la[j]))
                        matriz[i, j] = 1;
                }
            }
        } //Construye la matriz a partir de la lista de adyacencia del grafo

        public bool estaEnListaRelaciones(CNodoVertice nodo, CNodoVertice relacion)
        {
            bool encontrado = false;
            foreach (CNodoVertice cnv in nodo.getRelaciones())
            {
                if (relacion.getVertice().getId() == cnv.getVertice().getId())
                {
                    encontrado = true;
                    break;
                }
            }
            return encontrado;
        } //Verifica que existe relacion en lista de adyacencia

        public int[,] construirMatrizGrafoSubrayado()
        { 
            int [,] nueva = new int[n,n];

            for(int i=0; i<n;i++)
            {
                for(int j=0;j<n;j++)
                {
                    if (matriz[i, j] == 1)
                    {
                        nueva[i, j] = 1;
                        nueva[j, i] = 1;
                    }
                }
            }
            return nueva;
        }

        //Getters
        public int[,] getMatriz()
        {
            return matriz;
        }

        public void setMatriz(int[,] m)
        {
            matriz = m;
        }
    }
}
