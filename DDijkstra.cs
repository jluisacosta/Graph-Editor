using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Editor_de_Gafos
{
    public partial class DDijkstra : Form
    {
        public DDijkstra(DataTable dt,int id)
        {
            InitializeComponent();
            dataGridView1.DataSource = dt;
            label1.Text += id.ToString() + " :";
        } 

        private void BAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}