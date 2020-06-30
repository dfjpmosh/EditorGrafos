using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace EditorTest
{
    [Serializable]
    class CArista
    {
        public CVertice v1, v2;
        public Color color;
        public int ancho;
        public bool marcada=false;
        public bool curva = false, AD=false;
        string idnom = "";
        private int costo;
        private PointF p1, p2, p3, p4, pId;
        
        //constructor
        public CArista(CVertice vert1, CVertice vert2,Color c, int grosor)
        {
            v1 = vert1;
            v2 = vert2;
            v2.degInf++;
            color = c;
            ancho = grosor;
            idnom = "e"+vert1.id.ToString();
            costo=-1;
            p1= p2 = p3 = p4 = pId = new PointF();
        }

        public int Costo
        {
            get { return costo; }
            set { costo = value; }
        }

        //dibuja arista
        public void dibujate(Graphics g, int estilo, int diam)
        {
            Pen pen = new Pen( color, ancho);
            Font font = new Font("Arial", 10);
            double teta1, teta2;
            float x1, y1, x2, y2;


            teta1 = Math.Atan2(v2.pos.Y - v1.pos.Y, v2.pos.X - v1.pos.X);
            teta2 = Math.Atan2(v1.pos.Y - v2.pos.Y, v1.pos.X - v2.pos.X);

            x1 = v1.pos.X + (float)(Math.Cos(teta1) * (diam / 2));
            y1 = v1.pos.Y + (float)(Math.Sin(teta1) * (diam / 2));
            x2 = v2.pos.X + (float)(Math.Cos(teta2) * (diam / 2));
            y2 = v2.pos.Y + (float)(Math.Sin(teta2) * (diam / 2));

            if (estilo == 1)
            {
                AdjustableArrowCap tipo = new AdjustableArrowCap(5,5);
                pen.CustomEndCap= tipo;
            }
            p1 = calculaPunto(90,diam);
            p2 = calculaPunto(270,diam);
            //PointF p1 = calculaPunto(-50, diam);
            //PointF p2 = calculaPunto(-140, diam);
                        
            if (v1 == v2)
            {
                if (marcada == true)
                {
                    //pen.Color = Color.Yellow;
                }
                //g.DrawBezier(pen, p1.X, p1.Y, p1.X + 20, p1.Y - 50, p1.X - 50, p1.Y - 50, p2.X, p2.Y);
                g.DrawArc(pen, p1.X - diam, (p1.Y-diam/2) - diam, diam, diam, 90, 270);
            }
            else
            {
                if (curva)
                {
                    if (AD)
                        calculaBezier(50, x1, y1, x2, y2);
                    else
                        calculaBezier(-50, x1, y1, x2, y2);
                    g.DrawBezier(pen, p1, p2, p3, p4);
                }
                else
                {
                    if (marcada == true)
                    {
                        //pen.Color = Color.Yellow;
                    }
                    g.DrawLine(pen, x1, y1, x2, y2);
                }
            }

            if (costo > 0)
            {
                string strCosto = costo.ToString();
                if (v1 == v2)
                    g.DrawString(strCosto, font, Brushes.Blue, v1.pos.X - (diam / 4) * 3, v1.pos.Y - (diam / 4) * 3);
                else
                    if(curva)
                        g.DrawString(strCosto, font, Brushes.Blue, pId);
                    else
                        g.DrawString(strCosto, font, Brushes.Blue, (x1 + x2) / 2, (y1 + y2) / 2);
            }
        }

        private PointF calculaPunto(double angulo,int diam)
        {
            PointF pF = new PointF();
            float x1 = v1.pos.X + (float)((Math.Cos(angulo * Math.PI / 180)) * (diam / 2));
            float y1 = v1.pos.Y + (float)((Math.Sin(angulo * Math.PI / 180)) * (diam / 2));
            pF.X = x1;
            pF.Y = y1;
            return pF;
        }

        //checa la interseccion con el punto pos para saber si esta arista se va a aliminar
        public bool intersectaCon(Point pos)
        {
            double cateto1 = v1.pos.X - pos.X;
            double cateto2 = v1.pos.Y - pos.Y;
            double d1, d2, dist;

            d1= Math.Sqrt(Math.Pow(cateto1, 2) + Math.Pow(cateto2, 2));

            cateto1 = v2.pos.X - pos.X;
            cateto2 = v2.pos.Y - pos.Y;

            d2 = Math.Sqrt(Math.Pow(cateto1, 2) + Math.Pow(cateto2, 2));

            cateto1 = v2.pos.X - v1.pos.X;
            cateto2 = v2.pos.Y - v1.pos.Y;

            dist = Math.Sqrt(Math.Pow(cateto1, 2) + Math.Pow(cateto2, 2));

            if ((int)(d1 + d2) == (int)dist)
                return true;

            return false;
        }

        public bool buscaOreja(Point punto, Point centro, int tam)
        {
            int x = centro.X - tam;
            int y = centro.Y - tam;

            if (punto.X > x && punto.X < centro.X &&
                punto.Y > y && punto.Y < centro.Y)
                return true;

            return false;
        }

        public CVertice getVerticeFinal()
        {
            return v2;
        }

        public void calculaBezier(int a, float x1, float y1, float x2, float y2)
        {
            PointF medio = new PointF(); 
            PointF medio1 = new PointF();
            PointF medio2 = new PointF();
            int dX, dY;
            p1 = new PointF(x1, y1);
            p4 = new PointF(x2, y2);

            dX = (int)(x2 - x1);
            dY = (int)(y2 - y1);

            medio.X = (p1.X + p4.X) / 2;
            medio.Y = (p1.Y + p4.Y) / 2;

            medio1.X = (p1.X + medio.X) / 2;
            medio1.Y = (p1.Y + medio.Y) / 2;

            medio2.X = (medio.X + p4.X) / 2;
            medio2.Y = (medio.Y + p4.Y) / 2;

            if (Math.Abs(dX) >= Math.Abs(dY))
            {
                p2.X = medio1.X;
                p2.Y = medio1.Y - a;
                p3.X = medio2.X;
                p3.Y = medio2.Y - a;
                pId.X = medio.X;
                pId.Y = medio.Y - a - 7;
            }
            else
            {
                p2.X = medio1.X - a;
                p2.Y = medio1.Y;
                p3.X = medio2.X - a;
                p3.Y = medio2.Y;
                pId.X = medio.X - a - 7;
                pId.Y = medio.Y;
            }
        }

        public bool buscaBezier(Point punto)
        {
            double X = 0, Y = 0;
            PointF[] ap = { p1, p2, p3, p4 };

            int n = 3, i = 0;
            float U = 0;

            while (U <= 1.0)
            {
                for (i = 0; i <= n; i++)
                {
                    X += (Math.Pow((1 - U), (n - i)) * (factorial(n) / (factorial(i) * factorial(n - i))) * Math.Pow(U, i) * ap[i].X);
                    Y += (Math.Pow((1 - U), (n - i)) * (factorial(n) / (factorial(i) * factorial(n - i))) * Math.Pow(U, i) * ap[i].Y);
                }

                if (punto.X <= X + 5 && punto.X >= X - 5 && punto.Y <= Y + 5 && punto.Y >= Y - 5)
                    return true;
                U += (float)(0.1);
                X = Y = 0;
            }

            return false;
        }

        public int factorial(int numero)
        {
            int f;

            if (numero == 1 || numero == 0)
                f = 1;
            else
                f = numero * factorial(numero - 1);

            return f;
        }
    }
}
