using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace EditorTest
{
    [Serializable]
    class CGrafoDirigido: CGrafo
    {
        private int tiempo;
        //constructor padre
        public CGrafoDirigido():base()
        { 

        }
        //constructor por copia
        public CGrafoDirigido(CGrafo g)
        {
            listV = g.ListV;
            //configuracion = g.Config;
        }
        public override void muevete(Point p1, Point p2)
        {
            int dx = p2.X - p1.X;
            int dy = p2.Y - p1.Y;

            foreach(CVertice v in listV)
            {
                v.pos.X += dx;
                v.pos.Y += dy;
            }
            
        }
        ////GRAFO
        //es dirigido.
        public override bool esDirigigo()
        {
            return true;
        }
        //dibuja grafoDirigido
        public override void dibujaGrafo(Graphics g,bool activo)
        {
            foreach (CVertice vertice in listV)
            {
                //estilo == 1 si es con flecha
                vertice.dibujate(g,1);
                if (!activo)
                {
                    vertice.dibujate(g, 1);
                }
            }
        }
        ////ARISTA
        //Agrega Arista
        public override void agregaArista(CArista arista)
        {
            List<CArista> lA = new List<CArista>();
            CVertice v1 = arista.v1;
            lA = arista.v2.getListaAristas();

            foreach (CArista a in lA)
            {
                if (a.v1 == arista.v2 && a.v2 == arista.v1)
                {
                    a.curva = true;
                    a.AD = true;
                    arista.curva = true;
                    arista.AD = false;
                    break;
                }
            }
            v1.agregaArista(arista);
        }
        //Elimina Arista
        public override void eliminaArista(Point pos)
        {
            foreach (CVertice v in listV)
            {
                //si es verdadero, ya elimino una arista
                //hacemos esta verificacion para que no borre mas de una arista
                if (v.eliminaArista(pos) == true)
                    break;
            } 
        }

        public override bool buscaArista(Point pos)
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

        public override int numeroAristas()
        {
            int num = 0;
            foreach (CVertice v in listV)
            {
                num += v.getListaAristas().Count;
            }
            return num;
        }

        public override void gradoNodos()
        {
            string grados="";
            
            List<CArista> aux = new List<CArista>();

            foreach (CVertice v in listV)
            {
                v.degExt = v.degInf = 0;
                foreach (CArista a in v.getListaAristas())
                {
                    aux.Add(a);
                }
            }
            
            foreach (CArista a in aux)
            {
                foreach (CVertice w in listV)
                {
                    {
                        if (w.id == a.v1.id)
                            w.degExt++;
                        if (w.id == a.v2.id)
                            w.degInf++;
                    }
                }
            }            

            foreach (CVertice v in listV)
            {
                grados += "Deg-(" + v.id.ToString() + ")= " + v.degInf.ToString() + ". Deg+(" + v.id.ToString() + ")= " + v.degExt.ToString() + ".\n";
            }

            MessageBox.Show(grados, "Grados de los Nodos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool tieneCosto()
        {
            bool ret = true;
            List<CArista> lA = new List<CArista>();
            foreach (CVertice v in listV)
            {
                lA = v.getListaAristas();
                foreach (CArista a in lA)
                {
                    if (a.Costo == -1)
                    {
                        System.Windows.Forms.MessageBox.Show("Hay aristas sin costo.");
                        ret = false;
                    }
                }
            }
            return ret;
        }

        public override int[,] calculaFloyd()
        {
            int n = listV.Count + 1;
            int[,] matriz = null;
            int[,] P = null;
            int[,] C = null;

            CArista a = null;

            int comp = componentes();
            if (comp == 1)
            {
                if (tieneCosto())
                {
                    C = new int[n, n];
                    for (int x = 1; x < n; x++)
                    {
                        for (int y = 1; y < n; y++)
                        {
                            a = listV[x - 1].dameAristaCon(listV[y - 1]);
                            if (a != null)
                            {
                                C[x, y] = a.Costo;
                            }
                            else
                                C[x, y] = 999999;
                        }
                    }

                    matriz = new int[n, n];

                    for (int i = 1; i < n; i++)
                    {
                        matriz[i, 0] = listV[i - 1].id;
                        for (int j = 1; j < n; j++)
                        {
                            matriz[0, j] = listV[j - 1].id;
                            if (i == j)
                            {
                                matriz[i, j] = 0;
                            }
                            else
                            {
                                a = listV[i - 1].dameAristaCon(listV[j - 1]);
                                if (a != null)
                                {
                                    matriz[i, j] = a.Costo;
                                }
                                else
                                    matriz[i, j] = 999999;
                            }

                        }
                    }

                    for (int k = 1; k < n; k++)
                    {
                        for (int i = 1; i < n; i++)
                        {
                            for (int j = 1; j < n; j++)
                            {
                                if (matriz[i, k] + matriz[k, j] < matriz[i, j])
                                {
                                    matriz[i, j] = matriz[i, k] + matriz[k, j];
                                }
                            }
                        }
                    }
                }

            }
            else
                System.Windows.Forms.MessageBox.Show("El grafo no esta conectado");

            return matriz;
        }

        private void bpfCF(CVertice v)
        {
            v.marcado = true;
            List<CArista> listA = ordena(v.dameRelacionesSM(), 0);
            //Hay que ordenar la lista de menor a Mayor
            foreach (CArista a in listA)
            {
                if (a.v2.marcado == false)
                {
                    bpfCF(a.v2);
                }
            }
            v.id2 = tiempo;
            tiempo++;
        }
        private void bpfCF2(CVertice v)
        {

            v.marcado = true;
            List<CArista> listA = ordena(v.dameRelacionesSM(), 1);
            foreach (CArista a in listA)
            {
                if (a.v2.marcado == false)
                {
                    bpfCF2(a.v2);
                }
            }
        }
        private List<CArista> ordena(List<CArista> listA, int criterio)
        {
            CArista ar;
            List<CArista> lA = new List<CArista>();
            while (listA.Count != 0)
            {
                ar = listA[0];
                foreach (CArista a in listA)
                {
                    if (criterio == 0)
                    {
                        if (ar.v2.id > a.v2.id)
                        {
                            ar = a;
                        }
                    }
                    if (criterio == 1)
                    {
                        if (ar.v2.id2 < a.v2.id2)
                        {
                            ar = a;
                        }
                    }
                }
                lA.Add(ar);
                listA.Remove(ar);
            }
            return lA;
        }
        public int componentes()
        {
            List<CArista> lA;
            tiempo = 1;
            //Inicializar
            foreach (CVertice v in listV)
            {
                v.id2 = 0;
                v.marcado = false;
                lA = v.getListaAristas();
                foreach (CArista a in lA)
                {
                    a.color=Color.Black;
                    a.marcada = false;
                }
            }
            bpfCF(listV[0]);

            //Invertimos Aristas
            List<CArista> lA2 = new List<CArista>();
            //Metemos todas las aristas del grafo en lA2
            foreach (CVertice v in listV)
            {
                lA = v.getListaAristas();
                foreach (CArista a in lA)
                {
                    lA2.Add(a);
                }
                lA.Clear();
            }
            //Respaldamos Aristas antes de invertirlas
            List<CArista> lAR = new List<CArista>(lA2);
            //Invertimos Aristas
            foreach (CArista a in lA2)
            {
                this.agregaArista(new CArista(a.v2, a.v1, a.color, a.ancho));
                this.agregaArista(new CArista(a.v1, a.v2, a.color, a.ancho));
            }

            //Volvemos a inicializar
            tiempo = 1;
            foreach (CVertice v in listV)
            {
                v.marcado = false;
                lA = v.getListaAristas();
                foreach (CArista a in lA)
                {
                    a.color=Color.Black;
                    a.marcada = false;
                }
            }
            int componentes = 0;
            foreach (CVertice v in listV)
            {
                if (v.marcado == false)
                {
                    componentes++;
                    bpfCF2(v);
                }
            }
            //Para colorear Aristas fuera del componente
            List<CArista> lAux = new List<CArista>();
            foreach (CVertice v in listV)
            {
                lAux = v.getListaAristas();
                foreach (CArista a in lAux)
                {
                    if (Color.DodgerBlue != a.color)
                        a.color=Color.DarkGray;
                }
            }

            //Restauramos Aristas/
            foreach (CVertice v in listV)
            {
                lA = v.getListaAristas();
                foreach (CArista a in lA)
                {
                    a.color=Color.Black;
                }
                lA.Clear();
            }
            foreach (CArista a in lAR)
            {
                CArista arista = new CArista(a.v1, a.v2,a.color,a.ancho);
                arista.Costo=a.Costo;
                this.agregaArista(arista);
            }
            return componentes;
        }

        public override string centroGrafo()
        {
            String cad ="";
            CVertice v = null;
            int val1 = 0, val2 = 0, centro = 999999, columna = 0, col = 0;
            int[,] mFloyd = null;

            mFloyd = calculaFloyd();

            if (mFloyd != null)
            {
                int n = (int)Math.Sqrt(mFloyd.Length);
                List<int> lint = new List<int>();
                List<int> lintM = new List<int>();

                for (int j = 1; j < n; j++)
                {
                    for (int i = 1; i < n; i++)
                    {
                        val1 = mFloyd[i, j];
                        if (val1 > val2)
                        {
                            val2 = val1;
                            columna = j;
                        }
                    }
                    lint.Add(val2);
                    val2 = 0;
                    lintM.Add(mFloyd[0, columna]);
                }

                columna = 0;
                cad = "Las Excentricidades son:  ";
                foreach (int valor in lint)
                {
                    columna++;
                    if (valor < centro)
                    {
                        col = columna;
                        centro = valor;
                    }
                    if (valor == 999999)
                        cad += "  " + Convert.ToString("infinito");
                    else
                        cad += "  " + Convert.ToString(valor);
                }

                v = dameVertice(mFloyd[0, col]);

                if (v != null)
                {
                    v.Color = Color.DarkOrange;
                    cad += "\n\n Por lo tanto el Vertice: " + Convert.ToString(v.id) + " es el centro con excentricidad de: " + Convert.ToString(centro);
                }
                else
                    cad = "No hay Centro";
            }
            return cad;
        }

        public override void Dijkstra(int[,] C, int ivi)
        {
            List<CVertice> S = new List<CVertice>();
            List<CVertice> V= ListV;
            List<CVertice> aux = new List<CVertice>();
            CVertice w = null;
            int n= ListV.Count;
            int[] P = new int[n];
            int[] D = new int[n];
            int[] arr= new int[n];

            S.Add(ListV[ivi]);//S.Add(ListV[0]);
            foreach (CVertice v in V)
            {
                v.marcado = false;
            }

            for (int i = 0; i < n; i++) //for (int i = 1; i < n; i++)
            {
                D[i] = C[ivi, i];//D[i]=C[0,i];
            }
            for (int i = 0; i < n; i++)
            {
                P[i] = ivi+1;//P[i] = 1;
                arr[i] = V[i].id;
            }
            int posW=-1,posV=-1;
            int menor=9999999;
            for (int i = 1; i < n-1; i++)
            {
                menor = 9999999;
                aux.Clear();
                foreach (CVertice v in V)
                {
                    if (!S.Contains(v))
                    {
                        v.marcado = true;
                        aux.Add(v);
                        for (int j = 0; j < n; j++)
                        {
                            if (arr[j] == v.id)
                            {
                                posV = j;
                                break;
                            }
                        }
                        if (menor > D[posV])
                        {
                            menor = D[posV];
                            w = v;
                            
                        }
                    }
                    else
                    {
                        v.marcado = false;
                    }
                }
                w.marcado = false;
                S.Add(w);
                CArista a = null, b = null;
                //posW=-1;
                posV=-1;
                int temp=-1;
                foreach (CVertice v in V)
                {
                    if (v.marcado)
                    {
                        a = v.dameAristaCon(w);
                        b = w.dameAristaCon(v);
                        if (a != null || b != null)
                        {
                            for(int j=0;j<n; j++)
                            {
                                if(arr[j]==v.id)
                                {
                                    posV=j;
                                    break;
                                }
                            }

                            for (int j = 0; j < n; j++)
                            {
                                if (arr[j] == w.id)
                                {
                                    posW = j;
                                    break;
                                }
                            }

                            temp=D[posV];
                            D[posV]= min(D[posV], D[posW]+ C[posW,posV]);
                            if(temp!=D[posV])
                            {
                                P[posV]=w.id;
                            }
                        }
                    }
                }
            }
            muestraCaminos(P, D, arr, n, ivi);
        }

        private void muestraCaminos(int[] P, int[] D, int[] arr, int n, int ivi)
        {
            List<int> camino;
            List<string> cam = new List<string>();
            string cad;
            int i, vini = ivi+1;

            for (i = 0; i < n; i++)
            {
                cad = "";
                camino = new List<int>();
                int vfin = arr[i];
                camino.Add(vfin);
                int w = P[i];
                while (vini != w)
                {
                    camino.Add(w);
                    w = P[w-1];
                }
                camino.Add(vini);
                cad += vini + " - " + vfin + "          ";
                for(int c=camino.Count-1; c>=0; c--)
                    cad += camino[c] + "-";
                cad += "                " + D[i];
                cam.Add(cad);
            }
            cad="Vertices   Camino          Longitud\n";
            foreach (string s in cam)
                cad += s + "\n";
            MessageBox.Show(cad);
        }

        private int min(int x, int y)
        {
            int minimo = x;
            if (x > y)
            {
                minimo = y;
            }
            return minimo;
        }

        public override void Warshall(int[,] C)
        {
            int n= ListV.Count;
            int[,] D = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    D[i, j] = C[i, j];
                }
            }

            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        D[i, j] =  D[i,j] | D[i, k] & D[k, j];
                    }
                }
            }
            
            String cad = "Cerradura Transistiva\n\n      ";
            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    cad += D[i, j].ToString() + " ";
                }
                cad += "\n      ";
            }

            System.Windows.Forms.MessageBox.Show(cad);
        }
        public override bool BosqueAbarcadorProfundidad()
        {            
            bool GDA=true;
            respalda();
            List<CArista> lA;
            //Inicializacion
            tiempo = 0;
            foreach (CVertice v in listV)
            {
                v.id2 = 0;
                v.marcado = false;
                lA = v.getListaAristas();
                foreach (CArista a in lA)
                {
                    a.color=Color.Black;
                    a.marcada = false;
                }
            }
            foreach (CVertice v in listV)
            {
                if (v.marcado == false)
                {
                    bpf(v);
                }
            }
            //Coloreado de aristas que se eliminarian
            foreach (CVertice v in listV)
            {
                lA = v.getListaAristas();
                foreach (CArista a in lA)
                {
                    //Aristas de Cruze
                    if (a.v1.id2 >= a.v2.id2)
                        a.color=Color.DarkGray;
                    //Aristas de Avance
                    if (a.v1.id2 <= a.v2.id2 && a.color == Color.Black)
                        a.color=Color.Green;
                }
            }

            //Aristas de retroceso
            foreach (CVertice v in listV)
            {
                lA = v.getListaAristas();
                foreach (CArista a1 in lA)
                {
                    if (a1.v1.id2 >= a1.v2.id2 && a1.color == Color.DarkGray)
                    {
                        if (a1.v2.hayCaminoCon(a1.v1))
                        {
                            a1.color = Color.Yellow;
                            GDA = false;
                        }
                    }
                }
            }
            return GDA;
        }
        public void bpf(CVertice v)
        {
            v.marcado = true;
            v.id2 = tiempo;
            tiempo++;

            List<CArista> listA = ordena(v.dameRelacionesSM(), 0);
            //Hay que ordenar la listA de menor a Mayor
            foreach (CArista a in listA)
            {
                if (a.v2.marcado == false)
                {
                    //Aristas de arbol
                    a.color=Color.DodgerBlue;
                    bpf(a.v2);
                }
            }
        }
        public override int ComponentesFuertes()
        {           
            List<CArista> lA;
            respalda();
            //Inicializacion
            tiempo = 1;
            foreach (CVertice v in listV)
            {
                v.id2 = 0;
                v.marcado = false;
                lA = v.getListaAristas();
                foreach (CArista a in lA)
                {
                    a.color=Color.Black;
                    a.marcada = false;
                }
            }

            foreach (CVertice v in listV)
            {
                if(v.marcado == false)
                    bpfCF(v);
            }            

            ///Invertimos Aristas
            List<CArista> lA2 = new List<CArista>();
            foreach (CVertice v in listV)
            {
                lA = v.getListaAristas();  
                foreach (CArista a in lA)
                {
                    lA2.Add(a);  
                }
                lA.Clear();
            }
            foreach (CArista a in lA2)
            {
                this.agregaArista(new CArista(a.v2, a.v1,a.color,a.ancho));
            }
            
            ///Volvemos a inicializar
            tiempo = 1;
            foreach (CVertice v in listV)
            {
                v.id3 = 0;
                v.marcado = false;
                lA = v.getListaAristas();
                foreach (CArista a in lA)
                {
                    a.color=Color.Black;
                    a.marcada = false;
                }
            }
            //Volvemos a hacer una busqueda en profundidad
            int componentes = 0;
            CVertice vert = listV[0];
            while (!hayVerticeSinMArca())
            {
                componentes++;
                bpf2(dameVertconMayorId2());

            }
            //Para colorear Aristas fuera del componente
            List<CArista> lAux = new List<CArista>();
            foreach (CVertice v in listV)
            {
                lAux = v.getListaAristas();
                foreach(CArista a in lAux)
                {
                    if (Color.DodgerBlue != a.color)
                        a.color = Color.White;//a.color=Color.DarkGray;
                }
            }
            return componentes;            
        }
        public bool hayVerticeSinMArca()
        {
            int marcas = 0;
            foreach (CVertice v in listV)
            {
                if (v.marcado == true)
                    marcas++;
            }
            if (marcas == listV.Count)
                return true;
            else
                return false;
        }
        public CVertice dameVertconMayorId2()
        {
            CVertice vertice = null;
            if (listV.Count != 0)
            {
                foreach (CVertice v in listV)
                {
                    if (v.marcado == false)
                    {
                        vertice = v;
                        break;
                    }
                }
                foreach (CVertice v in listV)
                {
                    if (v.id2 > vertice.id2 && v.marcado == false)
                        vertice = v;
                }
            }
            return vertice;
        }
        public void bpf2(CVertice v)
        {
            v.marcado = true;
            v.id3 = tiempo;
            tiempo++;

            List<CArista> listA = ordena(v.dameRelacionesSM(), 0);
            //Hay que ordenar la listA de menor a Mayor
            foreach (CArista a in listA)
            {
                if (a.v2.marcado == false)
                {
                    //Aristas de arbol
                    a.color=Color.DodgerBlue;
                    bpf2(a.v2);
                }
            }
        }        

        public override void Coloreados()
        {
            int i = 0;
            foreach (CVertice v in ListV)
            {
                v.Coloreado = 0;
            }

            foreach (CVertice v in ListV)
            {
                if (v.Coloreado == 0)
                {
                    v.Coloreado++;
                    for (i = 0; i < v.getListaAristas().Count; i++)
                    {
                        if (v.getListaAristas()[i].v2.Coloreado == 0)
                        {
                            v.Coloreado++;
                            //i = -1;
                        }
                    }
                }
            }

            int vcrom = 0;
            foreach (CVertice v in ListV)
            {
                if (v.Coloreado > vcrom)
                {
                    vcrom = v.Coloreado;
                }
            }

            foreach (CVertice v in ListV)
            {
                v.setColor(v.Coloreado * (765 / (vcrom + 1)));
            }

            MessageBox.Show("El valor Cromatico es: " + Convert.ToString(vcrom));

        }


    }

}
