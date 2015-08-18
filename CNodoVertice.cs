using System;
using System.Collections.Generic;
using System.Text;

namespace Editor_de_Gafos
{
    [Serializable]
    public class CNodoVertice
    {
        private CVertice vertice;
        private List<CNodoVertice> relaciones;

        //Constructor
        public CNodoVertice(CVertice vert)
        {
            vertice = vert;
            relaciones = new List<CNodoVertice>();
        }

        //Getters
        public CVertice getVertice()
        {
            return vertice;
        }

        public List<CNodoVertice> getRelaciones()
        {
            return relaciones;
        }

        public void setRelacionesFC(List<CNodoVertice> L)
        {
            relaciones = L;
        }
    }
}
