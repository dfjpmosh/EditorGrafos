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
    public partial class AristaProp : Form
    {
        private int nVertices;
        private string titulo;
        public AristaProp(string tit)
        {            
            InitializeComponent();
            nVertices = 0;
            titulo = tit;
        }        

        public int getCosto()
        {
            return nVertices;
        }

        private void botonAceptar_Click(object sender, EventArgs e)
        {
            nVertices = (int)pesoAristaUpDown.Value;
            this.Close();
        }

    }
}
