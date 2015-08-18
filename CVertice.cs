using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Editor_de_Gafos
{
    [Serializable]
    public class CVertice
    {
        private int grado; //Grado externo para el dirigido, normal para el no dirigido
        private int gradoint;
        private int grado_error;    //utilizado en el algoritmo de coloreado
        private int id;
        private int relleno; //ARGB
        private int contorno; //ARGB
        private int radio;
        private int bajo;
        private Point centro;
        private List<CVertice> vecinos;
        private bool pintado;
        private bool visitado;
        private int numero_rp;
        public const int LONG_RAD = 25, ANCHO_LINEA = 2;

        //Constructor
        public CVertice(int identificador,int xc,int yc,Color col_rell,Color col_con)
        {
            centro = new Point(xc, yc);
            radio = LONG_RAD;
            id = identificador;
            bajo = 0;
            relleno = col_rell.ToArgb();
            contorno = col_con.ToArgb();
            grado = gradoint = grado_error = numero_rp = 0;
            pintado = visitado = false;
            vecinos = new List<CVertice>();
        }


        //Metodos funcionales
        public void aumentaGrado()
        {
            grado++;
        }

        public void disminuyeGrado()
        {
            if ((grado - 1) != -1)
                grado--;
        }

        public void aumentaGradoInt()
        {
            gradoint++;
        }

        public void disminuyeGradoInt()
        {
            if ((gradoint - 1) != -1)
                gradoint--;
        }

        public void dibujate(Graphics g, Bitmap bmp, TabPage tp)
        {
            Graphics dbm = tp.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            dbm.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Pen pc = new Pen(Color.FromArgb(contorno),ANCHO_LINEA);
            Pen pr = new Pen(Color.FromArgb(relleno), ANCHO_LINEA);
            
            int dis = 4;

            if (id / 10 > 0)
                dis = 8;
            
            g.FillEllipse(pr.Brush, centro.X - radio, centro.Y - radio, radio * 2, radio * 2);
            g.DrawEllipse(pc, centro.X - radio, centro.Y - radio, radio*2, radio*2);
            g.DrawString(id.ToString(), new Font(FontFamily.GenericSansSerif, 10), pc.Brush, centro.X - dis, centro.Y - 7);
            dbm.Clear(Color.White);
            dbm.DrawImage(bmp, 0, 0);
        }

        public void dibujateMov(Graphics g, TabPage tp)
        {
            Pen pc = new Pen(Color.FromArgb(contorno), ANCHO_LINEA);
            Pen pr = new Pen(Color.FromArgb(relleno), ANCHO_LINEA);

            int dis = 4;

            if (id / 10 > 0)
                dis = 8;

            g.FillEllipse(pr.Brush, centro.X - radio, centro.Y - radio, radio * 2, radio * 2);
            g.DrawEllipse(pc, centro.X - radio, centro.Y - radio, radio * 2, radio * 2);
            g.DrawString(id.ToString(), new Font(FontFamily.GenericSansSerif, 10), pc.Brush, centro.X - dis, centro.Y - 7);
        }

        public void borrate(Graphics g, Bitmap bmp, TabPage tp)
        {
            Graphics dbm = tp.CreateGraphics();
            dbm.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Pen borrador = new Pen(Color.White, ANCHO_LINEA+2);

            g.FillEllipse(borrador.Brush, centro.X - radio, centro.Y - radio, radio * 2, radio * 2);
            g.DrawEllipse(borrador, centro.X - radio, centro.Y - radio, radio * 2, radio * 2);
            dbm.DrawImage(bmp, 0, 0);
        }

        public void borrateMov(Graphics g)
        {
            Pen borrador = new Pen(Color.White, ANCHO_LINEA + 2);

            g.FillEllipse(borrador.Brush, centro.X - radio, centro.Y - radio, radio * 2, radio * 2);
            g.DrawEllipse(borrador, centro.X - radio, centro.Y - radio, radio * 2, radio * 2);
        }

        public void coloreate(Color c)
        {
            relleno = c.ToArgb();
        }


        //Setters Getters
        public void setGrado(int num_grado)
        {
            grado = num_grado;
        }

        public int getGradoInt()
        {
            return gradoint;
        }

        public void setGradoInt(int num_grado)
        {
            gradoint = num_grado;
        }

        public int getGrado()
        {
            return grado;
        }

        public void setId(int id_vert)
        {
            id = id_vert;
        }

        public int getId()
        {
            return id;
        }

        public void setRelleno(int color_argb)
        {
            relleno = color_argb;
        }

        public int getArgbRelleno()
        {
            return relleno;
        }

        public void setContorno(int color_argb)
        {
            contorno = color_argb;
        }

        public int getArgbContorno()
        {
            return contorno;
        }

        public void setRadio(int rad)
        {
            radio = rad;
        }

        public int getRadio()
        {
            return radio;
        }

        public void setPuntoCenral(Point p)
        {
            centro = p;
        }

        public Point getPuntoCentral()
        {
            return centro;
        }

        public void setGradoError(int ge)
        {
            grado_error = ge;
        }

        public int getGradoError()
        {
            return grado_error;
        }

        public void aumentaGE()
        {
            grado_error++;
        }

        public bool estaPintado()
        {
            return pintado;
        }

        public void setPintado(bool p)
        {
            pintado = p;
        }

        public List<CVertice> getVecinos()
        {
            return vecinos;
        }

        public void setNumero(int numero)
        {
            numero_rp = numero;
        }

        public void setVisitado(bool status)
        {
            visitado = status;
        }

        public int getNumero()
        {
            return numero_rp;
        }

        public bool getVisitado()
        {
            return visitado;
        }

        public void setBajo(int b)
        {
            bajo = b;
        }

        public int getBajo()
        {
            return bajo;
        }
    }
}
