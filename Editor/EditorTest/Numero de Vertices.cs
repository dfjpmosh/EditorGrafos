﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EditorTest
{
    public partial class Numero_de_Vertices : Form
    {
        int numVert;
        public Numero_de_Vertices(int nv)
        {
            InitializeComponent();
            numVert = nv;
        }

        private void Numero_de_Vertices_Load(object sender, EventArgs e)
        {
            verticesLabel.Text = numVert.ToString();
        }

        

    }
}
