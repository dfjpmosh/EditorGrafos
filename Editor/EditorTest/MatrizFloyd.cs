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
    public partial class MatrizFloyd : Form
    {
        public MatrizFloyd(int tam)
        {
            InitializeComponent();
            this.Size = new Size(tam * 100, tam * 35);
            dg.ColumnCount = tam;
            dg.Name = "Floyd";
            dg.RowHeadersVisible = false;
            dg.ColumnHeadersVisible = false;
            dg.Dock = DockStyle.Fill;
        }

        public void imprime(string[] row)
        {
            dg.Rows.Add(row);
        }
    }
}
