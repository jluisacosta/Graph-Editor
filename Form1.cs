using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Editor_de_Gafos
{
    public partial class EditorGrafos : Form
    {
        private int num_graf = 0;           //Numero de grafos del proyecto
        private int Opmenu = 0;             //Opcion actual del menu
        private CGrafo grafo_activo;        //Referencia al grafo activo
        private List<CGrafo> grafos;        //Lista de grafos existentes
        private bool proyecto;              //Bandera que indica si hay un proyecto abierto
        private string nom_proyecto;        //Nombre del proyecto (Localizacion)
        private bool idar;
        public const int NO_DIRIGIDO = 0, DIRIGIDO = 1, MOV_GRAFO = 1, BORRA_GRAFO = 2, ADD_VERT = 3, REM_VERT = 4, MOV_VERT = 5, ADD_ARIND = 6, ADD_ARID = 7, REM_ARI = 8, CONTRACCION = 11, ELIMINACION = 12, SUBDIVISION = 13;

        //Constructor
        public EditorGrafos()
        {
            InitializeComponent();
            proyecto = false;
            nom_proyecto = null;
            idar = false;
        }

        //Menu Archivo
        private void proyectoDeGrafosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sd = new SaveFileDialog();

            sd.AddExtension = true;
            sd.DefaultExt = ".grf";
            sd.Title = "Nuevo Proyecto de Grafos";
            sd.OverwritePrompt = true;
            sd.Filter = "Proyecto de Grafos (*.grf)|*.grf";
            sd.FilterIndex = 1;
            sd.ValidateNames = true;

            if (sd.ShowDialog() == DialogResult.OK)
            {
                cierraProyecto();
                FileInfo file = new FileInfo(sd.FileName);
                nom_proyecto = sd.FileName;
                string fileNameOnly = file.Name;
                this.Text = fileNameOnly;
                Stream stream = new FileStream(sd.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
                stream.Close();
                proyecto = true;
                grafos = new List<CGrafo>();
                if (grafo_activo != null)
                    grafo_activo = null;
            }
        }

        private void guardarProyectoDeGrafosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (proyecto && grafos != null)
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(nom_proyecto, FileMode.Open, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, grafos);
                stream.Close();
            }
        }
        
        private void abrirProyectoDeGrafosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            od.DefaultExt = ".grf";
            od.Title = "Abrir Proyecto de Grafos";
            od.Filter = "Proyecto de Grafos (*.grf)|*.grf";
            od.CheckFileExists = true;

            if (od.ShowDialog() == DialogResult.OK)
            {
                cierraProyecto();
                FileInfo file = new FileInfo(od.FileName);
                string fileNameOnly = file.Name;
                this.Text = fileNameOnly;
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(od.FileName, FileMode.Open, FileAccess.Read, FileShare.None);
                if (stream.Length != 0)
                {
                    grafos = (List<CGrafo>)formatter.Deserialize(stream);
                    if (grafos.Count != 0)
                    {
                        grafo_activo = grafos[0];
                        SetBotonesAristas(grafo_activo.getTipo());
                    }
                }
                else
                    grafos = new List<CGrafo>();
                
                stream.Close();
                num_graf = grafos.Count;
                nom_proyecto = od.FileName;
                proyecto = true;
                Opmenu = 0;
                cargaTabPage();
            }
            
        }
        
        private void MenuSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //MENU ALGORITMOS
        private void isomorfismoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grafos != null)
            {
                if(grafos.Count >= 2)
                {
                    DIso di = new DIso(grafos.Count);
                    if (di.ShowDialog() == DialogResult.OK)
                    {
                        CIsomorfismo ci = new CIsomorfismo(grafos[(di.ng) - 1], grafos[(di.nh) - 1]);
                        CIsomorfismo ce = new CIsomorfismo(grafos[(di.nh) - 1], grafos[(di.ng) - 1]);
                        if (ci.sonIsomorficos() || ce.sonIsomorficos())
                            MessageBox.Show(" SI son isomorficos!! ","Resultado de la evalución :",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        else
                            MessageBox.Show(" NO son isomorficos!! ", "Resultado de la evalución :", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                else
                    MessageBox.Show(" Deben existir por lo menos 2 grafos en el proyecto! ", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void conteoDeCaminosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grafos != null && grafo_activo != null)
            {
                if (grafo_activo.getNumeroVertices() >= 2)
                {
                    DConteo dc = new DConteo(grafo_activo.getNumeroVertices());
                    if (dc.ShowDialog() == DialogResult.OK)
                    {
                        CNodoVertice cnv1 = grafo_activo.getListaAdyacencia()[(dc.na)-1], cnv2 = grafo_activo.getListaAdyacencia()[(dc.nb)-1];
                        int num_cam = grafo_activo.calculaCaminosREntre(cnv1, cnv2, dc.r),ncam = dc.r;
                        if(cnv1.getVertice().getId() != cnv2.getVertice().getId())
                            MessageBox.Show(" Existen " + num_cam.ToString() + " caminos de longitud "+ncam.ToString()+" entre el vértice " + cnv1.getVertice().getId().ToString() + " al vértice " + cnv2.getVertice().getId().ToString()+"  ", "Conteo de caminos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show(" Existen " + num_cam.ToString() + " circuitos de longitud " +ncam.ToString()+" para el vértice " + cnv1.getVertice().getId().ToString()+"  ", "Conteo de circuitos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    MessageBox.Show(" Deben existir por lo menos 2 vertices en el grafo! ", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void coloreadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grafos != null && grafos.Count != 0)
            {
                if (grafo_activo != null && grafo_activo.getNumeroVertices()!=0)
                {
                    CColoreado c = new CColoreado(grafo_activo);
                    c.coloreoDeGrafo4Colores((TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                    MessageBox.Show(" Número Cromático : " + c.getNC().ToString() + " colores.  ","Coloreado",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    c.regresaAEstadoOriginal();
                    grafo_activo.dibujate((TabPage)Pestanas.Controls[Pestanas.SelectedIndex], grafo_activo.getBMP());
                }
            }
        }

        //Submenu Planaridad
        private void porCorolariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grafos != null && grafos.Count != 0)
            {
                if (grafo_activo != null && grafo_activo.getNumeroVertices() >= 2 && grafo_activo.getNumeroAristas()!=0)
                {
                    string cad = "\n\n ";
                    if (grafo_activo.esPlanoPorCorolarios(ref cad))
                        MessageBox.Show("\n El Grafo "+grafo_activo.getId().ToString()+" es PLANO. "+cad, " Planaridad por corolarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("\n El Grafo " + grafo_activo.getId().ToString() + " NO es PLANO. "+cad, " Planaridad por corolarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void kuratowskyInteractivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grafos != null && grafos.Count != 0)
            {
                if (grafo_activo != null && grafo_activo.getNumeroVertices() >= 2 && grafo_activo.getNumeroAristas() != 0)
                {
                    if (!grafo_activo.esNoPlanoKuratowsky())
                    {
                        setBarraDeHerramientas(false);
                        KIHerramientas.Visible = true;
                    }
                }
            }
        }

        private void KIContraccion_Click(object sender, EventArgs e)
        {
            if (grafo_activo != null)
            {
                grafos[Pestanas.SelectedIndex].op = Opmenu = CONTRACCION;
            }
        }

        private void KIEliminacion_Click(object sender, EventArgs e)
        {
            if (grafo_activo != null)
            {
                grafos[Pestanas.SelectedIndex].op = Opmenu = ELIMINACION;
            }
        }

        private void KISubdivision_Click(object sender, EventArgs e)
        {
            if (grafo_activo != null)
            {
                grafos[Pestanas.SelectedIndex].op = Opmenu = SUBDIVISION;
            }
        }

        private void KISalir_Click(object sender, EventArgs e)
        {
            setBarraDeHerramientas(true);
            KIHerramientas.Visible = false;
            SetBotonesAristas(grafo_activo.getTipo());
        }

        //Submenu Algoritmos para Digrafos
        private void dijkstraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grafos != null && grafo_activo != null && grafo_activo.getTipo() == DIRIGIDO && grafo_activo.getNumeroAristas() > 0)
            {
                if (!grafo_activo.tienePeso())
                {
                    DAddPeso dap = new DAddPeso(grafo_activo.getListaAristas());
                    grafo_activo.showHideIdAristas(true, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                    if (dap.ShowDialog() == DialogResult.OK)
                    {
                        grafo_activo.setPesos(dap.getPesos());
                        grafo_activo.showHideIdAristas(false, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                        grafo_activo.showHidePesos(true, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                        DPideVert pdv = new DPideVert(grafo_activo.getNumeroVertices());
                        if (pdv.ShowDialog() == DialogResult.OK)
                        {
                            CDijkstra djk = new CDijkstra(grafo_activo);
                            djk.calculaCaminoMasCorto(grafo_activo.buscaNodoVertice(pdv.getIdVert()));
                            grafo_activo.showHidePesos(false, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                            /*foreach (CArista a in grafo_activo.getListaAristas())
                                a.setPeso(0);*/
                        }
                    }
                    else
                        grafo_activo.showHideIdAristas(false, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                }
                else
                {
                    grafo_activo.showHidePesos(true, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                    DPideVert pdv = new DPideVert(grafo_activo.getNumeroVertices());
                    if (pdv.ShowDialog() == DialogResult.OK)
                    {
                        CDijkstra djk = new CDijkstra(grafo_activo);
                        djk.calculaCaminoMasCorto(grafo_activo.buscaNodoVertice(pdv.getIdVert()));
                        grafo_activo.showHidePesos(false, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                        /*foreach (CArista a in grafo_activo.getListaAristas())
                            a.setPeso(0);*/
                    }
                }
            }
        }

        private void floydToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grafos != null && grafo_activo != null && grafo_activo.getTipo() == DIRIGIDO && grafo_activo.getNumeroAristas() > 0)
            {
                if (!grafo_activo.tienePeso())
                {
                    DAddPeso dap = new DAddPeso(grafo_activo.getListaAristas());
                    grafo_activo.showHideIdAristas(true, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                    if (dap.ShowDialog() == DialogResult.OK)
                    {
                        grafo_activo.setPesos(dap.getPesos());
                        grafo_activo.showHideIdAristas(false, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                        grafo_activo.showHidePesos(true, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                        CFloyd cf = new CFloyd(grafo_activo);
                        cf.Floyd();
                        cf.muestraResultado();
                        grafo_activo.showHidePesos(false, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                    }
                    else
                        grafo_activo.showHideIdAristas(false, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                }
                else
                {
                    grafo_activo.showHidePesos(true, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                    CFloyd cf = new CFloyd(grafo_activo);
                    cf.Floyd();
                    cf.muestraResultado();
                    grafo_activo.showHidePesos(false, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                }
            }
        }

        private void obtenerCentroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grafos != null && grafo_activo != null && grafo_activo.getTipo() == DIRIGIDO && grafo_activo.getNumeroAristas() > 0)
            {
                if (!grafo_activo.tienePeso())
                {
                    DAddPeso dap = new DAddPeso(grafo_activo.getListaAristas());
                    grafo_activo.showHideIdAristas(true, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                    if (dap.ShowDialog() == DialogResult.OK)
                    {
                        grafo_activo.setPesos(dap.getPesos());
                        grafo_activo.showHideIdAristas(false, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                        grafo_activo.showHidePesos(true, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                        CFloyd cf = new CFloyd(grafo_activo);
                        cf.Floyd();
                        CVertice centro = cf.dameCentro().getVertice();
                        centro.setRelleno(Color.SpringGreen.ToArgb());
                        centro.dibujate(Graphics.FromImage(grafo_activo.getBMP()), grafo_activo.getBMP(), (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                        MessageBox.Show(" Vértice Central : " + centro.getId().ToString() + ".     ", "Centro del Grafo " + grafo_activo.getId().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        centro.borrate(Graphics.FromImage(grafo_activo.getBMP()), grafo_activo.getBMP(), (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                        centro.setRelleno(Color.LightGoldenrodYellow.ToArgb());
                        centro.dibujate(Graphics.FromImage(grafo_activo.getBMP()), grafo_activo.getBMP(), (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                        grafo_activo.showHidePesos(false, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                    }
                    else
                        grafo_activo.showHideIdAristas(false, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                }
                else
                {
                    grafo_activo.showHidePesos(true, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                    CFloyd cf = new CFloyd(grafo_activo);
                    cf.Floyd();
                    CVertice centro = cf.dameCentro().getVertice();
                    centro.setRelleno(Color.SpringGreen.ToArgb());
                    centro.dibujate(Graphics.FromImage(grafo_activo.getBMP()), grafo_activo.getBMP(), (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                    MessageBox.Show(" Vértice Central : " + centro.getId().ToString() + ".     ", "Centro del Grafo " + grafo_activo.getId().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    centro.borrate(Graphics.FromImage(grafo_activo.getBMP()), grafo_activo.getBMP(), (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                    centro.setRelleno(Color.LightGoldenrodYellow.ToArgb());
                    centro.dibujate(Graphics.FromImage(grafo_activo.getBMP()), grafo_activo.getBMP(), (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                    grafo_activo.showHidePesos(false, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                }
            }
        }

        private void cerraduraTransitivaWarshallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grafos != null && grafo_activo != null && grafo_activo.getTipo() == DIRIGIDO && grafo_activo.getNumeroAristas() > 0)
            {
                if (!grafo_activo.tienePeso())
                {
                    DAddPeso dap = new DAddPeso(grafo_activo.getListaAristas());
                    grafo_activo.showHideIdAristas(true, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                    if (dap.ShowDialog() == DialogResult.OK)
                    {
                        grafo_activo.setPesos(dap.getPesos());
                        grafo_activo.showHideIdAristas(false, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                        grafo_activo.showHidePesos(true, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                        CWarshall cw = new CWarshall(grafo_activo);
                        string cad = "";
                        if (cw.tieneCerraduraTransitiva())
                            cad = " SI";
                        else
                            cad = " NO";

                        MessageBox.Show(cad +" existe cerradura transitiva para el grafo " + grafo_activo.getId().ToString() + "!!     ", "Algoritmo de Warshall", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        grafo_activo.showHidePesos(false, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                    }
                    else
                        grafo_activo.showHideIdAristas(false, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                }
                else
                {
                    grafo_activo.showHidePesos(true, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                    CWarshall cw = new CWarshall(grafo_activo);
                    string cad = "";
                    if (cw.tieneCerraduraTransitiva())
                        cad = " SI";
                    else
                        cad = " NO";

                    MessageBox.Show(cad+" existe cerradura transitiva para el grafo " + grafo_activo.getId().ToString() + "!!     ", "Algoritmo de Warshall", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    grafo_activo.showHidePesos(false, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                }
            }
        }

        private void recorridoEnProfundidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grafos != null && grafo_activo != null && grafo_activo.getNumeroAristas() > 0)
            {
                DPideVert pv = new DPideVert(grafo_activo.getNumeroVertices());
                pv.setTituloVentana("Recorrido en Profundidad");
                pv.setLabelVertice("Vértice Inicial : ");
                if (pv.ShowDialog() == DialogResult.OK)
                {
                    if (grafo_activo.existeVerticeConId(pv.getIdVert()))
                    {
                        CRecorridoP rp = new CRecorridoP(grafo_activo, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                        rp.RecorridoEnProfundidad(grafo_activo.buscaNodoVertice(pv.getIdVert()));
                        rp.aplicaArbolAbarcador(grafo_activo.getTipo(),false);
                        grafo_activo.borraRP();
                    }
                    else
                        MessageBox.Show(" El vértice especificado no existe!! ");
                }
            }
        }

        private void componentesFuertesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grafos != null && grafo_activo != null && grafo_activo.getTipo() == DIRIGIDO && grafo_activo.getNumeroAristas() > 0)
            {
                CRecorridoP rp = new CRecorridoP(grafo_activo, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                rp.obtenerComponentesFuertes();
                grafo_activo.borraRP();
            }
        }
        
        //Algoritmos para grafos No Dirigidos
        private void primToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grafos != null && grafo_activo != null && grafo_activo.getTipo() == NO_DIRIGIDO && grafo_activo.getNumeroAristas() > 0)
            {
                if (!grafo_activo.tienePeso())
                {
                    DAddPeso dap = new DAddPeso(grafo_activo.getListaAristas());
                    grafo_activo.showHideIdAristas(true, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                    if (dap.ShowDialog() == DialogResult.OK)
                    {
                        grafo_activo.setPesos(dap.getPesos());
                        grafo_activo.showHideIdAristas(false, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                        grafo_activo.showHidePesos(true, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                        CPrim cpr = new CPrim(grafo_activo, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                        cpr.prim();
                        grafo_activo.showHidePesos(false, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                    }
                    else
                        grafo_activo.showHideIdAristas(false, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                }
                else
                {
                    grafo_activo.showHidePesos(true, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                    CPrim cpr = new CPrim(grafo_activo, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                    cpr.prim();
                    grafo_activo.showHidePesos(false, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                }
            }
        }
        
        private void kruskalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grafos != null && grafo_activo != null && grafo_activo.getTipo() == NO_DIRIGIDO && grafo_activo.getNumeroAristas() > 0)
            {
                if (!grafo_activo.tienePeso())
                {
                    DAddPeso dap = new DAddPeso(grafo_activo.getListaAristas());
                    grafo_activo.showHideIdAristas(true, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                    if (dap.ShowDialog() == DialogResult.OK)
                    {
                        grafo_activo.setPesos(dap.getPesos());
                        grafo_activo.showHideIdAristas(false, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                        grafo_activo.showHidePesos(true, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                        CKruskal k = new CKruskal(grafo_activo, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                        k.kruskal();
                        grafo_activo.showHidePesos(false, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                    }
                    else
                        grafo_activo.showHideIdAristas(false, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                }
                else
                {
                    grafo_activo.showHidePesos(true, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                    CKruskal k = new CKruskal(grafo_activo, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                    k.kruskal();
                    grafo_activo.showHidePesos(false, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                }
            }
        }

        private void recorridoEnProfundidadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            recorridoEnProfundidadToolStripMenuItem_Click(sender, e);
        }

        private void recorridoEnAmplitudToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grafos != null && grafo_activo != null && grafo_activo.getNumeroAristas() > 0)
            {
                DPideVert pv = new DPideVert(grafo_activo.getNumeroVertices());
                pv.setTituloVentana("Recorrido en Profundidad");
                pv.setLabelVertice("Vértice Inicial : ");
                if (pv.ShowDialog() == DialogResult.OK)
                {
                    if (grafo_activo.existeVerticeConId(pv.getIdVert()))
                    {
                        CRecorridoP rp = new CRecorridoP(grafo_activo, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                        rp.recorridoEnAmplitud(grafo_activo.buscaNodoVertice(pv.getIdVert()));
                        rp.aplicaArbolAbarcador(grafo_activo.getTipo(), true);
                        grafo_activo.borraRP();
                    }
                    else
                        MessageBox.Show(" El vértice especificado no existe!! ");
                }
            }
        }

        private void puntosDeArticulaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grafos != null && grafo_activo != null && grafo_activo.getNumeroAristas() > 0)
            {
                DPideVert pv = new DPideVert(grafo_activo.getNumeroVertices());
                pv.setTituloVentana("Puntos de articulación");
                pv.setLabelVertice("Vértice Inicial : ");
                if (pv.ShowDialog() == DialogResult.OK)
                {
                    if (grafo_activo.existeVerticeConId(pv.getIdVert()))
                    {
                        CRecorridoP rp = new CRecorridoP(grafo_activo, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                        CNodoVertice cnv = grafo_activo.buscaNodoVertice(pv.getIdVert());
                        rp.RecorridoEnProfundidad(cnv);
                        rp.aplicaArbolAbarcador(grafo_activo.getTipo(), false);
                        rp.RecorridoEnProfundidadPtosArticulacion(cnv);
                        rp.sacaPuntosDeArticulacion(cnv);
                        grafo_activo.borraRP();
                    }
                    else
                        MessageBox.Show(" El vértice especificado no existe!! ");
                }
            }
        }


        //Botones de operacion
        private void BNGrafo_Click(object sender, EventArgs e)
        {
            if (proyecto)
            {
                CGrafo grafo_nvo = new CGrafo(Pestanas, ++num_graf, -1);
                grafos.Add(grafo_nvo);
                if (grafos.Count == 1)
                    grafo_activo = grafos[0];
            }
        }
        
        private void BEGrafo_Click(object sender, EventArgs e)
        {
            if (proyecto && Pestanas.SelectedIndex != -1)
            {
                int elimpos = Pestanas.SelectedIndex;
                if (MessageBox.Show(" Esta seguro que desea eliminar el " + Pestanas.Controls[elimpos].Text + "? "
                    , "Elimina Grafo", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.OK)
                {

                    Pestanas.Controls.RemoveAt(elimpos);
                    grafos.RemoveAt(elimpos);
                }
            }
        }

        private void BNVertice_Click(object sender, EventArgs e)
        {
            if (grafo_activo != null)
            {
                grafos[Pestanas.SelectedIndex].op = Opmenu = ADD_VERT;
            }
        }

        private void BEVertice_Click(object sender, EventArgs e)
        {
            if (grafo_activo != null)
            {
                grafos[Pestanas.SelectedIndex].op = Opmenu = REM_VERT;
            }
        }
        
        private void BMVertice_Click(object sender, EventArgs e)
        {
            if (grafo_activo != null)
            {
                grafos[Pestanas.SelectedIndex].op = Opmenu = MOV_VERT;
            }
        }
        
        private void BNAristaND_Click(object sender, EventArgs e)
        {
            if (grafo_activo != null)
            {
                grafos[Pestanas.SelectedIndex].op = Opmenu = ADD_ARIND;
                grafos[Pestanas.SelectedIndex].primer_arista = NO_DIRIGIDO;
                Pestanas.Controls[Pestanas.SelectedIndex].MouseUp += new MouseEventHandler(EditorGrafos_MouseUp);
            }
        }

        private void BNAristaD_Click(object sender, EventArgs e)
        {
            if (grafo_activo != null)
            {
                grafos[Pestanas.SelectedIndex].op = Opmenu = ADD_ARID;
                grafos[Pestanas.SelectedIndex].primer_arista = DIRIGIDO;
                Pestanas.Controls[Pestanas.SelectedIndex].MouseUp += new MouseEventHandler(EditorGrafos_MouseUp);
            }
        }
        
        private void BEArista_Click(object sender, EventArgs e)
        {
            if (grafo_activo != null)
            {
                grafos[Pestanas.SelectedIndex].op = Opmenu = REM_ARI;
            }
        }

        private void BotonPG_Click(object sender, EventArgs e)
        {
            if (grafo_activo != null)
            {
                Propiedades p = new Propiedades(grafo_activo.getListaAdyacencia(), grafo_activo.getListaAristas(),grafo_activo.getMatrizAdyacencia(),
                                grafo_activo.getMatrizIncidencia(),grafo_activo.getNumeroAristas(),grafo_activo.getNumeroVertices());
                p.ShowDialog();
            }
        }

        private void BBorraGrafo_Click(object sender, EventArgs e)
        {
            if (grafo_activo != null)
            {
                grafo_activo.getListaAdyacencia().Clear();
                grafo_activo.getListaAristas().Clear();
                grafo_activo.setNumeroAristas(0);
                grafo_activo.setNumeroVertices(0);
                grafo_activo.borrate((TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
            }
        }

        private void BIdArista_Click(object sender, EventArgs e)
        {
            if (grafo_activo != null && grafo_activo.getNumeroAristas() >0)
            {
                if (!idar)
                {
                    grafo_activo.showHideIdAristas(true, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                    idar = true;
                }
                else
                {
                    grafo_activo.showHideIdAristas(false, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                    idar = false;
                }
                setBarraDeHerramientas(!idar);
            }
        }

        private void BAddPeso_Click(object sender, EventArgs e)
        {
            if (grafos != null && grafo_activo != null && grafo_activo.getNumeroAristas() > 0)
            {
                DAddPeso dap = new DAddPeso(grafo_activo.getListaAristas());
                grafo_activo.showHideIdAristas(true, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                if (dap.ShowDialog() == DialogResult.OK)
                {
                    grafo_activo.setPesos(dap.getPesos());
                    grafo_activo.showHideIdAristas(false, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                    grafo_activo.showHidePesos(true, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
                }
                else
                    grafo_activo.showHideIdAristas(false, (TabPage)Pestanas.Controls[Pestanas.SelectedIndex]);
            }
        }


        //Manejadores del Form principal
        void EditorGrafos_MouseUp(object sender, MouseEventArgs e)
        {
            if (grafo_activo != null && grafo_activo.getListaAristas().Count == 1 && e.Button == MouseButtons.Left)
            {
                SetBotonesAristas(grafo_activo.getTipo());
            }
        }

        private void EditorGrafos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (proyecto && MessageBox.Show(" Desea guardar los cambios en el proyecto? ", "Cerrando " + this.Text + " ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                guardarProyectoDeGrafosToolStripMenuItem_Click(sender, e);
            }
        }
        
        private void Pestanas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (grafos != null && grafos.Count != 0 && Pestanas.SelectedIndex != -1)
            {
                grafo_activo = grafos[Pestanas.SelectedIndex];
                grafo_activo.op = Opmenu;
                SetBotonesAristas(grafo_activo.getTipo());
            }
        }


        //Metodos funcionales
        public void cierraProyecto()
        {
            if (grafos != null)
            {
                num_graf = 0;
                Pestanas.Controls.Clear();
                grafos.Clear();
                grafos = null;
            }
        }

        public void cargaTabPage()
        {
            if (grafos != null && grafos.Count != 0)
            {
                for(int i = 0; i< grafos.Count ;i++)
                {
                    grafos[i] = new CGrafo(Pestanas,grafos[i].getId(),grafos[i].getTipo(),grafos[i].getListaAdyacencia(),
                                grafos[i].getListaAristas(),grafos[i].getNumeroAristas(),grafos[i].getNumeroVertices());
                }
            }
        }

        public void SetBotonesAristas(int tipoGrafo)
        {
            if (tipoGrafo == DIRIGIDO)
            {
                BNAristaND.Enabled = false;
                BNAristaD.Enabled = true;
            }
            else if (tipoGrafo == NO_DIRIGIDO)
            {
                BNAristaD.Enabled = false;
                BNAristaND.Enabled = true;
            }
            else
            {
                BNAristaD.Enabled = true;
                BNAristaND.Enabled = true;
            }
        }

        public void setBarraDeHerramientas(bool status)
        {
            BNGrafo.Enabled = BEGrafo.Enabled = BMueveGrafo.Enabled = BBorraGrafo.Enabled =
            BNVertice.Enabled = BEVertice.Enabled = BMVertice.Enabled = BNAristaND.Enabled =
            BNAristaD.Enabled = BEArista.Enabled = BotonPG.Enabled = status;
        }
    }
}