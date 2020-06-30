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
    public partial class CaminoVertices : Form
    {
        int ini;
        int fin;
        public CaminoVertices(List<int> list)
        {
            InitializeComponent();
            foreach(int n in list )
            {
                comboVertIni.Items.Add(n);
                comboVertFin.Items.Add(n);
            }
        }

        private void CaminoVertices_Load(object sender, EventArgs e)
        {
            ini = fin = -1;           
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            if (ini ==-1 || (fin ==-1 && comboVertFin.Visible==true))
            {
                this.DialogResult = DialogResult.None;
            }
        }

        private void comboVertIni_SelectedIndexChanged(object sender, EventArgs e)
        {
            ini = Convert.ToInt32(comboVertIni.SelectedItem);
        }

        private void comboVertFin_SelectedIndexChanged(object sender, EventArgs e)
        {
            fin = Convert.ToInt32(comboVertFin.SelectedItem);
        }

        public int getIni()
        {
            return ini;
        }

        public int getFin()
        {
            return fin;
        }

    }
}
