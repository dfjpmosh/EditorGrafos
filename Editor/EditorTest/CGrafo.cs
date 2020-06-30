using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace EditorTest
{
    [Serializable]
    class CGrafo
    {
        protected List<CVertice> listV;
        private List<CVertice> listVTemp = null;
        private List<CArista> listAtemp = null;
        public int[,] P;
        public int[,] D;
        //protected Config configuracion;
        //constructor
        public CGrafo()
        {
            listV = new List<CVertice>();
          //  configuracion = new Config();
        }        
        //
        /*public Config Config
        {
            get { return configuracion; }
            set { configuracion = value; }
        }*/

        //get & set List
        public List<CVertice> ListV
        {            
            get { return listV; }
            set { listV = value; }
        }        
        //Vertices
        public int numVertices()
        {
            return listV.Count;
        }
        public void agregaVertice(CVertice vertice)
        {
            listV.Add(vertice);
        }
        public CVertice dameVertice(Point pos)
        {
            foreach (CVertice v in listV)
            {
                if (v.Intersect(pos))
                {
                    return v;
                }                
            }
            CVertice vertice = null;
            return vertice;
        }
        public CVertice dameVertice(int id)
        {
            CVertice vertice = null;
            foreach (CVertice v in listV)
            {
                if (v.id == id)
                    vertice = v;
            }            
            return vertice;
        }
        public CArista dameArista(CVertice v1, CVertice v2)
        {
            CArista ari = null;

            foreach (CArista a in v1.getListaAristas())
            {
                if (a.v1 == v1 && a.v2 == v2 || a.v1 == v2 && a.v2 == v1)
                {
                    ari = a;
                    ari.color = Color.Yellow;
                }
            }

            return ari;
        }

        public void eliminaVertice(CVertice vertice)
        {
             foreach(CVertice v in listV)
             {
                  v.eliminaRelacionesCon(vertice);
             }             
             listV.Remove(vertice);
        }
        public void muestraNumVertices()
        {
            Numero_de_Vertices nv = new Numero_de_Vertices(numVertices());
            nv.ShowDialog();
        }

        public void muestraNumA()
        {
            Numero_de_Aristas nv = new Numero_de_Aristas(numeroAristas());
            nv.ShowDialog();
        }
        public int[,] matrizAdyacencia()
        {
            int[,] mAdy = new int[listV.Count + 1, listV.Count + 1];

            for (int i = 1; i <= listV.Count; i++)
                for (int j = 1; j <= listV.Count; j++)
                    mAdy[i, j] = 0;

            mAdy[0, 0] = -1;
            for (int i = 1; i <= listV.Count; i++)
            {
                mAdy[i, 0] = listV[i - 1].id;
                mAdy[0, i] = listV[i - 1].id;
            }

            foreach (CVertice v in listV)
            {
                foreach (CArista a in v.getListaAristas())
                {
                    mAdy[ listV.IndexOf(a.v2)+1, listV.IndexOf(v) + 1] += 1;
                }
            }
            return mAdy;
        }

        public void conteoCaminos()
        {
            int[,] matriz = new int[listV.Count,listV.Count];
            for (int i = 1; i <= listV.Count; i++)
            {
                for (int j = 1; j <= listV.Count; j++)
                {
                    matriz[i - 1, j - 1] = matrizAdyacencia()[i, j];
                }
            }
            int[,] result = new int[listV.Count,listV.Count];
            int[,] aux = new int[listV.Count, listV.Count];
            List<int> list = new List<int>();
            int longitud=0;
            Longitud dialogLon = new Longitud();

            foreach (CVertice v in listV)
            {
                list.Add(v.id);
            }

            CaminoVertices cam = new CaminoVertices(list);
            
            if (dialogLon.ShowDialog() == DialogResult.OK)
            {
                longitud = dialogLon.Long();
                //if (longitud == 1)
                {
                    for (int i = 0; i < listV.Count; i++)
                        for (int j = 0; j < listV.Count; j++)
                            result[i, j] = matriz[i, j];
                }
                //else
                {
                    for (int vuelta = 1 ; vuelta < longitud; vuelta++)
                    {
                        for (int i = 0; i < listV.Count; i++)
                            for (int j = 0; j < listV.Count; j++)
                                aux[i, j] = 0;
                        for (int i = 0; i < listV.Count; i++)
                            for (int j = 0; j < listV.Count; j++)
                                aux[i, j] = result[i, j];
                        for (int i = 0; i < listV.Count; i++)
                        {
                            for (int j = 0; j < listV.Count; j++)
                            {
                                result[i,j] = 0; 
                                for (int z = 0; z < listV.Count; z++)
                                {
                                    result[i, j] += matriz[i, z] * aux[z, j];
                                }
                            }
                        }
                    }
                }
            }
            if (cam.ShowDialog() == DialogResult.OK)
            {
                int ini = cam.getIni()-1;
                int fin = cam.getFin()-1;
                string cad = " Numero de caminos de longitud " + longitud.ToString() + " entre el Vertice " + (ini+1).ToString() + " hasta el" + (fin+1).ToString() + " es " + result[ini, fin];
                MessageBox.Show(cad, "Conteo de Caminos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }            
        }

        public bool isomorfismo(CGrafo g1, CGrafo g2)
        {
            g1.desmarcar();
            g2.desmarcar();
            bool salir = false, salirRelacion = false;
            List<CVertice> aux = new List<CVertice>();
            foreach (CVertice vg1 in g1.listV)
            {
                foreach (CVertice vg2 in g2.listV)
                {
                    if (vg1.grado == vg2.grado && !vg2.marcado)
                    {
                        vg2.marcado = true;
                        break;
                    }
                }
            }
            
            foreach (CVertice v in g2.ListV)
            {
                if (!v.marcado)
                {
                    salir = true;
                    break;
                }
            }

            g2.desmarcar();
            g1.desmarcar();

            bool band1 = false;
            if (!salir)
            {
                foreach (CVertice v in g1.ListV)
                {
                    v.cargaGradosVecinos();
                    foreach (CVertice w in g2.ListV)
                    {
                        band1 = false;
                        w.cargaGradosVecinos();
                        if (v.GradosVecinos.Count == w.GradosVecinos.Count && v.grado==w.grado && !w.marcado && !v.marcado)
                        {//misma cantidad de vecinos                            
                            int i=0;
                            w.cargaGradosVecinos();//cargo la lista de grados de vecinos
                            List<int> grados= w.GradosVecinos;
                            for (i = 0; i < grados.Count; i++)
                            {//checar los grados de cada vecino
                                if (v.GradosVecinos.Contains(grados[i]))
                                {
                                    v.GradosVecinos.Remove(grados[i]);
                                    band1 = true;
                                }
                                else
                                {
                                    v.GradosVecinos = v.recuperaGradosVecinos();
                                    band1 = false;
                                    break;
                                }
                            }
                            if(i==grados.Count && band1 )
                                w.marcado = true;
                        }
                        if (band1)
                        {
                            v.marcado = true;
                            break; 
                        }
                    }
                }
            }

            foreach (CVertice v in g2.ListV)
            {
                if (!v.marcado)
                {
                    salirRelacion = true;
                    break;
                }
            }
            if(salir || salirRelacion )
                return false;
            return true;
        }

         public void desmarcar()
        {
            foreach (CVertice v in ListV)
            {
                v.marcado = false;
            }
        }

        public bool hayArista(Point pos)
        {
            List<CArista> lA = new List<CArista>();
            foreach (CVertice pV in listV)
            {
                lA = pV.getListaAristas();
                foreach (CArista a in lA)
                {
                    if (a.intersectaCon(pos))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public CArista dameArista(Point position)
        {
            List<CArista> lA = new List<CArista>();
            CArista arista = null;
            foreach (CVertice pV in listV)
            {
                lA = pV.getListaAristas();
                foreach (CArista a in lA)
                {
                    if (a.v1 == a.v2)
                    {
                        if (a.buscaOreja(position, pV.pos, pV.diam))
                        {
                            arista=a;
                        }
                    }
                    else
                        if (a.curva)
                        {
                            if (a.buscaBezier(position))
                            {
                                arista = a;
                            }
                        }
                        else
                        {
                            if (a.intersectaCon(position))
                            {
                                arista = a;
                            }
                        }
                }
            }
            return arista;
        }

        //virtual
        //tercer 
        public virtual int[,] calculaFloyd()
        {
           return null;
        }

        public void Floyd()
        {
            int n = listV.Count;
            P= new int[n,n];
            D = new int[n, n];
            int i, j, k;

            int[,] C = new int[n, n];

            
            foreach(CVertice v in listV )
            {
                foreach( CVertice w in listV)
                {
                    CArista a = v.dameAristaCon(w);
                    if (a != null)
                    {
                        C[listV.IndexOf(v) , listV.IndexOf(w) ] = a.Costo;
                    }
                    else
                        C[listV.IndexOf(v), listV.IndexOf(w)] = 999999;
                }
            }

            for ( i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    D[i, j] = C[i, j];
                    P[i, j] = 0;
                }
            }

            for (i = 0; i < n; i++)
                D[i, i] = 0;

            
            for (k = 0; k < n; k++)
            {
                for (i = 0; i < n; i++)
                {
                    for (j = 0; j < n; j++)
                    {
                        if (D[i, k] + D[k, j] < D[i, j])
                        {
                            D[i, j] = D[i, k] + D[k, j];
                            P[i, j] = k;
                        }
                    }
                }
            }
        }

        public void respalda()
        {
            //Resplado vertices
            listVTemp = new List<CVertice>(listV);
            /****Respaldo Arista***************/
            List<CArista> lA;
            listAtemp = new List<CArista>();
            //Metemos todas las aristas del grafo en lA2
            foreach (CVertice v in listV)
            {
                lA = v.getListaAristas();
                foreach (CArista a in lA)
                {
                    listAtemp .Add(a);
                }
            }
        }

        public void restaura()
        {
            if (listV.Count != 0 && listVTemp != null)
            {
                listV.Clear();

                List<CArista> lA3;
                //Restauramos Vertices
                foreach (CVertice v in listVTemp )
                {
                    v.Color=Color.White;
                    lA3 = v.getListaAristas();
                    lA3.Clear();
                    this.agregaVertice(v);
                }
                //Restauramos Aristas
                foreach (CArista a in listAtemp )
                {
                    //Arista arista = new Arista(a.v1, a.v2);
                    //arista.setPeso(a.getPeso());
                    CArista arista = new CArista(a.v1, a.v2,a.color,a.ancho);
                    arista.Costo = a.Costo;
                    arista.curva = a.curva;
                    arista.AD = a.AD;

                    a.v1.agregaArista(arista);
                }
            }
        }

        //
        virtual public bool Colorario()
        {
            return false;
        }
        virtual public void Coloreados()
        {
        }
        virtual public void eliminaKuartowski(Point pos)
        {
        }
        virtual public void subdivisionKuartowski(CVertice v)
        {
        }
        virtual public void contraccionKuartowski(CVertice v)
        {
        }
        virtual public bool kuratowsky_k5()
        {
            return false;
        }

        virtual public bool kuratowsky_k33()
        {
            return false;
        }

        virtual public void dibujaGrafo(Graphics osdc, bool activo)
        {
        }
        virtual public void agregaArista(CArista arista)
        { 
        }
        virtual public void eliminaArista(Point pos)
        { 
        }
        virtual public bool buscaArista(Point pos)
        {
            foreach (CVertice v in listV)
            {
                //si es verdadero, ya elimino una arista
                //hacemos esta verificacion para que no borre mas de una arista
                if (v.buscaArista(pos) == true)
                {
                    return true;
                }

            }
            return false;
        }
        virtual public bool esDirigigo()
        {
            return false;
        }
        virtual public void dibujaGrafo(Graphics g)
        { 
        }
        virtual public void muevete(Point p1, Point p2)
        { 
        }
        virtual public int numeroAristas()
        {
            return 0;
        }
        virtual public void matrizIncidencia()
        { 
        }
        public virtual bool tieneCamino()
        {
            return false;
        }
        public virtual bool tieneCircuito()
        {
            return false;
        }

        public virtual String calculaEuler(Graphics g)
        {
            return "";
        }
        public virtual void dibujaCamino(Graphics g, String camino, int iter)
        {
        }
        //tercer
        virtual public void Dijkstra(int[,] C, int ivi)
        {
        }
        virtual public void Warshall(int[,] C)
        {
        }
        virtual public bool BosqueAbarcadorProfundidad()
        {
            return false;
        }
        virtual public int ComponentesFuertes()
        {
            return 0;
        }
        public virtual string centroGrafo()
        {
            return "";
        }
        //cuarto parcial
        virtual public void Prim()
        { 
        }
        virtual public void Kruskal()
        { 
        }
        virtual public void RecorridoProfundidad()
        { 
        }
        virtual public void ReccorridoAmplitud()
        { 
        }
        virtual public void PuntosArticulacion()
        { 
        }
        virtual public void gradoNodos()
        {
        }
    }
}
