namespace Editor_de_Gafos
{
    partial class DIso
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
            this.TBH = new System.Windows.Forms.TextBox();
            this.TBG = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BEvaluar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TBH
            // 
            this.TBH.Location = new System.Drawing.Point(223, 89);
            this.TBH.Name = "TBH";
            this.TBH.Size = new System.Drawing.Size(100, 20);
            this.TBH.TabIndex = 0;
            // 
            // TBG
            // 
            this.TBG.Location = new System.Drawing.Point(70, 89);
            this.TBG.Name = "TBG";
            this.TBG.Size = new System.Drawing.Size(100, 20);
            this.TBG.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Que Grafos desea evaluar?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Grafo G :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(220, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Grafo H :";
            // 
            // BEvaluar
            // 
            this.BEvaluar.Location = new System.Drawing.Point(70, 133);
            this.BEvaluar.Name = "BEvaluar";
            this.BEvaluar.Size = new System.Drawing.Size(75, 23);
            this.BEvaluar.TabIndex = 5;
            this.BEvaluar.Text = "Evaluar !";
            this.BEvaluar.UseVisualStyleBackColor = true;
            this.BEvaluar.Click += new System.EventHandler(this.BEvaluar_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(248, 133);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // DIso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 182);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.BEvaluar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TBG);
            this.Controls.Add(this.TBH);
            this.Name = "DIso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Evaluacion de Isomorfismo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TBH;
        private System.Windows.Forms.TextBox TBG;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BEvaluar;
        private System.Windows.Forms.Button button2;
    }
}