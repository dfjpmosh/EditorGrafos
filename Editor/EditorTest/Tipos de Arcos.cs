using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EditorTest
{    
    public partial class Tipos_de_Arcos : Form
    {
        public bool band = false;
        private bool cad;
        public Tipos_de_Arcos(bool gda)
        {
            InitializeComponent();
            cad = gda;
        }

        private void Tipos_de_Arcos_Paint(object sender, PaintEventArgs e)
        {
            if (cad)
                gda.Text = "Es GDA";
            else
                gda.Text = "No es GDA";
            e.Graphics.FillRectangle(Brushes.DodgerBlue, 90, 30, 100, 20);
            e.Graphics.FillRectangle(Brushes.Green, 90, 60, 100, 20);
            e.Graphics.FillRectangle(Brushes.DarkGray, 90, 90, 100, 20);
            e.Graphics.FillRectangle(Brushes.Yellow, 90, 120, 100, 20);
        }

        private void Tipos_de_Arcos_FormClosed(object sender, FormClosedEventArgs e)
        {
            band = true;
        }
        
    }
}
