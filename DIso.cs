using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Editor_de_Gafos
{
    public partial class DIso : Form
    {
        public int nmax;
        public int ng;
        public int nh;

        public DIso(int max)
        {
            InitializeComponent();
            nmax = max;
            ng = 1;
            nh = 2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BEvaluar_Click(object sender, EventArgs e)
        {
            if(TBG.Text != "" && TBH.Text != "")
            {
                try
                {
                    if (Convert.ToInt32(TBG.Text) != Convert.ToInt32(TBH.Text))
                    {
                        if (Convert.ToInt32(TBG.Text) > 0 && Convert.ToInt32(TBG.Text) <= nmax &&
                        Convert.ToInt32(TBH.Text) > 0 && Convert.ToInt32(TBH.Text) <= nmax)
                        {
                            ng = Convert.ToInt32(TBG.Text);
                            nh = Convert.ToInt32(TBH.Text);
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                            MessageBox.Show(" Existen valores fuera del rango!! ", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                    {
                        MessageBox.Show(" No se pueden repetir los grafos!! ", "Error..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (FormatException fe)
                {
                    MessageBox.Show(fe.Message,"Error...",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }
    }
}