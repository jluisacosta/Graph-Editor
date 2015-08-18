using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Editor_de_Gafos
{
    public partial class DConteo : Form
    {
        private int nmax;
        public int na;
        public int nb;
        public int r;

        public DConteo(int valormax)
        {
            InitializeComponent();
            nmax = valormax;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BContar_Click(object sender, EventArgs e)
        {
            if (TBA.Text != "" && TBH.Text != "" &&  TBR.Text != "")
            {
                try
                {
                    if (Convert.ToInt32(TBA.Text) > 0 && Convert.ToInt32(TBA.Text) <= nmax &&
                    Convert.ToInt32(TBH.Text) > 0 && Convert.ToInt32(TBH.Text) <= nmax)
                    {
                        na = Convert.ToInt32(TBA.Text);
                        nb = Convert.ToInt32(TBH.Text);
                        r = Convert.ToInt32(TBR.Text);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                        MessageBox.Show(" Existen valores fuera del rango!! ", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (FormatException fe)
                {
                    MessageBox.Show(fe.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}