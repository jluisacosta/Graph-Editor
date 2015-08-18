using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Editor_de_Gafos
{
    public partial class Propiedades : Form
    {
        public Propiedades(List<CNodoVertice> lady,List<CArista> lari, CMatrizAdyacencia mady,CMatrizIncidencia mind,int na,int nv)
        {
            InitializeComponent();
            DataTable mat_ady = new DataTable();
            DataTable mat_inc = new DataTable();
            object[] values = new object[lady.Count];
            object[] values2 = new object[lari.Count];

            int cont = 1;

            foreach (CNodoVertice cnv in lady)
                mat_ady.Columns.Add("V" + cnv.getVertice().getId(), typeof(int));

            foreach (CArista ar in lari)
            {
                mat_inc.Columns.Add("E"+cont.ToString(), typeof(int));
                cont++;
            }


            for (int i = 0; i < lady.Count; i++)
            {
                for (int j = 0; j < lady.Count; j++)
                    values[j] = mady.getMatriz()[i, j];

                mat_ady.Rows.Add(values);
            }

            for (int i = 0; i < lady.Count; i++)
            {
                for (int j = 0; j < lari.Count; j++)
                    values2[j] = mind.getMatriz()[i, j];

                mat_inc.Rows.Add(values2);
            }

            this.NAristasLabel.Text += na.ToString();
            this.NVerticesLabel.Text += nv.ToString();

            DGMatrizA.DataSource = mat_ady;
            DGMatrizI.DataSource = mat_inc;
        }
    }
}