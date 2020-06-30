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
    public partial class Numero_de_Aristas : Form
    {
        int numAri;
        public Numero_de_Aristas(int na)
        {
            InitializeComponent();
            numAri = na;
        }

        private void Numero_de_Aristas_Load(object sender, EventArgs e)
        {
            aristasLabel.Text = numAri.ToString();
        }
    }
}
