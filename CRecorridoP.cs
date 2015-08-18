using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Editor_de_Gafos
{
    class CRecorridoP
    {
        private CGrafo G;
        private List<CArista> arcos_arbol;
        private List<CArista> arcos_avance;
        private List<CArista> arcos_retroceso;
        private List<CArista> arcos_cruzados;
        private int num;
        private int num2;
        private int[] descendientes;
        private TabPage tp;
        private List<CNodoVertice> GR;
        private List<List<int>> ids_cf;
        private const int DIRIGIDO = 1, NO_DIRIGIDO = 0;


        public CRecorridoP(CGrafo grafo,TabPage tpx)
        {
            arcos_arbol = new List<CArista>();
            arcos_avance = new List<CArista>();
            arcos_retroceso = new List<CArista>();
            arcos_cruzados = new List<CArista>();
            G = grafo;
            num = 0;
            descendientes = new int[G.getListaAdyacencia().Count];
            tp = tpx;
            GR = new List<CNodoVertice>();
            ids_cf = new List<List<int>>();
        }

        public void RecorridoEnProfundidad(CNodoVertice cnvid)
        {
            if (cnvid.getVertice().getVisitado() != true)
            {
                int nd = 0;
                RP_R(cnvid, ref nd);
                descendientes[G.getListaAdyacencia().IndexOf(cnvid)] = nd;
            }

            foreach (CNodoVertice cnv in G.getListaAdyacencia())
            {
                if (cnv.getVertice().getId() != cnvid.getVertice().getId())
                {
                    if (cnv.getVertice().getVisitado() != true)
                    {
                        int nd = 0;
                        RP_R(cnv, ref nd);
                        descendientes[G.getListaAdyacencia().IndexOf(cnv)] = nd;
                    }
                }
            }
        }

        public void RP_R(CNodoVertice cnv,ref int ndes)
        {
            cnv.getVertice().setVisitado(true);
            cnv.getVertice().setNumero(++num);
            foreach (CNodoVertice w in cnv.getRelaciones())
            {
                if (w.getVertice().getVisitado() != true)
                {
                    int nd = 0;
                    RP_R(w, ref nd);
                    descendientes[G.getListaAdyacencia().IndexOf(w)] = nd;
                    ndes += nd + 1;
                    enlistaArcosArbol(cnv.getVertice(), w.getVertice());
                }
            }
        }

        public void enlistaArcosArbol(CVertice origen, CVertice destino)
        {
            foreach (CArista a in G.getListaAristas())
            {
                if (G.getTipo() == DIRIGIDO)
                {
                    if (a.getVOrigen().getId() == origen.getId() && a.getVDestino().getId() == destino.getId())
                        arcos_arbol.Add(a);
                }
                else
                {
                    if ((a.getVOrigen().getId() == origen.getId() && a.getVDestino().getId() == destino.getId()) ||
                        a.getVOrigen().getId() == destino.getId() && a.getVDestino().getId() == origen.getId())
                    {
                        arcos_arbol.Add(a);
                    }
                }
            }
        }

        public void clasificaArcos(bool ramp)
        {
            foreach (CArista a in G.getListaAristas())
            {
                if (G.getTipo() == DIRIGIDO)
                {
                    if (!arcos_arbol.Contains(a)) //Si no es arco de arbol
                    {
                        CVertice u = a.getVOrigen(), v = a.getVDestino();
                        if (u.getNumero() >= v.getNumero() && esXDescendienteDeY(u, v))          //Si es arco de retroceso
                            arcos_retroceso.Add(a);
                        else if ((u.getNumero() <= v.getNumero() && esXDescendienteDeY(v, u)))    //Si es arco de avance
                            arcos_avance.Add(a);
                        else
                            arcos_cruzados.Add(a);                                              //Entonces es arco cruzado
                    }
                }
                else
                {
                    if (!arcos_arbol.Contains(a))
                    {
                        if (ramp)
                            arcos_cruzados.Add(a);
                        else
                            arcos_retroceso.Add(a);
                    }
                }
            }
        }

        public bool esXDescendienteDeY(CVertice X, CVertice Y)
        { 
            if( Y.getNumero() <= X.getNumero() 
                && X.getNumero() <= (Y.getNumero() + descendientes[G.getListaAdyacencia().IndexOf(G.buscaNodoVertice(Y))]))
            {
                return true;
            }
            return false;
        }

        public void aplicaArbolAbarcador(int tipo_grafo,bool ramp)
        {
            Graphics g = Graphics.FromImage(G.getBMP());
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            clasificaArcos(ramp);

            foreach (CArista a in arcos_retroceso)
                a.dibujateRP(g, G.getBMP(), tp, 1,G.getTipo());

            foreach (CArista a in arcos_avance)
                a.dibujateRP(g, G.getBMP(), tp, 2,G.getTipo());

            foreach (CArista a in arcos_cruzados)
                a.dibujateRP(g, G.getBMP(), tp, 3,G.getTipo());

            string cad = "\n\n Arcos de árbol (Azul)\n Arcos de retroceso (Rojo)\n Arcos de Avance (Celeste)\n Arcos Cruzados (Verde)";
            string cad2 = "\n\n Arcos de árbol (Azul)\n Arcos de Retroceso (Rojo)\n";
            string cad3 = "\n\n Arcos de árbol (Azul)\n Arcos de Cruzados (Verde)\n";

            if (tipo_grafo == DIRIGIDO)
            {
                if (arcos_retroceso.Count == 0)
                    MessageBox.Show(" El Grafo " + G.getId().ToString() + " es un GDA.                   " + cad, "Recorrido en profundidad", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show(" El Grafo " + G.getId().ToString() + " NO es un GDA ya que tiene arcos de retroceso (Color Rojo).  " + cad, "Recorrido en profundidad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if(!ramp)
                    MessageBox.Show(" Resultado para el Grafo " + G.getId().ToString() + cad2, "Recorrido en profundidad (Grafo NO Dirigido)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show(" Resultado para el Grafo " + G.getId().ToString() + ".                   " + cad3, "Recorrido en amplitud", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            g.Clear(Color.White);
            G.dibujate(tp, G.getBMP());
        }


        //Componentes fuertes
        public void obtenerComponentesFuertes()
        {
            int cont = 1;
            string cf = "\n";

            RecorridoComponentesFuertes();
            construyeGR();
            RecorridoComponentesFuertesEnGR();

            foreach (List<int> li in ids_cf)
            {
                li.Sort();
                cf += "\n Componente " + cont.ToString()+" : { ";
                foreach (int i in li)
                {
                    cf += i.ToString();
                    if(li.IndexOf(i)!=(li.Count-1))
                        cf += ", ";
                    else
                        cf += " ";
                }
                cf += "}.";
                cont++;
            }

            MessageBox.Show("\n Componentes del Grafo " + G.getId().ToString() + " reducido :      "+cf, 
                "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        public void RecorridoComponentesFuertes()
        {
            List<int> nada = new List<int>();
            foreach (CNodoVertice cnv in G.getListaAdyacencia())
            {
                if (cnv.getVertice().getVisitado() != true)
                    CF_R(cnv,ref nada,1);
            }
        }

        public void construyeGR()
        {
            G.getListaAdyacencia().Sort(ordenaPorNumero);
            foreach (CNodoVertice nv in G.getListaAdyacencia())
            {
                CNodoVertice nuevo = new CNodoVertice(new CVertice(nv.getVertice().getId(), 0, 0, Color.Transparent, Color.Transparent));
                GR.Add(nuevo);
            }

            foreach (CNodoVertice cnv in GR)
                cnv.setRelacionesFC(getListaNuevaDe(cnv));

            G.getListaAdyacencia().Sort(ordenaPorID);
        }
        
        public void RecorridoComponentesFuertesEnGR()
        {
            foreach (CNodoVertice cnv in GR)
            {
                if (cnv.getVertice().getVisitado() != true)
                {
                    List<int> arbol = new List<int>();
                    arbol.Add(cnv.getVertice().getId());
                    CF_R(cnv,ref arbol,2);
                    ids_cf.Add(arbol);
                }
            }
        }

        public void CF_R(CNodoVertice cnv,ref List<int> ar,int vuelta)
        {
            cnv.getVertice().setVisitado(true);

            foreach (CNodoVertice w in cnv.getRelaciones())
            {
                if (w.getVertice().getVisitado() != true)
                {
                    ar.Add(w.getVertice().getId());
                    CF_R(w,ref ar,vuelta);
                }
            }

            if(vuelta == 1)
                cnv.getVertice().setNumero(++num);
            else
                cnv.getVertice().setNumero(++num2);
        }


        //Otros de componentes fuertes
        public List<CNodoVertice> getListaNuevaDe(CNodoVertice nv)
        {
            List<CNodoVertice> listanueva = new List<CNodoVertice>();
            
            foreach (CNodoVertice cnv in G.getListaAdyacencia())
            {
                foreach (CNodoVertice rel in cnv.getRelaciones())
                {
                    if (rel.getVertice().getId() == nv.getVertice().getId())
                        listanueva.Add(getCNVenGR(cnv.getVertice().getId()));
                }
            }

            return listanueva;
        }

        public CNodoVertice getCNVenGR(int id)
        { 
            CNodoVertice en = null;
            foreach (CNodoVertice cnv in GR)
            {
                if (cnv.getVertice().getId() == id)
                {
                    en = cnv;
                    break;
                }
            }
            return en;
        }

        public CNodoVertice getCNVdeNumeroMasAltoEnG()
        {
            CNodoVertice mayor = G.getListaAdyacencia()[0];
            foreach (CNodoVertice cnv in G.getListaAdyacencia())
            {
                if (cnv.getVertice().getNumero() > mayor.getVertice().getNumero())
                    mayor = cnv;
            }
            return mayor;
        }

        public int ordenaPorNumero(CNodoVertice nv1,CNodoVertice nv2)
        {
            return nv2.getVertice().getNumero().CompareTo(nv1.getVertice().getNumero());
        }

        public int ordenaPorID(CNodoVertice nv1, CNodoVertice nv2)
        {
            return nv1.getVertice().getId().CompareTo(nv2.getVertice().getId());
        }

        //Recorrido en Amplitud
        public void recorridoEnAmplitud(CNodoVertice vert_ini)
        {
            vert_ini.getVertice().setVisitado(true);
            List<CNodoVertice> Vp = construyeLAdyPrima(G.getListaAdyacencia(), vert_ini);
            List<CNodoVertice> Q = new List<CNodoVertice>();
            Q.Add(vert_ini);

            while (Vp.Count != 0)
            {
                CNodoVertice u = Q[0];
                Q.RemoveAt(0);
                foreach (CNodoVertice w in u.getRelaciones())
                {
                    if (!w.getVertice().getVisitado())
                    {
                        w.getVertice().setVisitado(true);
                        Q.Add(w);
                        enlistaArcosArbol(u.getVertice(), w.getVertice());
                        Vp.Remove(w);
                    }
                }
            }

        }

        public List<CNodoVertice> construyeLAdyPrima(List<CNodoVertice> lady, CNodoVertice cnv_elim)
        {
            List<CNodoVertice> prima = new List<CNodoVertice>();
            foreach (CNodoVertice cnv in lady)
                prima.Add(cnv);

            prima.Remove(cnv_elim);
            return prima;
        }

        //Puntos de articulacion
        public void RecorridoEnProfundidadPtosArticulacion(CNodoVertice cnvid)
        {
            foreach (CNodoVertice cv in G.getListaAdyacencia())
                cv.getVertice().setVisitado(false);

            if (cnvid.getVertice().getVisitado() != true)
                RP_RPA(cnvid);

            foreach (CNodoVertice cnv in G.getListaAdyacencia())
            {
                if (cnv.getVertice().getId() != cnvid.getVertice().getId())
                    if (cnv.getVertice().getVisitado() != true)
                        RP_RPA(cnv);
            }
        }

        public void RP_RPA(CNodoVertice cnv)
        {
            cnv.getVertice().setVisitado(true);
            foreach (CNodoVertice w in cnv.getRelaciones())
            {
                if (w.getVertice().getVisitado() != true)
                    RP_RPA(w);
            }
            cnv.getVertice().setBajo(minimo(cnv.getVertice().getNumero(),getZde(cnv),getYde(cnv)));
        }

        public int getZde(CNodoVertice cnv)
        {
            List<int> zetas;
            int zmin = -1;

            if (arcos_arbol.Count != 0 && arcos_retroceso.Count != 0)
            {
                zetas = new List<int>();
                foreach (CArista a in arcos_retroceso)
                {
                    if (a.getVOrigen().getId() == cnv.getVertice().getId())
                        zetas.Add(a.getVDestino().getNumero());
                    else if (a.getVDestino().getId() == cnv.getVertice().getId())
                        zetas.Add(a.getVOrigen().getNumero());
                }

                if (zetas.Count != 0)
                {
                    zetas.Sort();
                    zmin = zetas[0];
                }
            }

            return zmin;
        }

        public int getYde(CNodoVertice cnv)
        {
            List<int> yes =new List<int>();
            int ymin = -1;
            foreach (CArista a in arcos_arbol)
            {
                CVertice or = a.getVOrigen(), de = a.getVDestino();
                int num_or = or.getNumero(), num_de = de.getNumero();
                if (or.getId() == cnv.getVertice().getId() && num_or < num_de)
                {
                    if(de.getBajo() != 0)
                        yes.Add(de.getBajo());
                }
                else if (de.getId() == cnv.getVertice().getId() && num_de < num_or)
                {
                    if (or.getBajo() != 0)
                        yes.Add(or.getBajo());
                }

                if (yes.Count != 0)
                {
                    yes.Sort();
                    ymin = yes[0];
                }
            }

            return ymin;
        }

        public int minimo(int nodo_num, int z_num, int y_num)
        {
            List<int> m = new List<int>();

            m.Add(nodo_num);
            if (z_num != -1)
                m.Add(z_num);
            if (y_num != -1)
                m.Add(y_num);

            m.Sort();
            return m[0];
        }

        public void sacaPuntosDeArticulacion(CNodoVertice cnv_ini)
        {
            List<CNodoVertice> puntos_articulacion = new List<CNodoVertice>();

            if (laRaizTiene2OMasHijos(cnv_ini))
                puntos_articulacion.Add(cnv_ini);

            foreach (CNodoVertice cnv in G.getListaAdyacencia())
            {
                if (cnv.getVertice().getId() != cnv_ini.getVertice().getId() && tieneHijosConBajoMayorOIgualAlNumDe(cnv))
                    puntos_articulacion.Add(cnv);
            }

            if(puntos_articulacion.Count != 0)
            {
                string cad = "{ ";
                foreach (CNodoVertice p in puntos_articulacion)
                {
                    p.getVertice().setRelleno(Color.LightPink.ToArgb());
                    p.getVertice().dibujate(Graphics.FromImage(G.getBMP()), G.getBMP(),tp);
                    cad += "(" + p.getVertice().getId().ToString() + ")";
                    if(puntos_articulacion.IndexOf(p) != puntos_articulacion.Count-1)
                        cad += ", ";
                }
                cad += " }.        ";
                MessageBox.Show(" Vértices Cut : "+cad, "Puntos de articulación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                foreach (CNodoVertice p in puntos_articulacion)
                {
                    p.getVertice().borrate(Graphics.FromImage(G.getBMP()), G.getBMP(), tp);
                    p.getVertice().setRelleno(Color.LightGoldenrodYellow.ToArgb());
                    p.getVertice().dibujate(Graphics.FromImage(G.getBMP()), G.getBMP(), tp);
                }
            }
            else
                MessageBox.Show(" No existen vértices CUT para el Grafo "+G.getId().ToString()+".     ","Puntos de articulación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public bool tieneHijosConBajoMayorOIgualAlNumDe(CNodoVertice cnv)
        { 
            foreach (CArista a in arcos_arbol)
            {
                CVertice or = a.getVOrigen(), de = a.getVDestino();
                int num_or = or.getNumero(), num_de = de.getNumero();
                if (or.getId() == cnv.getVertice().getId() && num_or < num_de && de.getBajo() >= cnv.getVertice().getNumero())
                    return true;
                else if (de.getId() == cnv.getVertice().getId() && num_de < num_or && or.getBajo() >= cnv.getVertice().getNumero())
                    return true;
            }
            return false;
        }

        public bool laRaizTiene2OMasHijos(CNodoVertice cnv_ini)
        {
            int num_hijos = 0;
            foreach (CArista a in arcos_arbol)
            {
                CVertice or = a.getVOrigen(), de = a.getVDestino();
                int num_or = or.getNumero(), num_de = de.getNumero();
                if ((or.getId() == cnv_ini.getVertice().getId() && num_or < num_de) ||
                    (de.getId() == cnv_ini.getVertice().getId() && num_de < num_or))
                {
                    num_hijos++;
                }
            }

            if (num_hijos >= 2)
                return true;

            return false;
        }
    }
}
