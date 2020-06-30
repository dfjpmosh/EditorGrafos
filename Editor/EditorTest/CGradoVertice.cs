using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EditorTest
{
    class CGradoVertice
    {
        private int numGrado;
        private bool marcado;
        private List<CGradoVecino> Lista_degVecino;

        public CGradoVertice()
        {
            numGrado = 0;
            marcado = false;
            Lista_degVecino = new List<CGradoVecino>();
        }
        
        public int Grado
        {
            get { return numGrado; }
            set { numGrado = value; }
        }
        public bool Marcado
        {
            get { return marcado; }
            set { marcado = value; }
        }

        public void agregaVecino(CGradoVecino degVecino)
        {
            Lista_degVecino.Add(degVecino);
        }

        public List<CGradoVecino> getLista_degVecino()
        {
            return Lista_degVecino;
        }

        public void desmarcaVecinos()
        {
            foreach (CGradoVecino gv in getLista_degVecino())
            {
                gv.Marcado = false;
            }
        }

        public bool todosMarcados()
        {
            foreach (CGradoVecino gv in Lista_degVecino)
            {
                if (gv.Marcado == false)
                    return false;
            }
            return true;
        }

    }
}
