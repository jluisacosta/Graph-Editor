using System;
using System.Collections.Generic;
using System.Text;

namespace Editor_de_Gafos
{
    [Serializable]
    public class CMatrizIncidencia
    {
        private int m,n;
        private int[,] matriz;

        //Constructor
        public CMatrizIncidencia(int mvert,int nar)
        {
            m = mvert;
            n = nar;
            matriz = new int[m,n];
            for(int i = 0;i<m;i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matriz[i, j] = 0;
                }
            }
        }

        public void creaMatriz(List<CNodoVertice> lver,List<CArista> lar)
        {
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if(esIncidenteCon(lar[j],lver[i]))
                        matriz[i, j] = 1;
                }
            }
        }//Construye la matriz a partir de la lista de adyacencia del grafo

        public bool esIncidenteCon(CArista ari, CNodoVertice nodo_od)
        {
            bool encontrado = false;
            if (ari.getVOrigen().getId() == nodo_od.getVertice().getId() || ari.getVDestino().getId() == nodo_od.getVertice().getId())
                encontrado = true;
            
            return encontrado;
        } //Verifica que existe incidencia en lista de adyacencia

        //Getters
        public int[,] getMatriz()
        {
            return matriz;
        }

    }
}
