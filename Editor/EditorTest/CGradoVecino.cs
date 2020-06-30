using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EditorTest
{
    class CGradoVecino
    {
        private int deg;
        private bool marcado;

        public CGradoVecino(int d)
        {
            deg = d;
            marcado = false;
        }

        public int DegVecino
        {
            get { return deg; }
            set { deg = value; }
        }
        
        public bool Marcado
        {
            get { return marcado; }
            set { marcado = value; } 
        }
    }
}
