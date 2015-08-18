using System;
using System.Collections.Generic;
using System.Text;

namespace Editor_de_Gafos
{
    public class CKuratowsky : CAlgoritmo
    {
        private CGrafo k5;
        private CGrafo k33;

        public CKuratowsky() : base()
        {
            k5 = this.construyeK5();
            k33 = this.construyeK33();
        }

        public bool esIsomorficoAK5(CGrafo grafo_evaluado)
        {
            CIsomorfismo ci = new CIsomorfismo(k5, grafo_evaluado);
            if (ci.sonIsomorficos())
                return true;
            else
                return false;
        }

        public bool esIsomorficoAK33(CGrafo grafo_evaluado)
        {
            CIsomorfismo ci = new CIsomorfismo(k33, grafo_evaluado);
            if (ci.sonIsomorficos())
                return true;
            else
                return false;
        }

        public bool esPlanoPorKuratowskyInteractivo(CGrafo grafo_evaluado)
        {
            if (esIsomorficoAK5(grafo_evaluado) || esIsomorficoAK33(grafo_evaluado))
                return false;
            else
                return true;
        }
    }
}
