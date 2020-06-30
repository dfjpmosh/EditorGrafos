using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EditorTest
{
    class Componente
    {
        private int num;
        private List<CVertice> vertices;

        public Componente(int num, CVertice v )
        {
            this.num = num;
            vertices = new List<CVertice>();
            vertices.Add(v);
        }
        public Componente()
        {
            this.num = -1;
            vertices = new List<CVertice>();
        }

        public int Numero
        {
            get { return num; }
            set { num = value; }
        }

        public List<CVertice> Lista
        {
            get { return vertices; }
            set { vertices = value; }
        }

        public int encuentra(CVertice v)
        {
            int indice ;

            indice = vertices.IndexOf(v);
            if (indice >= 0)
                indice = num;
            else
                indice = -1;

            return indice;
        }

        public void agregaVertices(List<CVertice> v)
        {
            foreach (CVertice w in v)
            {
                vertices.Add(w);
            }
        }

        public void vaciaLista()
        {
            vertices = new List<CVertice>();
        }
    
    }
}
