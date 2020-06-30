using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace EditorTest
{
    public partial class Matriz_Adyacencia : Form
    {
        int[,] ma;
        Bitmap bmp;
        Graphics g, pag;
        PaintEventArgs paintE;

        public Matriz_Adyacencia(int[,] info, int numVertices)
        {
            InitializeComponent();
            ma = info;
            bmp = new Bitmap(ClientSize.Width, ClientSize.Height);
            pag = CreateGraphics();
            g = Graphics.FromImage(bmp);
        }

        private void Matriz_Adyacencia_Paint(object sender, PaintEventArgs e)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;//suaviza el pintado 
            g.Clear(this.BackColor);//limpiamos el graphics
            paintE = e;//actualizamos el evento de paint    

            Font font = new Font("Arial", 10);
            SolidBrush brocha = new SolidBrush(Color.Black);
            Pen pen = new Pen(brocha, 15);
            Point pos = new Point(50, 100);

            double dim = Math.Sqrt(ma.Length);

            for (int i = 0; i < (int)dim; i++)
            {                
                for (int j = 0; j < (int)dim; j++)
                {
                    pos.Y+=15;
                    g.DrawString(ma[i,j].ToString(), font, Brushes.Black, pos.X, pos.Y);
                }
                pos.X += 15;
                pos.Y = 100;
            }
            pag.DrawImage(bmp, 0, 0);
        }
    }
}
