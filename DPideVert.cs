using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Editor_de_Gafos
{
    public partial class DPideVert : Form
    {
        private int id_vert;
        private int max;

        public DPideVert(int nmax)
        {
            InitializeComponent();
            max = nmax;
            id_vert = 1;
        }

        private void BAceptar_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                try
                {
                    int nv = Convert.ToInt32(textBox1.Text);
                    if (nv > 0 && nv <= max)
                    {
                        id_vert = nv;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                catch (FormatException fe)
                {
                    MessageBox.Show(fe.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        public int getIdVert()
        {
            return id_vert;
        }

        public void setTituloVentana(string tit)
        {
            this.Text = tit;
        }

        public void setLabelVertice(string et)
        {
            label1.Text = et;
        }
    }
}