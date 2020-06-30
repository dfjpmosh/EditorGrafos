
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace EditorTest
{
    public partial class Datos : Form
    {
        Bitmap img;
        Graphics g, pag;
        PaintEventArgs paintE;
        public Config config,con;
        

        public Datos(Config c)
        {
            InitializeComponent();
            config = new Config();
            config.AA = c.AA;
            config.ACV = c.ACV;
            config.CA = c.CA;
            config.CCV = c.CCV;
            config.CP = c.CP;
            config.CV = c.CV;
            config.DIAM = c.DIAM;
            config.ID = c.ID;
        }
        public Config CONFIG
        {
            get { return config; }
            set { config = value; }
        }

        private void Datos_Load(object sender, EventArgs e)
        {
            img = new Bitmap(ClientSize.Width, ClientSize.Height);
            pag = CreateGraphics();
            g = Graphics.FromImage(img);

            textPantalla.BackColor = config.CP;

            textRelleno.BackColor = config.CV;
            textCVert.BackColor = config.CCV;
            textAContorno.Text = config.ACV.ToString();
            AnchoContorno.Value = config.ACV;
            textDiametro.Text = config.DIAM.ToString();
            Diametro.Value = config.DIAM;
            if (config.ID)
            {
                numero.Checked = true;
                letra.Checked = false;
            }
            else
            {
                numero.Checked = true;
                letra.Checked = false;
            }
            textColorArista.BackColor = config.CA;
            textAnchoArista.Text = config.AA.ToString();
            AnchoLinea.Value = config.AA;
            
            pag.DrawImage(img, 0, 0);//pintamos imagen en el graphics            

            Pantalla.Click += new EventHandler(Pantalla_Click);
            RellenoVertice.Click += new EventHandler(RellenoVertice_Click);
            ContornoVertice.Click+=new EventHandler(ContornoVertice_Click);
            AnchoContorno.Scroll += new EventHandler(AnchoContorno_Scroll);
            Diametro.Scroll += new EventHandler(Diametro_Scroll);
            numero.Click += new EventHandler(numero_Click);
            letra.Click += new EventHandler(letra_Click);
            Arista.Click += new EventHandler(Arista_Click);
            AnchoLinea.Scroll += new EventHandler(AnchoLinea_Scroll);
            this.Paint += new PaintEventHandler(Datos_Paint);
        }

        void Datos_Paint(object sender, PaintEventArgs e)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;//suaviza el pintado 
            g.Clear(config.CP);//limpiamos el graphics
            paintE = e;//actualizamos el evento de paint            
            
            Font font = new Font("Arial", 10);
            SolidBrush brocha = new SolidBrush( config.CV);
            Pen pen = new Pen(config.CCV, config.ACV);
            Point pos = new Point(500, 200);
            Point posA = new Point(400, 300);

            string num ;
            if (config.ID)
                num = "10";
            else
                num = "A";

            //Contorno de Nodo y Relleno
            g.DrawEllipse(pen, pos.X - config.DIAM / 2, pos.Y - config.DIAM / 2, config.DIAM, config.DIAM);
            g.FillEllipse(brocha, pos.X - config.DIAM / 2, pos.Y - config.DIAM / 2, config.DIAM, config.DIAM);

            //Num Id 
            g.DrawString(num, font, Brushes.Black, pos.X - 5, pos.Y - 5);

            //Arista no dirigida
            pen = new Pen(config.CA, config.AA);
            g.DrawLine(pen, posA.X , posA.Y, posA.X+150, posA.Y);

            //Arista dirigida
            AdjustableArrowCap tipo = new AdjustableArrowCap(5, 5);
            pen.CustomEndCap = tipo;
            g.DrawLine(pen, posA.X, posA.Y+50, posA.X + 150, posA.Y+50);


            pag.DrawImage(img, 0, 0);//pintamos imagen en el graphics            
        }

        void AnchoLinea_Scroll(object sender, EventArgs e)
        {
            config.AA = AnchoLinea.Value;
            textAnchoArista.Text = config.AA.ToString();
            this.Datos_Paint(sender, paintE);
        }
        void Arista_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                config.CA = colorDialog1.Color;
                textColorArista.BackColor = config.CA;
            }
            this.Datos_Paint(sender, paintE);
        }
        void letra_Click(object sender, EventArgs e)
        {
            if (letra.Checked == true)
            {
                config.ID = false;
                numero.Checked = false;
            }
            else
            {
                config.ID = true;
                numero.Checked = true;
            }
            this.Datos_Paint(sender, paintE);
        }
        void numero_Click(object sender, EventArgs e)
        {
            if (numero.Checked == true)
            {
                config.ID = true;
                letra.Checked = false;
            }
            else
            {
                config.ID = false;
                letra.Checked = true;
            }
            this.Datos_Paint(sender, paintE);
        }
        void Diametro_Scroll(object sender, EventArgs e)
        {
            config.DIAM = Diametro.Value;
            textDiametro.Text = config.DIAM.ToString();
            this.Datos_Paint(sender, paintE);
        }

        void AnchoContorno_Scroll(object sender, EventArgs e)
        {
            config.ACV = AnchoContorno.Value;
            textAContorno.Text = config.ACV.ToString();
            this.Datos_Paint(sender, paintE);
        }
                
        void ContornoVertice_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                config.CCV = colorDialog1.Color;
                textCVert.BackColor = config.CCV;
            }
            this.Datos_Paint(sender, paintE);
        }
        void RellenoVertice_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                config.CV = colorDialog1.Color;
                textRelleno.BackColor = config.CV;
            }
            this.Datos_Paint(sender, paintE);
        }

        void Pantalla_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                config.CP = colorDialog1.Color;
                textPantalla.BackColor = config.CP;
            }
            this.Datos_Paint(sender, paintE);
        }
    }
}
