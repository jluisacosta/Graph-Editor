using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Editor_de_Gafos
{
    public partial class DAddPeso : Form
    {
        private List<int> pesos;

        public DAddPeso(List<CArista> aristas)
        {
            InitializeComponent();
            agregaTextBox(aristas);
            pesos = new List<int>();
        }

        public void agregaTextBox(List<CArista> lar)
        { 
            int x = 50,y = 60,indx=1;
            foreach (CArista a in lar)
            {
                Label l = new Label();
                l.Name = "LE" + indx.ToString();
                l.Text = "E" + indx.ToString() + " : ";
                l.Size = new Size(40, 13);
                l.Location = new Point(x, y);
                TextBox tb = new TextBox();
                tb.Name = "TBE"+ indx.ToString();
                tb.Text ="";
                tb.Size = new Size(60, 20);
                tb.Location = new Point(x + 60, y-3);
                y += 25;
                this.Controls.Add(l);
                this.Controls.Add(tb);
                indx++;
            }
            this.Size = new Size(this.Size.Width, y + 90);
            BAceptar.Location = new Point((this.Width/2)-(BAceptar.Width/2),this.Height - 75);
        }

        private void BAceptar_Click(object sender, EventArgs e)
        {
            bool hay_vacio = false;
            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    TextBox tb = (TextBox)c;
                    if (tb.Text == "")
                    {
                        hay_vacio = true;
                        break;
                    }
                    else if (Convert.ToInt32(tb.Text) < 0)
                    { 
                        MessageBox.Show(" Existen valores negativos!!", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        hay_vacio = true;
                        break;
                    }
                }
            }

            if (!hay_vacio)
            {
                foreach (Control c in this.Controls)
                {
                    if (c.GetType() == typeof(TextBox))
                    {
                        TextBox tb = (TextBox)c;
                        try
                        {
                            int peso = Convert.ToInt32(tb.Text);
                            pesos.Add(peso);
                        }
                        catch (FormatException fe)
                        {
                            fe.GetType();
                            MessageBox.Show(" Existen valores no numericos!!", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        public List<int> getPesos()
        {
            return pesos;
        }
    }
}