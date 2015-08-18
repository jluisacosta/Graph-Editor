using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Editor_de_Gafos
{
    public class CColoreado
    {
        private CGrafo G;
        private Color[] colores;
        private int num_cromatico;
        public int cont =0;
        private bool band,band2;
        private const int AZUL = 0,ROJO = 1,VERDE = 2,AMARILLO = 3,NARANJA = 4,CAFE = 5,MORADO = 6,ROSA = 7,AQUA = 8,NEGRO = 9;

        //Constructor
        public CColoreado(CGrafo grafo)
        {
            colores = new Color[10];
            colores[AZUL]= Color.DeepSkyBlue;
            colores[ROJO]= Color.Red;
            colores[VERDE]= Color.Lime;
            colores[AMARILLO]= Color.Yellow;
            colores[NARANJA]= Color.Orange;
            colores[CAFE]= Color.Peru;
            colores[MORADO]= Color.DarkOrchid;
            colores[ROSA]= Color.HotPink;
            colores[AQUA]= Color.Aqua;
            colores[NEGRO]= Color.Black;
            band = band2=false;
            G = grafo;
            foreach (CNodoVertice cnv in G.getListaAdyacencia())
                cnv.getVertice().setGradoError(cnv.getVertice().getGrado());
        }


        public bool hayNodoSinPintar()
        {
            foreach (CNodoVertice cnv in G.getListaAdyacencia())
            {
                if (cnv.getVertice().estaPintado() == false)
                    return true;
            }
            return false;
        }

        public CVertice getNodoDeMayorGradoDeErrorSinPintar()
        {
            CVertice encontrado = null;
            int mayorGE = 0;
            foreach (CNodoVertice cnv in G.getListaAdyacencia())
            {
                if (!cnv.getVertice().estaPintado() && cnv.getVertice().getGradoError() >= mayorGE)
                {
                    mayorGE = cnv.getVertice().getGrado();
                    encontrado = cnv.getVertice();
                }
            }
            return encontrado;
        }

        public bool hayColorDisponibe(CVertice vertice,ref int color)
        {
            bool band = false;
            for (int colori = AZUL; colori < NARANJA; colori++)
            {
                if (!hayVecinoConColor(vertice, colori))
                {
                    color = colori;
                    band = true;
                    break;
                }
            }

            return band;
        }

        public bool hayColorDisponibeNColores(CVertice vertice, ref int color)
        {
            bool band = false;
            for (int colori = AZUL; colori < NEGRO; colori++)
            {
                if (!hayVecinoConColor(vertice, colori))
                {
                    color = colori;
                    band = true;
                    break;
                }
            }

            return band;
        }
        
        public void pintaNodo4Colores(CVertice vertice,int color_asignado)
        {
            if (num_cromatico < (color_asignado + 1))
                num_cromatico++;
            
            vertice.setRelleno(colores[color_asignado].ToArgb());
            vertice.setPintado(true);
        } //Con teorema de los 4 colores

        public void despintarNodosAdyacentesA(CVertice vertice)
        { 
            foreach(CVertice v in vertice.getVecinos())
            {
                v.setRelleno(Color.LightGoldenrodYellow.ToArgb());
                v.setPintado(false);
            }
        }

        public bool hayVecinoConColor(CVertice vertice, int color)
        {
            foreach (CVertice vecino in vertice.getVecinos())
            {
                if (vecino.estaPintado())
                {
                    if (vecino.getArgbRelleno() == colores[color].ToArgb())
                        return true;
                }
            }
            
            return false;
        }

        public void coloreoDeGrafoNColores(TabPage tp)
        {
            if (hayNodoSinPintar() && !band2)
            {
                CVertice vert_mge = getNodoDeMayorGradoDeErrorSinPintar();
                if (vert_mge != null)
                {
                    int color = -1;
                    if (hayColorDisponibeNColores(vert_mge, ref color) && color != -1)
                    {
                        pintaNodo4Colores(vert_mge, color);
                        coloreoDeGrafoNColores(tp);
                    }
                    else
                    {
                        band2 = true;
                        MessageBox.Show("\n El Grafo " + G.getId().ToString() + " ha sobrepasado el limite de colores disponible (10)...",
                            "Número cromatico arbitrario!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }
        
        public void coloreoDeGrafo4Colores(TabPage tp)
        {
            if (hayNodoSinPintar() && !band)
            {
                CVertice vert_mge = getNodoDeMayorGradoDeErrorSinPintar();
                if (vert_mge != null)
                {
                    int color = -1;
                    if (hayColorDisponibe(vert_mge, ref color) && color != -1)
                        pintaNodo4Colores(vert_mge, color);
                    else
                    {
                        if (vert_mge.getVecinos().Count != G.getNumeroVertices() - 1)
                        {
                            vert_mge.aumentaGE();
                            despintarNodosAdyacentesA(vert_mge);
                        }
                        else
                            band = true;
                    }

                    coloreoDeGrafo4Colores(tp);
                }
            }
            else
            {
                if (hayNodoSinPintar())
                    coloreoDeGrafoNColores(tp);
                
                G.dibujate(tp, G.getBMP());
            }
        }

        public bool esElUltimoEnPintar(CVertice v)
        {
            foreach (CNodoVertice cnv in G.getListaAdyacencia())
            {
                if (cnv.getVertice().getId() != v.getId() && !v.estaPintado())
                    return false;
            }

            return true;
        }

        public void pintaNodoNColores(CVertice vertice)
        {
            int color_asignado = AZUL;

            foreach (CVertice vecino in vertice.getVecinos())
            {
                if (vecino.estaPintado())
                {
                    if (vecino.getArgbRelleno() == colores[color_asignado].ToArgb())
                    {
                        if (color_asignado != NEGRO)
                        {
                            color_asignado++;
                        }
                    }
                }
            }

            vertice.setRelleno(colores[color_asignado].ToArgb());
            vertice.setPintado(true);
        } //General numero cromatico arbitrario

        public void regresaAEstadoOriginal()
        {
            foreach (CNodoVertice cnv in G.getListaAdyacencia())
            {
                cnv.getVertice().setPintado(false);
                cnv.getVertice().setRelleno(Color.LightGoldenrodYellow.ToArgb());
            }
        }
        
        //Setters Getters
        public void setNC(int nc)
        {
            num_cromatico = nc;
        }

        public int getNC()
        {
            return num_cromatico;
        }
    }
}
