namespace Editor_de_Gafos
{
    partial class DConteo
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
            this.label1 = new System.Windows.Forms.Label();
            this.TBA = new System.Windows.Forms.TextBox();
            this.TBH = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.BContar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.TBR = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Número de caminos entre :";
            // 
            // TBA
            // 
            this.TBA.Location = new System.Drawing.Point(70, 89);
            this.TBA.Name = "TBA";
            this.TBA.Size = new System.Drawing.Size(50, 20);
            this.TBA.TabIndex = 5;
            // 
            // TBH
            // 
            this.TBH.Location = new System.Drawing.Point(170, 89);
            this.TBH.Name = "TBH";
            this.TBH.Size = new System.Drawing.Size(50, 20);
            this.TBH.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(167, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Nodo B :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nodo A :";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(248, 133);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // BContar
            // 
            this.BContar.Location = new System.Drawing.Point(70, 133);
            this.BContar.Name = "BContar";
            this.BContar.Size = new System.Drawing.Size(75, 23);
            this.BContar.TabIndex = 8;
            this.BContar.Text = "Contar !";
            this.BContar.UseVisualStyleBackColor = true;
            this.BContar.Click += new System.EventHandler(this.BContar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(274, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Longitud:";
            // 
            // TBR
            // 
            this.TBR.Location = new System.Drawing.Point(273, 89);
            this.TBR.Name = "TBR";
            this.TBR.Size = new System.Drawing.Size(50, 20);
            this.TBR.TabIndex = 10;
            // 
            // DConteo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 182);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TBR);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.BContar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TBA);
            this.Controls.Add(this.TBH);
            this.Controls.Add(this.label1);
            this.Name = "DConteo";
            this.Text = "Conteo de caminos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TBA;
        private System.Windows.Forms.TextBox TBH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button BContar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TBR;
    }
}