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
    public partial class Longitud : Form
    {
        int lon;
        public Longitud()
        {
            InitializeComponent();            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textLon.Text != "") 
                lon = Convert.ToInt32(textLon.Text);
        }

        private void Longitud_Load(object sender, EventArgs e)
        {
            lon = 0;            
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            if (textLon.Text== "")
            {
                this.DialogResult = DialogResult.None;
            }
        }
        public int Long()
        {
            return lon;
        }
    }
}
