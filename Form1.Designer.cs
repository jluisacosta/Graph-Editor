namespace Editor_de_Gafos
{
    partial class EditorGrafos
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorGrafos));
            this.BarraHerramientas = new System.Windows.Forms.ToolStrip();
            this.BarraMenus = new System.Windows.Forms.MenuStrip();
            this.NPGrafos = new System.Windows.Forms.ToolStripMenuItem();
            this.proyectoDeGrafosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarProyectoDeGrafosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirProyectoDeGrafosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.algoritmosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.isomorfismoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conteoDeCaminosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planaridadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.porCorolariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kuratowskyInteractivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coloreadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.digrafosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dijkstraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.floydToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.obtenerCentroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerraduraTransitivaWarshallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recorridoEnProfundidadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.componentesFuertesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grafosNoDirigidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.primToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kruskalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recorridoEnProfundidadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.recorridoEnAmplitudToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BNGrafo = new System.Windows.Forms.Button();
            this.BMVertice = new System.Windows.Forms.Button();
            this.BEVertice = new System.Windows.Forms.Button();
            this.BNVertice = new System.Windows.Forms.Button();
            this.BBorraGrafo = new System.Windows.Forms.Button();
            this.BMueveGrafo = new System.Windows.Forms.Button();
            this.BEGrafo = new System.Windows.Forms.Button();
            this.BNAristaD = new System.Windows.Forms.Button();
            this.BNAristaND = new System.Windows.Forms.Button();
            this.BEArista = new System.Windows.Forms.Button();
            this.Pestanas = new System.Windows.Forms.TabControl();
            this.BotonPG = new System.Windows.Forms.Button();
            this.KIHerramientas = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.KIContraccion = new System.Windows.Forms.ToolStripButton();
            this.KIEliminacion = new System.Windows.Forms.ToolStripButton();
            this.KISubdivision = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.KISalir = new System.Windows.Forms.ToolStripButton();
            this.BIdArista = new System.Windows.Forms.Button();
            this.BAddPeso = new System.Windows.Forms.Button();
            this.puntosDeArticulaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BarraMenus.SuspendLayout();
            this.KIHerramientas.SuspendLayout();
            this.SuspendLayout();
            // 
            // BarraHerramientas
            // 
            this.BarraHerramientas.AutoSize = false;
            this.BarraHerramientas.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.BarraHerramientas.Location = new System.Drawing.Point(0, 24);
            this.BarraHerramientas.Name = "BarraHerramientas";
            this.BarraHerramientas.Size = new System.Drawing.Size(892, 40);
            this.BarraHerramientas.TabIndex = 0;
            this.BarraHerramientas.Text = "toolStrip1";
            // 
            // BarraMenus
            // 
            this.BarraMenus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NPGrafos,
            this.algoritmosToolStripMenuItem});
            this.BarraMenus.Location = new System.Drawing.Point(0, 0);
            this.BarraMenus.Name = "BarraMenus";
            this.BarraMenus.Size = new System.Drawing.Size(892, 24);
            this.BarraMenus.TabIndex = 1;
            this.BarraMenus.Text = "menuStrip1";
            // 
            // NPGrafos
            // 
            this.NPGrafos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.proyectoDeGrafosToolStripMenuItem,
            this.guardarProyectoDeGrafosToolStripMenuItem,
            this.abrirProyectoDeGrafosToolStripMenuItem,
            this.MenuSalir});
            this.NPGrafos.Name = "NPGrafos";
            this.NPGrafos.Size = new System.Drawing.Size(55, 20);
            this.NPGrafos.Text = "&Archivo";
            // 
            // proyectoDeGrafosToolStripMenuItem
            // 
            this.proyectoDeGrafosToolStripMenuItem.Name = "proyectoDeGrafosToolStripMenuItem";
            this.proyectoDeGrafosToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.proyectoDeGrafosToolStripMenuItem.Text = "Nuevo...";
            this.proyectoDeGrafosToolStripMenuItem.Click += new System.EventHandler(this.proyectoDeGrafosToolStripMenuItem_Click);
            // 
            // guardarProyectoDeGrafosToolStripMenuItem
            // 
            this.guardarProyectoDeGrafosToolStripMenuItem.Name = "guardarProyectoDeGrafosToolStripMenuItem";
            this.guardarProyectoDeGrafosToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.guardarProyectoDeGrafosToolStripMenuItem.Text = "Guardar...";
            this.guardarProyectoDeGrafosToolStripMenuItem.Click += new System.EventHandler(this.guardarProyectoDeGrafosToolStripMenuItem_Click);
            // 
            // abrirProyectoDeGrafosToolStripMenuItem
            // 
            this.abrirProyectoDeGrafosToolStripMenuItem.Name = "abrirProyectoDeGrafosToolStripMenuItem";
            this.abrirProyectoDeGrafosToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.abrirProyectoDeGrafosToolStripMenuItem.Text = "Abrir...";
            this.abrirProyectoDeGrafosToolStripMenuItem.Click += new System.EventHandler(this.abrirProyectoDeGrafosToolStripMenuItem_Click);
            // 
            // MenuSalir
            // 
            this.MenuSalir.Name = "MenuSalir";
            this.MenuSalir.Size = new System.Drawing.Size(136, 22);
            this.MenuSalir.Text = "Salir";
            this.MenuSalir.Click += new System.EventHandler(this.MenuSalir_Click);
            // 
            // algoritmosToolStripMenuItem
            // 
            this.algoritmosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.isomorfismoToolStripMenuItem,
            this.conteoDeCaminosToolStripMenuItem,
            this.planaridadToolStripMenuItem,
            this.coloreadoToolStripMenuItem,
            this.digrafosToolStripMenuItem,
            this.grafosNoDirigidosToolStripMenuItem});
            this.algoritmosToolStripMenuItem.Name = "algoritmosToolStripMenuItem";
            this.algoritmosToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.algoritmosToolStripMenuItem.Text = "Algoritmos";
            // 
            // isomorfismoToolStripMenuItem
            // 
            this.isomorfismoToolStripMenuItem.Name = "isomorfismoToolStripMenuItem";
            this.isomorfismoToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.isomorfismoToolStripMenuItem.Text = "Isomorfismo";
            this.isomorfismoToolStripMenuItem.Click += new System.EventHandler(this.isomorfismoToolStripMenuItem_Click);
            // 
            // conteoDeCaminosToolStripMenuItem
            // 
            this.conteoDeCaminosToolStripMenuItem.Name = "conteoDeCaminosToolStripMenuItem";
            this.conteoDeCaminosToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.conteoDeCaminosToolStripMenuItem.Text = "Conteo de caminos";
            this.conteoDeCaminosToolStripMenuItem.Click += new System.EventHandler(this.conteoDeCaminosToolStripMenuItem_Click);
            // 
            // planaridadToolStripMenuItem
            // 
            this.planaridadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.porCorolariosToolStripMenuItem,
            this.kuratowskyInteractivoToolStripMenuItem});
            this.planaridadToolStripMenuItem.Name = "planaridadToolStripMenuItem";
            this.planaridadToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.planaridadToolStripMenuItem.Text = "Planaridad";
            // 
            // porCorolariosToolStripMenuItem
            // 
            this.porCorolariosToolStripMenuItem.Name = "porCorolariosToolStripMenuItem";
            this.porCorolariosToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.porCorolariosToolStripMenuItem.Text = "Por Corolarios";
            this.porCorolariosToolStripMenuItem.Click += new System.EventHandler(this.porCorolariosToolStripMenuItem_Click);
            // 
            // kuratowskyInteractivoToolStripMenuItem
            // 
            this.kuratowskyInteractivoToolStripMenuItem.Name = "kuratowskyInteractivoToolStripMenuItem";
            this.kuratowskyInteractivoToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.kuratowskyInteractivoToolStripMenuItem.Text = "Kuratowsky (Interactivo)";
            this.kuratowskyInteractivoToolStripMenuItem.Click += new System.EventHandler(this.kuratowskyInteractivoToolStripMenuItem_Click);
            // 
            // coloreadoToolStripMenuItem
            // 
            this.coloreadoToolStripMenuItem.Name = "coloreadoToolStripMenuItem";
            this.coloreadoToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.coloreadoToolStripMenuItem.Text = "Coloreado";
            this.coloreadoToolStripMenuItem.Click += new System.EventHandler(this.coloreadoToolStripMenuItem_Click);
            // 
            // digrafosToolStripMenuItem
            // 
            this.digrafosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dijkstraToolStripMenuItem,
            this.floydToolStripMenuItem,
            this.obtenerCentroToolStripMenuItem,
            this.cerraduraTransitivaWarshallToolStripMenuItem,
            this.recorridoEnProfundidadToolStripMenuItem,
            this.componentesFuertesToolStripMenuItem});
            this.digrafosToolStripMenuItem.Name = "digrafosToolStripMenuItem";
            this.digrafosToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.digrafosToolStripMenuItem.Text = "Digrafos";
            // 
            // dijkstraToolStripMenuItem
            // 
            this.dijkstraToolStripMenuItem.Name = "dijkstraToolStripMenuItem";
            this.dijkstraToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.dijkstraToolStripMenuItem.Text = "Dijkstra";
            this.dijkstraToolStripMenuItem.Click += new System.EventHandler(this.dijkstraToolStripMenuItem_Click);
            // 
            // floydToolStripMenuItem
            // 
            this.floydToolStripMenuItem.Name = "floydToolStripMenuItem";
            this.floydToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.floydToolStripMenuItem.Text = "Floyd";
            this.floydToolStripMenuItem.Click += new System.EventHandler(this.floydToolStripMenuItem_Click);
            // 
            // obtenerCentroToolStripMenuItem
            // 
            this.obtenerCentroToolStripMenuItem.Name = "obtenerCentroToolStripMenuItem";
            this.obtenerCentroToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.obtenerCentroToolStripMenuItem.Text = "Obtener Centro";
            this.obtenerCentroToolStripMenuItem.Click += new System.EventHandler(this.obtenerCentroToolStripMenuItem_Click);
            // 
            // cerraduraTransitivaWarshallToolStripMenuItem
            // 
            this.cerraduraTransitivaWarshallToolStripMenuItem.Name = "cerraduraTransitivaWarshallToolStripMenuItem";
            this.cerraduraTransitivaWarshallToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.cerraduraTransitivaWarshallToolStripMenuItem.Text = "Cerradura Transitiva (Warshall)";
            this.cerraduraTransitivaWarshallToolStripMenuItem.Click += new System.EventHandler(this.cerraduraTransitivaWarshallToolStripMenuItem_Click);
            // 
            // recorridoEnProfundidadToolStripMenuItem
            // 
            this.recorridoEnProfundidadToolStripMenuItem.Name = "recorridoEnProfundidadToolStripMenuItem";
            this.recorridoEnProfundidadToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.recorridoEnProfundidadToolStripMenuItem.Text = "Recorrido en profundidad";
            this.recorridoEnProfundidadToolStripMenuItem.Click += new System.EventHandler(this.recorridoEnProfundidadToolStripMenuItem_Click);
            // 
            // componentesFuertesToolStripMenuItem
            // 
            this.componentesFuertesToolStripMenuItem.Name = "componentesFuertesToolStripMenuItem";
            this.componentesFuertesToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.componentesFuertesToolStripMenuItem.Text = "Componentes Fuertes";
            this.componentesFuertesToolStripMenuItem.Click += new System.EventHandler(this.componentesFuertesToolStripMenuItem_Click);
            // 
            // grafosNoDirigidosToolStripMenuItem
            // 
            this.grafosNoDirigidosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.primToolStripMenuItem,
            this.kruskalToolStripMenuItem,
            this.recorridoEnProfundidadToolStripMenuItem1,
            this.recorridoEnAmplitudToolStripMenuItem,
            this.puntosDeArticulaciónToolStripMenuItem});
            this.grafosNoDirigidosToolStripMenuItem.Name = "grafosNoDirigidosToolStripMenuItem";
            this.grafosNoDirigidosToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.grafosNoDirigidosToolStripMenuItem.Text = "Grafos No Dirigidos";
            // 
            // primToolStripMenuItem
            // 
            this.primToolStripMenuItem.Name = "primToolStripMenuItem";
            this.primToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.primToolStripMenuItem.Text = "Prim";
            this.primToolStripMenuItem.Click += new System.EventHandler(this.primToolStripMenuItem_Click);
            // 
            // kruskalToolStripMenuItem
            // 
            this.kruskalToolStripMenuItem.Name = "kruskalToolStripMenuItem";
            this.kruskalToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.kruskalToolStripMenuItem.Text = "Kruskal";
            this.kruskalToolStripMenuItem.Click += new System.EventHandler(this.kruskalToolStripMenuItem_Click);
            // 
            // recorridoEnProfundidadToolStripMenuItem1
            // 
            this.recorridoEnProfundidadToolStripMenuItem1.Name = "recorridoEnProfundidadToolStripMenuItem1";
            this.recorridoEnProfundidadToolStripMenuItem1.Size = new System.Drawing.Size(207, 22);
            this.recorridoEnProfundidadToolStripMenuItem1.Text = "Recorrido en profundidad";
            this.recorridoEnProfundidadToolStripMenuItem1.Click += new System.EventHandler(this.recorridoEnProfundidadToolStripMenuItem1_Click);
            // 
            // recorridoEnAmplitudToolStripMenuItem
            // 
            this.recorridoEnAmplitudToolStripMenuItem.Name = "recorridoEnAmplitudToolStripMenuItem";
            this.recorridoEnAmplitudToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.recorridoEnAmplitudToolStripMenuItem.Text = "Recorrido en amplitud";
            this.recorridoEnAmplitudToolStripMenuItem.Click += new System.EventHandler(this.recorridoEnAmplitudToolStripMenuItem_Click);
            // 
            // BNGrafo
            // 
            this.BNGrafo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BNGrafo.BackgroundImage")));
            this.BNGrafo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BNGrafo.Location = new System.Drawing.Point(10, 25);
            this.BNGrafo.Name = "BNGrafo";
            this.BNGrafo.Size = new System.Drawing.Size(37, 37);
            this.BNGrafo.TabIndex = 2;
            this.BNGrafo.Tag = "NUEVO";
            this.BNGrafo.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.BNGrafo.UseVisualStyleBackColor = true;
            this.BNGrafo.Click += new System.EventHandler(this.BNGrafo_Click);
            // 
            // BMVertice
            // 
            this.BMVertice.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BMVertice.BackgroundImage")));
            this.BMVertice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BMVertice.Location = new System.Drawing.Point(290, 25);
            this.BMVertice.Name = "BMVertice";
            this.BMVertice.Size = new System.Drawing.Size(37, 37);
            this.BMVertice.TabIndex = 3;
            this.BMVertice.UseVisualStyleBackColor = true;
            this.BMVertice.Click += new System.EventHandler(this.BMVertice_Click);
            // 
            // BEVertice
            // 
            this.BEVertice.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BEVertice.BackgroundImage")));
            this.BEVertice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BEVertice.Location = new System.Drawing.Point(250, 25);
            this.BEVertice.Name = "BEVertice";
            this.BEVertice.Size = new System.Drawing.Size(37, 37);
            this.BEVertice.TabIndex = 4;
            this.BEVertice.UseVisualStyleBackColor = true;
            this.BEVertice.Click += new System.EventHandler(this.BEVertice_Click);
            // 
            // BNVertice
            // 
            this.BNVertice.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BNVertice.BackgroundImage")));
            this.BNVertice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BNVertice.Location = new System.Drawing.Point(210, 25);
            this.BNVertice.Name = "BNVertice";
            this.BNVertice.Size = new System.Drawing.Size(37, 37);
            this.BNVertice.TabIndex = 5;
            this.BNVertice.UseVisualStyleBackColor = true;
            this.BNVertice.Click += new System.EventHandler(this.BNVertice_Click);
            // 
            // BBorraGrafo
            // 
            this.BBorraGrafo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BBorraGrafo.BackgroundImage")));
            this.BBorraGrafo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BBorraGrafo.Location = new System.Drawing.Point(150, 25);
            this.BBorraGrafo.Name = "BBorraGrafo";
            this.BBorraGrafo.Size = new System.Drawing.Size(37, 37);
            this.BBorraGrafo.TabIndex = 6;
            this.BBorraGrafo.UseVisualStyleBackColor = true;
            this.BBorraGrafo.Click += new System.EventHandler(this.BBorraGrafo_Click);
            // 
            // BMueveGrafo
            // 
            this.BMueveGrafo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BMueveGrafo.BackgroundImage")));
            this.BMueveGrafo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BMueveGrafo.Location = new System.Drawing.Point(110, 25);
            this.BMueveGrafo.Name = "BMueveGrafo";
            this.BMueveGrafo.Size = new System.Drawing.Size(37, 37);
            this.BMueveGrafo.TabIndex = 7;
            this.BMueveGrafo.UseVisualStyleBackColor = true;
            // 
            // BEGrafo
            // 
            this.BEGrafo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BEGrafo.BackgroundImage")));
            this.BEGrafo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BEGrafo.Location = new System.Drawing.Point(50, 25);
            this.BEGrafo.Name = "BEGrafo";
            this.BEGrafo.Size = new System.Drawing.Size(37, 37);
            this.BEGrafo.TabIndex = 8;
            this.BEGrafo.UseVisualStyleBackColor = true;
            this.BEGrafo.Click += new System.EventHandler(this.BEGrafo_Click);
            // 
            // BNAristaD
            // 
            this.BNAristaD.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BNAristaD.BackgroundImage")));
            this.BNAristaD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BNAristaD.Location = new System.Drawing.Point(390, 25);
            this.BNAristaD.Name = "BNAristaD";
            this.BNAristaD.Size = new System.Drawing.Size(37, 37);
            this.BNAristaD.TabIndex = 9;
            this.BNAristaD.UseVisualStyleBackColor = true;
            this.BNAristaD.Click += new System.EventHandler(this.BNAristaD_Click);
            // 
            // BNAristaND
            // 
            this.BNAristaND.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BNAristaND.BackgroundImage")));
            this.BNAristaND.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BNAristaND.Location = new System.Drawing.Point(350, 25);
            this.BNAristaND.Name = "BNAristaND";
            this.BNAristaND.Size = new System.Drawing.Size(37, 37);
            this.BNAristaND.TabIndex = 10;
            this.BNAristaND.UseVisualStyleBackColor = true;
            this.BNAristaND.Click += new System.EventHandler(this.BNAristaND_Click);
            // 
            // BEArista
            // 
            this.BEArista.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BEArista.BackgroundImage")));
            this.BEArista.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BEArista.Location = new System.Drawing.Point(430, 25);
            this.BEArista.Name = "BEArista";
            this.BEArista.Size = new System.Drawing.Size(37, 37);
            this.BEArista.TabIndex = 11;
            this.BEArista.UseVisualStyleBackColor = true;
            this.BEArista.Click += new System.EventHandler(this.BEArista_Click);
            // 
            // Pestanas
            // 
            this.Pestanas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pestanas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pestanas.Location = new System.Drawing.Point(0, 64);
            this.Pestanas.Name = "Pestanas";
            this.Pestanas.SelectedIndex = 0;
            this.Pestanas.Size = new System.Drawing.Size(892, 452);
            this.Pestanas.TabIndex = 12;
            this.Pestanas.SelectedIndexChanged += new System.EventHandler(this.Pestanas_SelectedIndexChanged);
            // 
            // BotonPG
            // 
            this.BotonPG.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BotonPG.BackgroundImage")));
            this.BotonPG.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BotonPG.Location = new System.Drawing.Point(600, 25);
            this.BotonPG.Name = "BotonPG";
            this.BotonPG.Size = new System.Drawing.Size(37, 37);
            this.BotonPG.TabIndex = 13;
            this.BotonPG.UseVisualStyleBackColor = true;
            this.BotonPG.Click += new System.EventHandler(this.BotonPG_Click);
            // 
            // KIHerramientas
            // 
            this.KIHerramientas.AutoSize = false;
            this.KIHerramientas.Dock = System.Windows.Forms.DockStyle.None;
            this.KIHerramientas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripSeparator1,
            this.KIContraccion,
            this.KIEliminacion,
            this.KISubdivision,
            this.toolStripSeparator2,
            this.KISalir});
            this.KIHerramientas.Location = new System.Drawing.Point(1, 88);
            this.KIHerramientas.Name = "KIHerramientas";
            this.KIHerramientas.Size = new System.Drawing.Size(355, 40);
            this.KIHerramientas.TabIndex = 14;
            this.KIHerramientas.Text = "toolStrip1";
            this.KIHerramientas.Visible = false;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(160, 37);
            this.toolStripLabel1.Text = " Kuratowsky Interactivo ";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 40);
            // 
            // KIContraccion
            // 
            this.KIContraccion.AutoSize = false;
            this.KIContraccion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.KIContraccion.Image = ((System.Drawing.Image)(resources.GetObject("KIContraccion.Image")));
            this.KIContraccion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.KIContraccion.Name = "KIContraccion";
            this.KIContraccion.Size = new System.Drawing.Size(37, 37);
            this.KIContraccion.Text = "Contracción";
            this.KIContraccion.Click += new System.EventHandler(this.KIContraccion_Click);
            // 
            // KIEliminacion
            // 
            this.KIEliminacion.AutoSize = false;
            this.KIEliminacion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.KIEliminacion.Image = ((System.Drawing.Image)(resources.GetObject("KIEliminacion.Image")));
            this.KIEliminacion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.KIEliminacion.Name = "KIEliminacion";
            this.KIEliminacion.Size = new System.Drawing.Size(37, 37);
            this.KIEliminacion.Text = "Eliminación";
            this.KIEliminacion.Click += new System.EventHandler(this.KIEliminacion_Click);
            // 
            // KISubdivision
            // 
            this.KISubdivision.AutoSize = false;
            this.KISubdivision.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.KISubdivision.Image = ((System.Drawing.Image)(resources.GetObject("KISubdivision.Image")));
            this.KISubdivision.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.KISubdivision.Name = "KISubdivision";
            this.KISubdivision.Size = new System.Drawing.Size(37, 37);
            this.KISubdivision.Text = "Subdivisión";
            this.KISubdivision.Click += new System.EventHandler(this.KISubdivision_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 40);
            // 
            // KISalir
            // 
            this.KISalir.AutoSize = false;
            this.KISalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.KISalir.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.KISalir.Image = ((System.Drawing.Image)(resources.GetObject("KISalir.Image")));
            this.KISalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.KISalir.Name = "KISalir";
            this.KISalir.Size = new System.Drawing.Size(45, 37);
            this.KISalir.Text = "Salir";
            this.KISalir.Click += new System.EventHandler(this.KISalir_Click);
            // 
            // BIdArista
            // 
            this.BIdArista.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BIdArista.BackgroundImage")));
            this.BIdArista.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BIdArista.Location = new System.Drawing.Point(470, 25);
            this.BIdArista.Name = "BIdArista";
            this.BIdArista.Size = new System.Drawing.Size(37, 37);
            this.BIdArista.TabIndex = 15;
            this.BIdArista.UseVisualStyleBackColor = true;
            this.BIdArista.Click += new System.EventHandler(this.BIdArista_Click);
            // 
            // BAddPeso
            // 
            this.BAddPeso.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BAddPeso.BackgroundImage")));
            this.BAddPeso.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BAddPeso.Location = new System.Drawing.Point(510, 25);
            this.BAddPeso.Name = "BAddPeso";
            this.BAddPeso.Size = new System.Drawing.Size(37, 37);
            this.BAddPeso.TabIndex = 16;
            this.BAddPeso.UseVisualStyleBackColor = true;
            this.BAddPeso.Click += new System.EventHandler(this.BAddPeso_Click);
            // 
            // puntosDeArticulaciónToolStripMenuItem
            // 
            this.puntosDeArticulaciónToolStripMenuItem.Name = "puntosDeArticulaciónToolStripMenuItem";
            this.puntosDeArticulaciónToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.puntosDeArticulaciónToolStripMenuItem.Text = "Puntos de articulación";
            this.puntosDeArticulaciónToolStripMenuItem.Click += new System.EventHandler(this.puntosDeArticulaciónToolStripMenuItem_Click);
            // 
            // EditorGrafos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 516);
            this.Controls.Add(this.BAddPeso);
            this.Controls.Add(this.BIdArista);
            this.Controls.Add(this.KIHerramientas);
            this.Controls.Add(this.BotonPG);
            this.Controls.Add(this.Pestanas);
            this.Controls.Add(this.BEArista);
            this.Controls.Add(this.BNAristaND);
            this.Controls.Add(this.BNAristaD);
            this.Controls.Add(this.BEGrafo);
            this.Controls.Add(this.BMueveGrafo);
            this.Controls.Add(this.BBorraGrafo);
            this.Controls.Add(this.BNVertice);
            this.Controls.Add(this.BEVertice);
            this.Controls.Add(this.BMVertice);
            this.Controls.Add(this.BNGrafo);
            this.Controls.Add(this.BarraHerramientas);
            this.Controls.Add(this.BarraMenus);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.BarraMenus;
            this.Name = "EditorGrafos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editor de Grafos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditorGrafos_FormClosing);
            this.BarraMenus.ResumeLayout(false);
            this.BarraMenus.PerformLayout();
            this.KIHerramientas.ResumeLayout(false);
            this.KIHerramientas.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip BarraHerramientas;
        private System.Windows.Forms.MenuStrip BarraMenus;
        private System.Windows.Forms.Button BNGrafo;
        private System.Windows.Forms.Button BMVertice;
        private System.Windows.Forms.Button BEVertice;
        private System.Windows.Forms.Button BNVertice;
        private System.Windows.Forms.Button BBorraGrafo;
        private System.Windows.Forms.Button BMueveGrafo;
        private System.Windows.Forms.Button BEGrafo;
        private System.Windows.Forms.Button BNAristaD;
        private System.Windows.Forms.Button BNAristaND;
        private System.Windows.Forms.Button BEArista;
        private System.Windows.Forms.ToolStripMenuItem NPGrafos;
        private System.Windows.Forms.ToolStripMenuItem proyectoDeGrafosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirProyectoDeGrafosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuSalir;
        private System.Windows.Forms.TabControl Pestanas;
        private System.Windows.Forms.ToolStripMenuItem guardarProyectoDeGrafosToolStripMenuItem;
        private System.Windows.Forms.Button BotonPG;
        private System.Windows.Forms.ToolStripMenuItem algoritmosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem isomorfismoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem planaridadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem porCorolariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kuratowskyInteractivoToolStripMenuItem;
        private System.Windows.Forms.ToolStrip KIHerramientas;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton KIContraccion;
        private System.Windows.Forms.ToolStripButton KIEliminacion;
        private System.Windows.Forms.ToolStripButton KISubdivision;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton KISalir;
        private System.Windows.Forms.ToolStripMenuItem coloreadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conteoDeCaminosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem digrafosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dijkstraToolStripMenuItem;
        private System.Windows.Forms.Button BIdArista;
        private System.Windows.Forms.ToolStripMenuItem floydToolStripMenuItem;
        private System.Windows.Forms.Button BAddPeso;
        private System.Windows.Forms.ToolStripMenuItem obtenerCentroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerraduraTransitivaWarshallToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recorridoEnProfundidadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem componentesFuertesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grafosNoDirigidosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem primToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kruskalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recorridoEnProfundidadToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem recorridoEnAmplitudToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem puntosDeArticulaciónToolStripMenuItem;
    }
}

