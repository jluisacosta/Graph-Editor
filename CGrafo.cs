using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Editor_de_Gafos
{
    [Serializable]
    public class CGrafo
    {
        //Atributos principales de manejo
        private List<CNodoVertice> lista_adyacencia;
        private List<CArista> lista_aristas;                     //Lista Para pintado
        //Atributos modificados en la corrida
        private CMatrizAdyacencia ma;
        private CMatrizIncidencia mi;
        private int id,tipo,num_aristas,num_vertices;
        private Bitmap bmp, bmp2;
        public int op = -1,primer_arista=-1;
        private Point pin, pfi;
        private CVertice vertact;
        List<CVertice> contrac;
        private bool idar;
        private bool par;
        public const int NO_DIRIGIDO = 0, DIRIGIDO = 1, MOV_GRAFO = 1, BORRA_GRAFO = 2, ADD_VERT = 3, REM_VERT = 4, MOV_VERT = 5, ADD_ARIND = 6, ADD_ARID = 7, REM_ARI = 8,CONTRACCION = 11,ELIMINACION = 12,SUBDIVISION = 13;


        //Constructores
        public CGrafo(TabControl pestanas, int num_grafo, int tipo_grafo)
        {
            TabPage tp;
            id = num_grafo;
            tp = new TabPage("Grafo " + id.ToString());
            tp.BackColor = Color.White;
            tp.MouseDown += new MouseEventHandler(tp_MouseDown);
            tp.Paint += new PaintEventHandler(tp_Paint);
            tp.MouseMove += new MouseEventHandler(tp_MouseMove);
            tp.MouseUp += new MouseEventHandler(tp_MouseUp);
            pestanas.Controls.Add(tp);
            lista_adyacencia = new List<CNodoVertice>();
            lista_aristas = new List<CArista>();
            tipo = tipo_grafo;
            num_aristas = 0;
            num_vertices = 0;
            bmp = new Bitmap(tp.Width, tp.Height);
            bmp2 = new Bitmap(tp.Width, tp.Height);
            vertact = null;
            contrac = new List<CVertice>();
            idar = par =false;
        }

        public CGrafo(TabControl pestanas, int ident, int tipg,List<CNodoVertice> l_ady,List<CArista> l_ar, int n_ari,int n_ver)
        {
            id = ident;
            TabPage tp = new TabPage("Grafo " + id.ToString());
            tp.BackColor = Color.White;
            tp.MouseDown += new MouseEventHandler(tp_MouseDown);
            tp.Paint += new PaintEventHandler(tp_Paint);
            tp.MouseMove += new MouseEventHandler(tp_MouseMove);
            tp.MouseUp += new MouseEventHandler(tp_MouseUp);
            pestanas.Controls.Add(tp);
            lista_adyacencia = l_ady;
            lista_aristas = l_ar;
            tipo = tipg;
            num_aristas = n_ari;
            num_vertices = n_ver;
            bmp = new Bitmap(tp.Width, tp.Height);
            bmp2 = new Bitmap(tp.Width, tp.Height);
            vertact = null;
            contrac = new List<CVertice>();
            dibujate(tp,bmp);
            idar = par = false;
        }


        //Constructor grafos ficticios
        public CGrafo(int ng, int tipo_g)
        {
            id = ng;
            lista_adyacencia = new List<CNodoVertice>();
            lista_aristas = new List<CArista>();
            tipo = tipo_g;
            num_aristas = 0;
            num_vertices = 0;
        }

        //SWITCH PRNCIPAL
        public void clickIzquierdo(MouseEventArgs e, TabPage tp)
        {
            switch (op)
            {
                case ADD_VERT:
                    addNodoVertice(e, tp);
                break;
                case REM_VERT:
                    removeVertice(e, tp);
                break;
                case MOV_VERT:
                    if (punteroSobreNodo(e.X, e.Y, ref vertact))
                    {
                        Graphics g = Graphics.FromImage(bmp);
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        vertact.borrateMov(g);
                        borraAristas(vertact, g);
                    }
                break;
                case ADD_ARIND: case ADD_ARID:
                    if (punteroSobreNodo(e.X, e.Y, ref vertact))
                        pin = e.Location;
                break;
                case REM_ARI:case ELIMINACION:
                    CArista ari = null;
                    if (punteroSobreArista(e.X, e.Y, ref ari) && ari != null)
                            eliminaAristaSencilla(ari, tp);
                break;
                case SUBDIVISION:
                    CArista arist = null;
                    if (punteroSobreArista(e.X, e.Y, ref arist))
                        if (arist != null)
                            subdivisionArista(arist, tp);
                break;
                case CONTRACCION:
                    CVertice vaux = null;
                    if(contrac.Count<2 && punteroSobreNodo(e.X,e.Y,ref vaux))
                    {
                        if (!hayVerticeConId(contrac, vaux.getId()))
                        {
                            contrac.Add(vaux);
                            if (contrac.Count == 2)
                            {
                                if (sonVerticesAdyacentes(contrac[0], contrac[1]))
                                {
                                    if (!tienenVerticesEnComun(contrac[0], contrac[1]))
                                        contraccionDeDosVertices(contrac[0], contrac[1], tp);
                                    else
                                        MessageBox.Show(" No se pueden contraer vertices que tienen vecinos en común! ", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    contrac.Clear();
                                }
                                else
                                    MessageBox.Show(" No se pueden contraer vertices que no son adyacentes! ", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show(" No se puede contraer el vertice " + vaux.getId().ToString() + " consigo mismo! ", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            contrac.Clear();
                        }
                    }
                break;
            }
        }

        public void clickDerecho(MouseEventArgs e, TabPage tp)
        {
            CVertice v = null;
            string cad = "";
            if (punteroSobreNodo(e.X, e.Y, ref v))
            {
                if (v != null)
                {
                    int grad = v.getGrado();
                    ToolTip tt = new ToolTip();
                    tt.ToolTipTitle = " Grado Vértice " + v.getId().ToString() + " : ";
                    tt.AutomaticDelay = 300;
                    tt.AutoPopDelay = 2000;
                    if (this.tipo == NO_DIRIGIDO)
                    {
                        if (grad == 0)
                            cad = " (Aislado)";
                        else if (grad == 1)
                            cad = " (Pendiente)";

                        tt.SetToolTip(tp, " " + v.getGrado().ToString() + cad);
                    }
                    else if (this.tipo == DIRIGIDO)
                    {
                        tt.SetToolTip(tp, " Externo: " + v.getGrado().ToString() + "\n" + " Interno :" + v.getGradoInt().ToString());
                    }
                    else
                    {
                        cad = " (Aislado)";
                        tt.SetToolTip(tp, " " + v.getGrado().ToString() + cad);
                    }
                }
            }
        } //Visualizar Grado de los nodos


        //Manejadores del TabPage
        void tp_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                clickIzquierdo(e,(TabPage)sender);
            else if (e.Button == MouseButtons.Right)
                clickDerecho(e,(TabPage)sender);
        }

        void tp_Paint(object sender, PaintEventArgs e)
        {
            TabPage tp = (TabPage)sender;
            Graphics g = tp.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.Clear(tp.BackColor);
            g.DrawImage(bmp, 0, 0);
            if (idar)
                showHideIdAristas(true, (TabPage)sender);
            if(par)
                showHidePesos(true, (TabPage)sender);
        }
        
        void tp_MouseMove(object sender, MouseEventArgs e)
        {
            switch (op)
            {
                case MOV_VERT:
                    moveVertice(e, (TabPage)sender);
                break;
                case ADD_ARIND: case ADD_ARID:
                     addArista(e, (TabPage)sender);
                break;
            }
        }

        void tp_MouseUp(object sender, MouseEventArgs e)
        {
            switch (op)
            {
                case MOV_VERT:
                    vertact = null;
                    bmp = new Bitmap(bmp2);
                break;
                case ADD_ARIND: case ADD_ARID:
                    if (e.Button == MouseButtons.Left)
                    {
                        if (vertact != null)
                            borraElastica((TabPage)sender);
                        verificaPrimerArista();
                        agregaAristaLista(e, (TabPage)sender);
                    }
                    vertact = null;
                break;
            }
        }


        //Operaciones Vertice
        public void addNodoVertice(MouseEventArgs e,TabPage tp)
        {
            if (!estaEmpalmado(new Point(e.X, e.Y)) && !quedaAfuera(new Point(e.X, e.Y), tp))
            {
                Graphics g = Graphics.FromImage(bmp);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                CVertice vertice = new CVertice(this.asignaId(), e.X, e.Y, Color.LightGoldenrodYellow, Color.CornflowerBlue);
                lista_adyacencia.Add(new CNodoVertice(vertice));
                lista_adyacencia.Sort(ordenaPorId);
                num_vertices++;
                vertice.dibujate(g, bmp,tp);
            }
        }

        public void removeVertice(MouseEventArgs e,TabPage tp)
        {
            CVertice v = null;
            if (punteroSobreNodo(e.X, e.Y, ref v))
            {
                if (v != null)
                {
                    Graphics g = Graphics.FromImage(bmp),g2 = tp.CreateGraphics();
                    CNodoVertice cnv = null;
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    cnv = buscaNodoVertice(v);
                    v.borrate(g,bmp,tp);
                    eliminaAristasIncidente(v);
                    
                    if(cnv != null)
                    {
                        lista_adyacencia.Remove(cnv);
                        g.Clear(Color.White);
                        dibujate(tp, bmp);
                        num_vertices--;
                    }
                }
            }
        }
        
        public void removeAristasListaAdy(CNodoVertice cnv,CNodoVertice cnvborrar)
        {
            foreach (CNodoVertice nv in lista_adyacencia)
            {
                if (nv.getVertice().getId() == cnv.getVertice().getId())
                {
                    nv.getRelaciones().Remove(cnvborrar);
                    break;
                }
            }
        }    //Operacion combinada con aristas

        public void moveVertice(MouseEventArgs e, TabPage tp)
        {
            if (e.Button == MouseButtons.Left && vertact != null)
            {
                Graphics pag = Graphics.FromImage(bmp2),principal = tp.CreateGraphics();
                pag.SmoothingMode = principal.SmoothingMode= System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                
                vertact.setPuntoCenral(new Point(e.X, e.Y));
                pag.Clear(Color.White);
                pag.DrawImage(bmp, 0, 0);
                mueveVertice(vertact,pag,tp);
                vertact.dibujateMov(pag, tp);
                principal.DrawImage(bmp2, 0, 0);
            }
        }
        
        public void mueveVertice(CVertice vertmov,Graphics g, TabPage tp)
        {
            foreach (CArista a in lista_aristas)
            {
                Point po = new Point(),pd = new Point();
                if (a.getVOrigen().getId() == vertmov.getId() || a.getVDestino().getId() == vertmov.getId())
                {
                    normalizarAristaMov(a.getVOrigen(), a.getVDestino(), tp, ref po, ref pd, g);
                    a.setPuntoOD(po, pd);
                }
            }
        }

        public void contraccionDeDosVertices(CVertice v1,CVertice v2,TabPage tp)
        {
            List<CArista> la = getAristasIncidentesA(v2);
            List<CArista> laem = new List<CArista>();

            foreach (CArista a in la)
            {
                if (a.getVOrigen().getId() == v2.getId() && v1.getId() != a.getVDestino().getId() && !aristaRepetida(v1,a.getVDestino()))
                {
                    CNodoVertice cnvo = buscaNodoVertice(v1), cnvd = buscaNodoVertice(a.getVDestino());
                    Point po = new Point(),pd = new Point();

                    cnvo.getRelaciones().Add(cnvd);
                    cnvo.getRelaciones().Sort(ordenaPorId);
                    if (tipo == NO_DIRIGIDO)
                    {
                        cnvd.getRelaciones().Add(cnvo);
                        cnvd.getRelaciones().Sort(ordenaPorId);
                    }
                    v1.getVecinos().Add(a.getVDestino());
                    v1.getVecinos().Sort(ordenaPorGrado);
                    a.getVDestino().getVecinos().Add(v1);
                    a.getVDestino().getVecinos().Remove(v2);
                    a.getVDestino().getVecinos().Sort(ordenaPorGrado);
                    v1.aumentaGrado();
                    a.setVOrigen(v1);
                    normalizarAristaSencilla(v1, a.getVDestino(), ref po, ref pd);
                    a.setPO(po);
                    a.setPD(pd);
                }
                else if (a.getVDestino().getId() == v2.getId() && v1.getId() != a.getVOrigen().getId() && !aristaRepetida(a.getVOrigen(), v1))
                {
                    CNodoVertice cnvd = buscaNodoVertice(v1), cnvo = buscaNodoVertice(a.getVOrigen());
                    Point po = new Point(), pd = new Point();

                    cnvo.getRelaciones().Add(cnvd);
                    cnvo.getRelaciones().Sort(ordenaPorId);
                    if (tipo == NO_DIRIGIDO)
                    {
                        cnvd.getRelaciones().Add(cnvo);
                        cnvd.getRelaciones().Sort(ordenaPorId);
                        v1.aumentaGrado();
                    }
                    else
                        v1.aumentaGradoInt();

                    v1.getVecinos().Add(a.getVOrigen());
                    v1.getVecinos().Sort(ordenaPorGrado);
                    a.getVOrigen().getVecinos().Add(v1);
                    a.getVOrigen().getVecinos().Remove(v2);
                    a.getVOrigen().getVecinos().Sort(ordenaPorGrado);
                    a.setVDestino(v1);
                    normalizarAristaSencilla(a.getVOrigen(),v1, ref po, ref pd);
                    a.setPO(po);
                    a.setPD(pd);
                }
                else
                {
                    laem.Add(a);
                }
            }
            foreach (CArista a in laem)
            {
                eliminaAristaSencilla(a, tp);
            }
            Graphics g = Graphics.FromImage(bmp);
            CNodoVertice cnv = buscaNodoVertice(v2);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.Clear(Color.White);
            foreach (CNodoVertice cva in lista_adyacencia)
            {
                cva.getRelaciones().Remove(cnv);
            }
            lista_adyacencia.Remove(cnv);
            this.dibujate(tp, bmp);
            num_vertices--;
            esNoPlanoKuratowsky();
        }

        //Validaciones de operaciones vertice
        public bool estaEmpalmado(Point punto)
        {
            bool empalmado = false;
            foreach (CNodoVertice cnv in lista_adyacencia)
            {
                CVertice vert = cnv.getVertice();
                if (calculaDistancia(vert.getPuntoCentral(), punto) < 2 * (vert.getRadio()))
                {
                    empalmado = true;
                    break;
                }
            }
            return empalmado;
        }

        public bool quedaAfuera(Point punto, TabPage tp)
        {
            bool fuera = false;
            int radio = 30;

            if (calculaDistancia(punto, new Point(0, punto.Y)) < radio || calculaDistancia(punto, new Point(punto.X, 0)) < radio ||
                calculaDistancia(punto, new Point(tp.Width, punto.Y)) < radio || calculaDistancia(punto, new Point(punto.X, tp.Height)) < radio)
            {
                fuera = true;
            }
            return fuera;
        }


        //Operaciones Arista
        public void addArista(MouseEventArgs e, TabPage tp)
        {
            if (e.Button == MouseButtons.Left && vertact != null)
            {
                Graphics pag = Graphics.FromImage(bmp2), g = Graphics.FromImage(bmp),principal = tp.CreateGraphics();
                Pen p = new Pen(Color.CornflowerBlue,4);
                
                principal.SmoothingMode = pag.SmoothingMode = g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                if (this.tipo == DIRIGIDO)
                    p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;

                pfi = e.Location;
                pag.Clear(Color.White);
                pag.DrawImage(bmp, 0, 0);
                pag.DrawLine(p, pin, pfi);
                principal.DrawImage(bmp2, 0, 0);
            }
        }

        public void agregaAristaLista(MouseEventArgs e,TabPage tp)
        { 
            CVertice v2 = null,vbuscado = null;
            if (punteroSobreNodo(e.X, e.Y, ref  v2))
            {
                if (vertact != null)
                {
                    vbuscado = buscaVertice(vertact);
                    if (vbuscado != null && vertact.getId() != v2.getId() && !aristaRepetida(vbuscado, v2))
                    {
                        Point po = new Point(), pd = new Point();
                        normalizarArista(vbuscado, v2, tp, ref po, ref pd);
                        CArista nva_ar = new CArista(vbuscado, v2, po, pd, primer_arista);

                        if (this.tipo != NO_DIRIGIDO)
                            v2.aumentaGradoInt();
                        else
                            v2.aumentaGrado();

                        vbuscado.aumentaGrado();
                        vbuscado.getVecinos().Add(v2);
                        vbuscado.getVecinos().Sort(ordenaPorGrado);
                        v2.getVecinos().Add(vbuscado);
                        v2.getVecinos().Sort(ordenaPorGrado);
                        this.lista_aristas.Add(nva_ar);
                        insertaAristaListaAdyacencia(vbuscado, v2);
                        num_aristas++;
                    }
                    else
                        borraElastica(tp);
                }
            }
        }

        public void insertaAristaListaAdyacencia(CVertice vo, CVertice vd)
        {
            foreach (CNodoVertice cnv in lista_adyacencia)
            {
                if (vo.getId() == cnv.getVertice().getId())
                {
                    cnv.getRelaciones().Add(buscaNodoVertice(vd));
                    cnv.getRelaciones().Sort(ordenaPorId);
                    break;
                }
            }
            if (this.tipo == NO_DIRIGIDO)
            {
                foreach (CNodoVertice cnv in lista_adyacencia)
                {
                    if (vd.getId() == cnv.getVertice().getId())
                    {
                        cnv.getRelaciones().Add(buscaNodoVertice(vo));
                        cnv.getRelaciones().Sort(ordenaPorId);
                        break;
                    }
                }
            }
        }

        public void eliminaAristasIncidente(CVertice vert)
        {
            List<CArista> arrem = new List<CArista>();
            Graphics g = Graphics.FromImage(bmp);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            foreach (CArista a in lista_aristas)
            {
                if (a.getVOrigen().getId() == vert.getId())
                {
                    arrem.Add(a);
                    a.getVOrigen().getVecinos().Remove(a.getVDestino());
                    a.getVDestino().getVecinos().Remove(a.getVOrigen());

                    if (tipo == DIRIGIDO)
                        a.getVDestino().disminuyeGradoInt();
                    else
                    {
                        a.getVDestino().disminuyeGrado();
                        removeAristasListaAdy(buscaNodoVertice(a.getVDestino()), buscaNodoVertice(a.getVOrigen()));
                    }
                    
                    removeAristasListaAdy(buscaNodoVertice(a.getVOrigen()), buscaNodoVertice(a.getVDestino()));
                }
                else if (a.getVDestino().getId() == vert.getId())
                {
                    arrem.Add(a);
                    a.getVOrigen().disminuyeGrado();
                    a.getVOrigen().getVecinos().Remove(a.getVDestino());
                    a.getVDestino().getVecinos().Remove(a.getVOrigen());
                    removeAristasListaAdy(buscaNodoVertice(a.getVOrigen()), buscaNodoVertice(a.getVDestino()));

                    if (tipo == NO_DIRIGIDO)
                        removeAristasListaAdy(buscaNodoVertice(a.getVDestino()), buscaNodoVertice(a.getVOrigen()));
                }
            }

            foreach (CArista a in arrem)
            {
                lista_aristas.Remove(a);
                num_aristas--;
            }

            borraAristas(vert, g);
        }

        public void eliminaAristaSencilla(CArista arista,TabPage tp)
        {
            CVertice origen = arista.getVOrigen(), destino = arista.getVDestino();
            CNodoVertice cnvo = buscaNodoVertice(origen),cnvd =buscaNodoVertice(destino);

            cnvo.getRelaciones().Remove(cnvd);
            
            origen.getVecinos().Remove(destino);
            origen.disminuyeGrado();
            destino.getVecinos().Remove(origen);

            if (tipo == NO_DIRIGIDO)
            {
                cnvd.getRelaciones().Remove(cnvo);
                destino.disminuyeGrado();
            }
            else
            {
                destino.getVecinos().Remove(origen);
                destino.disminuyeGradoInt();
            }

            lista_aristas.Remove(arista);
            num_aristas--;
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            dibujate(tp, bmp);
            if (op == ELIMINACION)
                esNoPlanoKuratowsky();
        }
        
        //Validaciones de operaciones aristas
        
        public void verificaPrimerArista()
        {
            if (lista_aristas.Count == 0)
            {
                this.tipo = primer_arista;
            }
        }

        public bool aristaRepetida(CVertice ori, CVertice dest)
        {
            CVertice vo, vd, vo1, vd1;
            bool band = false;

            //if(this.tipo == NO_DIRIGIDO)
            //{
            foreach (CArista a in lista_aristas)
            {
                vd1 = vo = a.getVOrigen();
                vo1 = vd = a.getVDestino();

                if ((ori.getId() == vo.getId() && dest.getId() == vd.getId()) ||
                    (ori.getId() == vo1.getId() && dest.getId() == vd1.getId()))
                {
                    band = true;
                }
            }
            //}
            /*else if(this.tipo == DIRIGIDO)
            {
                 foreach (CArista a in lista_aristas)
                 {
                     vo = a.getVOrigen();
                     vd = a.getVDestino();

                     if(ori.getId() == vo.getId() && dest.getId() == vd.getId())
                     {
                         band = true;
                     }
                 }
            }*/

            return band;
        }

        public void subdivisionArista(CArista arista, TabPage tp)
        {
            Point np = getNvoPtoCtrlSubdivision(arista),po = new Point(),pnv1 = new Point(),pnv2 = new Point(),pd = new Point();
            CVertice nv = new CVertice(this.asignaId(), np.X, np.Y, Color.LightGoldenrodYellow, Color.CornflowerBlue);
            CNodoVertice cnv = new CNodoVertice(nv),cnvo = buscaNodoVertice(arista.getVOrigen()),cnvd = buscaNodoVertice(arista.getVDestino());
            CArista nao, nad;

            normalizarAristaSencilla(cnvo.getVertice(), nv, ref po, ref pnv1);
            normalizarAristaSencilla(nv, cnvd.getVertice(), ref pnv2, ref pd);
            nao = new CArista(cnvo.getVertice(), nv, po, pnv1, tipo);
            nad = new CArista(nv,cnvd.getVertice(), pnv2, pd, tipo);
            lista_aristas.Add(nao);
            lista_aristas.Add(nad);
            lista_adyacencia.Add(cnv);
            lista_adyacencia.Sort(ordenaPorId);

            cnvo.getRelaciones().Add(cnv);
            cnvo.getVertice().getVecinos().Add(cnv.getVertice());
            cnvo.getVertice().aumentaGrado();
            cnv.getVertice().getVecinos().Add(cnvo.getVertice());
            cnv.getRelaciones().Add(cnvd);
            cnv.getVertice().getVecinos().Add(cnvd.getVertice());
            cnv.getVertice().aumentaGrado();
            cnvd.getVertice().getVecinos().Add(cnv.getVertice());
            
            if (tipo == NO_DIRIGIDO)
            {
                cnv.getRelaciones().Add(cnvo);
                cnv.getVertice().aumentaGrado();
                cnvd.getRelaciones().Add(cnv);
                cnvd.getVertice().aumentaGrado();
            }
            else
            {
                cnv.getVertice().aumentaGradoInt();
                cnvd.getVertice().aumentaGradoInt();
            }

            cnv.getVertice().getVecinos().Sort(ordenaPorGrado);
            cnvo.getVertice().getVecinos().Sort(ordenaPorGrado);
            cnvd.getVertice().getVecinos().Sort(ordenaPorGrado);
            cnv.getRelaciones().Sort(ordenaPorId);
            cnvo.getRelaciones().Sort(ordenaPorId);
            cnvd.getRelaciones().Sort(ordenaPorId);
            eliminaAristaSencilla(arista, tp);
            num_aristas += 2;
            num_vertices++;
            esNoPlanoKuratowsky();
        }


        //Dibujado de grafo
        public void dibujate(TabPage tp,Bitmap bmpg) //Dibujar vertices y aristas
        {
            Graphics g = Graphics.FromImage(bmpg);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            foreach (CNodoVertice cnv in lista_adyacencia)
            {
                cnv.getVertice().dibujate(g,bmpg, tp);
            }

            foreach (CArista a in lista_aristas)
            {
                a.dibujate(g, bmpg, tp);
            }
        }
        
        public void borraElastica(TabPage tp)
        {
            Graphics g = Graphics.FromImage(bmp2),g2 = tp.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.Clear(Color.White);
            g2.Clear(Color.White);
            g2.DrawImage(bmp2, 0, 0);
            g2.DrawImage(bmp, 0, 0);
        }
        
        public void normalizarArista(CVertice v1, CVertice v2,TabPage tp,ref Point po,ref Point pd)
        {
            Graphics g = Graphics.FromImage(bmp), g2 = tp.CreateGraphics() ;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Pen p = new Pen(Color.CornflowerBlue,4);
            double xc1 = 0, yc1 = 0,x1 = v1.getPuntoCentral().X,
                   x2 = v2.getPuntoCentral().X, y1 = v1.getPuntoCentral().Y,
                   y2 = v2.getPuntoCentral().Y,rad = v1.getRadio(), rad2 = v1.getRadio(),
                   xc2 = 0, yc2 = 0;
            
            if (y1 > y2)
                rad *= -1;

            xc1 = x1 + rad * (Math.Sin(Math.Atan((x2 - x1) / (y2 - y1))));
            yc1 = y1 + rad * (Math.Cos(Math.Atan((x2 - x1) / (y2 - y1))));
            xc2 = x2 - rad * (Math.Sin(Math.Atan((x2 - x1)/(y2 - y1))));
            yc2 = y2 - rad * (Math.Cos(Math.Atan((x2 - x1)/(y2 - y1))));

            po = new Point(Convert.ToInt32(xc1),Convert.ToInt32(yc1));
            pd = new Point(Convert.ToInt32(xc2),Convert.ToInt32(yc2));

            if (this.tipo == DIRIGIDO)
                p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;

            g.DrawLine(p,Convert.ToSingle(xc1), Convert.ToSingle(yc1),Convert.ToSingle(xc2),Convert.ToSingle(yc2));
            g2.Clear(Color.White);
            g2.DrawImage(bmp, 0, 0);
        }

        public void normalizarAristaMov(CVertice v1, CVertice v2, TabPage tp, ref Point po, ref Point pd,Graphics g)
        {
            Pen p = new Pen(Color.CornflowerBlue,4);
            double xc1 = 0, yc1 = 0, x1 = v1.getPuntoCentral().X,
                   x2 = v2.getPuntoCentral().X, y1 = v1.getPuntoCentral().Y,
                   y2 = v2.getPuntoCentral().Y, rad = v1.getRadio(), rad2 = v1.getRadio(),
                   xc2 = 0, yc2 = 0;

            if (y1 > y2)
                rad *= -1;

            xc1 = x1 + rad * (Math.Sin(Math.Atan((x2 - x1) / (y2 - y1))));
            yc1 = y1 + rad * (Math.Cos(Math.Atan((x2 - x1) / (y2 - y1))));
            xc2 = x2 - rad * (Math.Sin(Math.Atan((x2 - x1) / (y2 - y1))));
            yc2 = y2 - rad * (Math.Cos(Math.Atan((x2 - x1) / (y2 - y1))));

            po = new Point(Convert.ToInt32(xc1), Convert.ToInt32(yc1));
            pd = new Point(Convert.ToInt32(xc2), Convert.ToInt32(yc2));

            if (this.tipo == DIRIGIDO)
                p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;

            g.DrawLine(p, Convert.ToSingle(xc1), Convert.ToSingle(yc1), Convert.ToSingle(xc2), Convert.ToSingle(yc2));
        }

        public void normalizarAristaSencilla(CVertice v1, CVertice v2,ref Point po, ref Point pd)
        {
            double xc1 = 0, yc1 = 0, x1 = v1.getPuntoCentral().X,
                   x2 = v2.getPuntoCentral().X, y1 = v1.getPuntoCentral().Y,
                   y2 = v2.getPuntoCentral().Y, rad = v1.getRadio(), rad2 = v1.getRadio(),
                   xc2 = 0, yc2 = 0;

            if (y1 > y2)
                rad *= -1;

            xc1 = x1 + rad * (Math.Sin(Math.Atan((x2 - x1) / (y2 - y1))));
            yc1 = y1 + rad * (Math.Cos(Math.Atan((x2 - x1) / (y2 - y1))));
            xc2 = x2 - rad * (Math.Sin(Math.Atan((x2 - x1) / (y2 - y1))));
            yc2 = y2 - rad * (Math.Cos(Math.Atan((x2 - x1) / (y2 - y1))));

            po = new Point(Convert.ToInt32(xc1), Convert.ToInt32(yc1));
            pd = new Point(Convert.ToInt32(xc2), Convert.ToInt32(yc2));
        }

        public void borraAristas(CVertice vertmov, Graphics g)
        {
            foreach (CArista a in lista_aristas)
            {
                if (a.getVOrigen().getId() == vertmov.getId())
                {
                    a.borrateMov(g);
                }
                else if (a.getVDestino().getId() == vertmov.getId())
                {
                    a.borrateMov(g);
                }
            }
        }

        public void borrate(TabPage tp)
        {
            Graphics gbmp = Graphics.FromImage(bmp),gbmp2 = Graphics.FromImage(bmp2),gfinal = tp.CreateGraphics();
            gbmp.Clear(Color.White);
            gbmp2.Clear(Color.White);
            gfinal.Clear(Color.White);
            gfinal.DrawImage(bmp, 0, 0);
        }


        //Metodos funcionales
        public bool punteroSobreNodo(int x2, int y2,ref CVertice vert)
        {
            Point p; 
            bool dentro = false;
            double dist = 0;

            foreach (CNodoVertice cnv in lista_adyacencia)
            { 
                p = new Point(cnv.getVertice().getPuntoCentral().X,cnv.getVertice().getPuntoCentral().Y);
                dist = Convert.ToDouble(Math.Sqrt(Convert.ToDouble(Math.Pow(x2 - p.X, 2)) + Convert.ToDouble(Math.Pow(y2 - p.Y, 2))));
                if (dist <= cnv.getVertice().getRadio())
                {
                    dentro = true;
                    vert = cnv.getVertice();
                    break;
                }
            }
            
            return dentro;
        }   //Regresa true si esta dentro de algun vertice y regresa por referencia en cual

        public bool punteroSobreArista(int x2, int y2, ref CArista arista)
        {
            bool band = false;

            foreach (CArista ait in lista_aristas)
            { 
                if(pasaPorlaRecta(x2,y2,ait))
                {
                    arista = ait;
                    band = true;
                    break;
                }

            }
            return band;
        }

        public bool pasaPorlaRecta(int x, int y, CArista a) 
        {
            double x1 = a.getVOrigen().getPuntoCentral().X, y1 = a.getVOrigen().getPuntoCentral().Y;
            double x2 = a.getVDestino().getPuntoCentral().X, y2 = a.getVDestino().getPuntoCentral().Y;
            double mx1 = 0,A=0,B=0,C=0,dist = 0,xf1=0,yf1=0,xf2=0,yf2=0;
            bool band = false;

            A = (y2 - y1) / (x2 - x1);
            mx1 = (A * -x1);
            C = mx1 + y1;
            B = -1;

            dist = Math.Abs((A * x) + (B * y) + C) / Math.Sqrt((Math.Pow(A, 2)) + (Math.Pow(B, 2)));

            if (x1 >= x2) { xf2 = x1; xf1 = x2;}
            else{ xf2 = x2; xf1 = x1;}

            if (y1 >= y2) { yf2 = y1; yf1 = y2;}
            else{ yf2 = y2; yf1 = y1;}

            if (dist < 5 && y >= yf1 && y <= yf2 && x >= xf1 && x <= xf2)
            {
                //MessageBox.Show(" Distancia : " + dist.ToString() + "\n Indice de arista : " + lista_aristas.IndexOf(a).ToString() + "\n X: " + x.ToString() + "\n Y: " + y.ToString());
                band = true;
            }

            return band;
        }
        
        public CNodoVertice buscaNodoVertice(CVertice vertice)
        {
            CNodoVertice encontrado = null;
            if (lista_adyacencia != null && lista_adyacencia.Count != 0)
            {
                foreach (CNodoVertice cnv in lista_adyacencia)
                {
                    if (cnv.getVertice().getId() == vertice.getId())
                    {
                        encontrado = cnv;
                        break;
                    }
                }
            }
            return encontrado;
        } //Encuentra el nodoVertice que contiene el vertice especificado

        public CNodoVertice buscaNodoVertice(int id)
        {
            CNodoVertice encontrado = null;
            if (lista_adyacencia != null && lista_adyacencia.Count != 0)
            {
                foreach (CNodoVertice cnv in lista_adyacencia)
                {
                    if (cnv.getVertice().getId() == id)
                    {
                        encontrado = cnv;
                        break;
                    }
                }
            }
            return encontrado;
        }  //Encuentra el nodoVertice que contiene el id especificado

        public double calculaDistancia(Point p1, Point p2)
        {
            double dist = 0;

            dist = Convert.ToDouble(Math.Sqrt(Convert.ToDouble(Math.Pow(p2.X - p1.X, 2)) + Convert.ToDouble(Math.Pow(p2.Y-p1.Y, 2))));

            return dist;
        } //Calcula la distancia entre dos puntos

        public CVertice buscaVertice(CVertice vertice)
        {
            CVertice encontrado = null;
            if (lista_adyacencia != null && lista_adyacencia.Count != 0)
            {
                foreach (CNodoVertice cnv in lista_adyacencia)
                {
                    if (cnv.getVertice().getId() == vertice.getId())
                    {
                        encontrado = cnv.getVertice();
                        break;
                    }
                }
            }
            return encontrado;
        } //Busca y regresa la referencia de la lista de adyacencia de un vertice determinado

        public int ordenaPorId(CNodoVertice v1, CNodoVertice v2)
        {
            int comp = 0;
            comp = v1.getVertice().getId().CompareTo(v2.getVertice().getId());
            return comp;
        }//Delegado Sort por Id

        public int ordenaPorGrado(CVertice v1, CVertice v2)
        {
            int comp = 0;
            comp = v1.getId().CompareTo(v2.getId());
            return comp;
        } //Delegado Sort por grado

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

        public int[,] multiplicaMatrices(int[,] m1, int[,] m2)
        {
            int n = Convert.ToInt32(Math.Sqrt((double)m1.Length));
            int[,] mult = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    mult[i, j] = multiplicaRenglonColumna(m1, j, m2, i, n);
                }
            }

            return mult;
        }

        public int multiplicaRenglonColumna(int[,] m1, int columna, int[,] m2, int renglon,int n)
        {
            int suma = 0;
            for (int i = 0; i < n; i++)
            {
                suma += (m1[i, columna] * m2[renglon, i]); 
            }
            return suma;
        }

        public bool hayVerticeConId(List<CVertice> lvert, int idv)
        {
            bool band = false;

            foreach (CVertice ve in lvert)
            {
                if (idv == ve.getId())
                {
                    band = true;
                    break;
                }
            }

            return band;
        } //Verifica si en una lista de vertices dada hay un elemento con id = idv

        public bool sonVerticesAdyacentes(CVertice v1, CVertice v2)
        {
            int idvo=0,idvd=0,idv1 = v1.getId(),idv2 = v2.getId();
            foreach (CArista a in lista_aristas)
            {
                idvo=a.getVOrigen().getId();
                idvd=a.getVDestino().getId();
                if ((idvo == idv1 && idvd == idv2) || (idvo == idv2 && idvd == idv1))
                    return true;
            }

            return false;
        }

        public List<CArista> getAristasIncidentesA(CVertice v)
        {
            List<CArista> la = new List<CArista>();
            foreach (CArista a in lista_aristas)
            {
                if ((v.getId() == a.getVOrigen().getId()) || (v.getId() == a.getVDestino().getId()))
                    la.Add(a);
            }
            return la;
        }
        
        public Point getNvoPtoCtrlSubdivision(CArista arista)
        {
            double x1=arista.getVOrigen().getPuntoCentral().X,y1=arista.getVOrigen().getPuntoCentral().Y,
                   x2 = arista.getVDestino().getPuntoCentral().X,y2 = arista.getVDestino().getPuntoCentral().Y;
            int x = 0, y = 0;

            x = Convert.ToInt32((x1 + x2) / 2);
            y = Convert.ToInt32((y1 + y2) / 2);

            return (new Point(x,y));
        }

        public CArista getAristaDe(CVertice v1, CVertice v2)
        {
            int idvo = 0, idvd = 0, idv1 = v1.getId(), idv2 = v2.getId();
            CArista encontrada = null;

            foreach (CArista a in lista_aristas)
            {
                idvo = a.getVOrigen().getId();
                idvd = a.getVDestino().getId();
                if ((idvo == idv1 && idvd == idv2) || (idvo == idv2 && idvd == idv1))
                {
                    encontrada = a;
                    break;
                }
            }

            return encontrada;
        }

        public bool existeVerticeConId(int nuevo_id)
        {
            bool band = false;
            foreach (CNodoVertice cv in lista_adyacencia)
            {
                if (cv.getVertice().getId() == nuevo_id)
                {
                    band = true;
                    break;
                }
            }
            return band;
        }

        public int asignaId()
        {
            int id = 1;
            while (existeVerticeConId(id))
            {
                id++;
            }
            return id;
        }

        public bool tienenVerticesEnComun(CVertice v1, CVertice v2)
        {
            CNodoVertice cnv1 = buscaNodoVertice(v1), cnv2 = buscaNodoVertice(v2);

            foreach (CNodoVertice cnodv in cnv1.getRelaciones())
            {
                foreach (CNodoVertice cnodv2 in cnv2.getRelaciones())
                {
                    if (cnodv.getVertice().getId() == cnodv2.getVertice().getId())
                        return true;
                }
            }
            return false;
        }

        public void showHideIdAristas(bool show,TabPage tp)
        {
            Graphics g = tp.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            if (show)
            {
                Font f = new Font(FontFamily.GenericSansSerif, 11,FontStyle.Bold);
                int indx = 1;
                foreach (CArista a in lista_aristas)
                {
                    Point p = getNvoPtoCtrlSubdivision(a);
                    g.DrawString("E" + indx.ToString(),f, Brushes.Black, p.X, p.Y);
                    indx++;
                }
                idar = true;
            }
            else
            {
                g.Clear(Color.White);
                g.DrawImage(bmp, 0, 0);
                idar = false;
            }
        }

        public void showHidePesos(bool show, TabPage tp)
        {
            Graphics g = tp.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            if (show)
            {
                Font f = new Font(FontFamily.GenericSansSerif, 11, FontStyle.Bold);
                foreach (CArista a in lista_aristas)
                {
                    Point p = getNvoPtoCtrlSubdivision(a);
                    g.DrawString(a.getPeso().ToString(), f, Brushes.Red, p.X, p.Y);
                }
                par = true;
            }
            else
            {
                g.Clear(Color.White);
                g.DrawImage(bmp, 0, 0);
                par = false;
            }
        }

        public void borraRP()
        {
            foreach (CNodoVertice cnv in lista_adyacencia)
            {
                cnv.getVertice().setVisitado(false);
                cnv.getVertice().setNumero(0);
                cnv.getVertice().setBajo(0);
            }
        }


        //Conectividad
        public int[,] getAr(int r,bool in_conect)
        {
            int n = Convert.ToInt32(Math.Sqrt((double)this.getMatrizAdyacencia().getMatriz().Length));
            int[,] nueva,aux;

            if (tipo == DIRIGIDO && in_conect)
            {
                nueva = this.getMatrizAdyacencia().construirMatrizGrafoSubrayado();
                aux = this.getMatrizAdyacencia().construirMatrizGrafoSubrayado();
            }
            else
            {
                nueva = copiaMatriz(this.getMatrizAdyacencia().getMatriz(), n);
                aux = this.getMatrizAdyacencia().getMatriz();
            }

            for (int i = 0; i < (r-1); i++)
            {
                nueva = multiplicaMatrices(nueva,aux);
            }
            return nueva;
        }

        public bool existeCamino(CNodoVertice cnv1, CNodoVertice cnv2)
        {
            int n = Convert.ToInt32(Math.Sqrt((double)this.getMatrizAdyacencia().getMatriz().Length));
            int indx1 = lista_adyacencia.IndexOf(cnv1),indx2 = lista_adyacencia.IndexOf(cnv2),r=2;
            int[,] mat;
            bool band = false;

            if (tipo == DIRIGIDO)
                mat = this.getMatrizAdyacencia().construirMatrizGrafoSubrayado();
            else
                mat = copiaMatriz(this.getMatrizAdyacencia().getMatriz(), n);

            while (mat[indx1, indx2] == 0 && r <= num_aristas)
            {
                mat = getAr(r,true);
                r++;
            }

            if (mat[indx1, indx2] > 0)
                band = true;

            return band;
        }

        public bool estaConectado()
        {
            bool band = true;
            foreach (CNodoVertice cnv in lista_adyacencia)
            {
                foreach (CNodoVertice cnv2 in lista_adyacencia)
                {
                    if (cnv.getVertice().getId() != cnv2.getVertice().getId())
                    {
                        if (!existeCamino(cnv, cnv2))
                        {
                            band = false;
                            break;
                        }
                    }
                }
            }

            return band;
        }

        //Conteo de Caminos

        public int calculaCaminosREntre(CNodoVertice v1, CNodoVertice v2, int r)
        {
            int ncam = 0,indv1=lista_adyacencia.IndexOf(v1),indv2=lista_adyacencia.IndexOf(v2),n=num_vertices;
            int [,] mat = new int[n,n];

            mat = getAr(r, false);
            ncam = mat[indv1, indv2];
            return ncam;
        }

        //Planaridad
        public bool esPlanoPorCorolarios(ref string cad)
        {
            bool plano = false,bc1=false;
            string cad2 = "";

            if ((bc1=corolarioUno())&& corolarioDos(ref cad2))
                plano = true;

            if (bc1)
            {
                cad += "Cumple con el Corolario 1 : E <= 3V - 6.";
                cad += cad2;
            }
            else
                cad += "No cumple con el Corolario 1: E > 3V - 6!\n No continua con la verificación.";

            return plano;
        }
        
        public int[,] getAr2(int r)
        {
            int n = Convert.ToInt32(Math.Sqrt((double)this.getMatrizAdyacencia().getMatriz().Length));
            int[,] nueva, aux;
            nueva = copiaMatriz(this.getMatrizAdyacencia().getMatriz(), n);
            aux = this.getMatrizAdyacencia().getMatriz();

            for (int i = 0; i < (r-1); i++)
            {
                nueva = multiplicaMatrices(nueva, aux);
            }
            return nueva;
        }

        public bool corolarioUno()
        {
            bool band = false;
            int corolario = (3*num_vertices)-6;

            if (num_aristas <= corolario)
                band = true;

            return band;
        }

        public bool corolarioDos(ref string cad)
        {
            bool band = false;
            int corolario2 = (2*num_vertices)-4;

            if (num_vertices >= 3 && !hayCircuitosLong3())
            {
                cad += "\n Cumple con V >= 3 y NO existen circuitos de longitud 3.";
                if (num_aristas <= corolario2)
                {
                    cad += "\n Cumple con el Corolario 2 : E <= 2V  - 4.";
                    band = true;
                }
                else
                {
                    cad += "\n No cumple con el Corolario 2 : E > 2V  - 4!";
                    band = false;
                }
            }
            else
            {
                cad += "\n No cumple con V >= 3 o existen circuitos de longitud 3.\n No verifica el Corolario 2.";
                band = true;
            }

            return band;
        }

        public bool hayCircuitosLong3()
        {
            int n = Convert.ToInt32(Math.Sqrt((double)this.getMatrizAdyacencia().getMatriz().Length));
            int cont = 0;
            int[,] mat = getAr2(3);
            bool band = true;

            for (int i = 0; i < num_vertices; i++)
            {
                if (mat[i, i] == 0)
                    cont++;
            }

            if (cont == num_vertices)
                band = false;

            return band;
        }

        public bool esNoPlanoKuratowsky()
        {
            CKuratowsky ck = new CKuratowsky();
            if (!ck.esPlanoPorKuratowskyInteractivo(this))
            {
                MessageBox.Show(" El Grafo " + this.id.ToString() + " no puede ser plano porque es homeomórfico a K5 o K3,3! ",
                    "Evaluación del Teorema de Kuratowsky :", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }

            return false;
            /*else if (grafo_activo.esPlanoPorCorolarios())
            {
                MessageBox.Show(" El Grafo " + grafo_activo.getId().ToString() + " es plano porque NO es homeomórfico a K5 o K3,3! ",
                    "Evaluación del Teorema de Kuratowsky :", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }*/
        }


        //Setters y Getters
        public int getId()
        {
            return id;
        }

        public int getTipo()
        {
            return tipo;
        }

        public bool getPar()
        {
            return par;
        }

        public void setPar(bool p)
        {
            par = p;
        }

        public List<CNodoVertice> getListaAdyacencia()
        {
            return lista_adyacencia;
        }

        public int getNumeroAristas()
        {
            return num_aristas;
        }

        public int getNumeroVertices()
        {
            return num_vertices;
        }

        public void setNumeroAristas(int n)
        {
            num_aristas = n;
        }

        public void setNumeroVertices(int n)
        {
            num_vertices = n;
        }

        public Bitmap getBMP()
        {
            return bmp;
        }

        public List<CArista> getListaAristas()
        {
            return lista_aristas;
        }

        public CMatrizAdyacencia getMatrizAdyacencia()
        {
            if (lista_adyacencia.Count != 0)
            {
                ma = new CMatrizAdyacencia(lista_adyacencia.Count);
                ma.creaMatriz(lista_adyacencia);
            }

            return ma;
        }

        public CMatrizIncidencia getMatrizIncidencia()
        {
            if (lista_adyacencia.Count != 0 && lista_aristas.Count != 0)
            {
                mi = new CMatrizIncidencia(lista_adyacencia.Count,lista_aristas.Count);
                mi.creaMatriz(lista_adyacencia,lista_aristas);
            }

            return mi;
        }

        public void setPesos(List<int> pesos)
        {
            int cont = 0;
            foreach (CArista a in lista_aristas)
            {
                a.setPeso(pesos[cont]);
                cont++;
            }
        }

        public bool tienePeso()
        {
            foreach (CArista a in lista_aristas)
            {
                if (a.getPeso() > 0)
                    return true;
            }

            return false;
        }
        
    }
}
