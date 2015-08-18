using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Editor_de_Gafos
{
    public partial class DDFloyd : Form
    {
        public DDFloyd(DataTable dt)
        {
            InitializeComponent();
            dataGridView1.DataSource = dt;
        }

        private void BAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}