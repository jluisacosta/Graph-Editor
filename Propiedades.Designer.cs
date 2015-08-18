namespace Editor_de_Gafos
{
    partial class Propiedades
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
            this.DGMatrizI = new System.Windows.Forms.DataGridView();
            this.DGMatrizA = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NAristasLabel = new System.Windows.Forms.Label();
            this.NVerticesLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGMatrizI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGMatrizA)).BeginInit();
            this.SuspendLayout();
            // 
            // DGMatrizI
            // 
            this.DGMatrizI.AllowUserToAddRows = false;
            this.DGMatrizI.AllowUserToDeleteRows = false;
            this.DGMatrizI.AllowUserToResizeColumns = false;
            this.DGMatrizI.AllowUserToResizeRows = false;
            this.DGMatrizI.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGMatrizI.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGMatrizI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGMatrizI.Location = new System.Drawing.Point(313, 54);
            this.DGMatrizI.Name = "DGMatrizI";
            this.DGMatrizI.ReadOnly = true;
            this.DGMatrizI.RowHeadersVisible = false;
            this.DGMatrizI.Size = new System.Drawing.Size(200, 200);
            this.DGMatrizI.TabIndex = 1;
            // 
            // DGMatrizA
            // 
            this.DGMatrizA.AllowUserToAddRows = false;
            this.DGMatrizA.AllowUserToDeleteRows = false;
            this.DGMatrizA.AllowUserToResizeColumns = false;
            this.DGMatrizA.AllowUserToResizeRows = false;
            this.DGMatrizA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGMatrizA.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGMatrizA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGMatrizA.Location = new System.Drawing.Point(50, 54);
            this.DGMatrizA.Name = "DGMatrizA";
            this.DGMatrizA.ReadOnly = true;
            this.DGMatrizA.RowHeadersVisible = false;
            this.DGMatrizA.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.DGMatrizA.Size = new System.Drawing.Size(200, 200);
            this.DGMatrizA.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Matriz de Adyacencia :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(309, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Matriz deIncidencia :";
            // 
            // NAristasLabel
            // 
            this.NAristasLabel.AutoSize = true;
            this.NAristasLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NAristasLabel.Location = new System.Drawing.Point(309, 285);
            this.NAristasLabel.Name = "NAristasLabel";
            this.NAristasLabel.Size = new System.Drawing.Size(177, 20);
            this.NAristasLabel.TabIndex = 5;
            this.NAristasLabel.Text = "Número de Aristas :  ";
            // 
            // NVerticesLabel
            // 
            this.NVerticesLabel.AutoSize = true;
            this.NVerticesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NVerticesLabel.Location = new System.Drawing.Point(46, 285);
            this.NVerticesLabel.Name = "NVerticesLabel";
            this.NVerticesLabel.Size = new System.Drawing.Size(187, 20);
            this.NVerticesLabel.TabIndex = 6;
            this.NVerticesLabel.Text = "Número de Vértices :  ";
            // 
            // Propiedades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 336);
            this.Controls.Add(this.NVerticesLabel);
            this.Controls.Add(this.NAristasLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DGMatrizA);
            this.Controls.Add(this.DGMatrizI);
            this.Name = "Propiedades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Propiedades";
            ((System.ComponentModel.ISupportInitialize)(this.DGMatrizI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGMatrizA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGMatrizI;
        private System.Windows.Forms.DataGridView DGMatrizA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label NAristasLabel;
        private System.Windows.Forms.Label NVerticesLabel;

    }
}