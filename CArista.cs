using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Editor_de_Gafos
{
    [Serializable]
    public class CArista
    {
        private CVertice origen;
        private CVertice destino;
        private Point po;
        private Point pd;
        private int tipo;
        private int peso;
        public const int NO_DIRIGIDA = 0,DIRIGIDA = 1;

        //Constructor
        public CArista(CVertice or,CVertice de, Point o, Point d,int tipo_ar)
        {
            po = o;
            pd = d;
            origen = or;
            destino = de;
            tipo = tipo_ar;
            peso = 0;
        }

        //Movilidad
        public void setPuntoOD(Point o, Point d)
        {
            po = o;
            pd = d;
        }

        //Dibujado
        public void dibujate(Graphics g, Bitmap bmp, TabPage tp)
        {
            Graphics dbm = tp.CreateGraphics();
            dbm.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Pen p = new Pen(Color.CornflowerBlue,4);

            if (this.tipo == DIRIGIDA)
                p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;

            g.DrawLine(p, po, pd);
            dbm.DrawImage(bmp, 0, 0);
        }
        
        public void borrateMov(Graphics g)
        {
            Pen borrador = new Pen(Color.White, 6);

            g.DrawLine(borrador, po, pd);
        }

        //Getters Setters
        public CVertice getVOrigen()
        {
            return origen;
        }

        public CVertice getVDestino()
        {
            return destino;
        }

        public int getPeso()
        {
            return peso;
        }

        public void setVOrigen(CVertice or)
        {
            origen = or;
        }

        public void setVDestino(CVertice de)
        {
            destino = de;
        }

        public void setPO(Point p)
        {
            po = p;
        }

        public void setPD(Point p)
        {
            pd = p;
        }

        public void setPeso(int p)
        {
            peso = p;
        }

        public void dibujateRP(Graphics g, Bitmap bmp, TabPage tp,int tipo_arco,int tipo_grafo)
        {
            Graphics dbm = tp.CreateGraphics();
            dbm.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Pen p = new Pen(Color.CornflowerBlue, 4);
            
            if(tipo_grafo == DIRIGIDA)
                p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;

            p.Brush = Brushes.White;
            g.DrawLine(p, po, pd);
            p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            switch (tipo_arco)
            { 
                case 1://retroceso
                    p.Brush = Brushes.Red;
                break;
                case 2://avance
                    p.Brush = Brushes.DodgerBlue;
                break;
                case 3://cruzado
                    p.Brush = Brushes.GreenYellow;
                break;
            }
           
            g.DrawLine(p, po, pd);
            dbm.DrawImage(bmp, 0, 0);
        }

        public void dibujateAACM(Graphics g, Bitmap bmp, TabPage tp)
        {
            Graphics dbm = tp.CreateGraphics();
            dbm.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Pen p = new Pen(Color.CornflowerBlue, 4);

            p.Brush = Brushes.White;
            g.DrawLine(p, po, pd);
            p.Brush = Brushes.Orange;
            g.DrawLine(p, po, pd);
            dbm.DrawImage(bmp, 0, 0);
        }
    }
}
