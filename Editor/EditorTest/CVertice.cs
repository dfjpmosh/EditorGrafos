using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace EditorTest
{
    [Serializable]
    class CVertice
    {
        public Point pos;
        public int id;
        public int id2;
        public int id3;
        public char idL;
        public int diam;
        public int grueso;        
        private Color color;
        public Color colorContorno;
        public bool marcado = false;
        List<CArista> listA;
        public int grado;
        public int degInf;
        public int degExt;
        Rectangle rect;
        private int coloreado;
        List<int> gradoVecinos;
        List<int> gradoVecinosCopia;
        //CVertice hijo;
        List<CVertice> arcosRetro, hijo;

        int num;
        int bajo;
        //private CGradoVertice deg;

        //Constructor
        public CVertice(Point p,char idLetra, int identificador, int d,Color c, Color colorC, int anchoContorno)
        {            
            pos = p;
            id = identificador;
            idL = idLetra;
            diam = d;
            color= c;
            grueso = anchoContorno;
            colorContorno = colorC;
            listA = new List<CArista>();
            gradoVecinos = new List<int>();
            gradoVecinosCopia = new List<int>();
            grado = 0;
            //deg = new CGradoVertice();
            id2 = 0;
            id3 = 0;
            degInf=0;
            degExt=0;
            coloreado = 0;
            num = -1;
            bajo = -1;
            //hijo = null;
            hijo = new List<CVertice>();
            arcosRetro = new List<CVertice>();
        }

        public void cargaGradosVecinos()
        {
            gradoVecinos = new List<int>();
            gradoVecinosCopia = new List<int>();
            foreach (CArista a in listA)
            {
                gradoVecinos.Add(a.v2.grado);
                gradoVecinosCopia.Add(a.v2.grado);
            }
        }

        public List<int> GradosVecinos
        {
            get { return gradoVecinos; }
            set { gradoVecinos = value; }
        }

        public List<int> recuperaGradosVecinos()
        {
            return gradoVecinosCopia;
        }

        public List<CVertice> ArcosRetro
        {
            get { return arcosRetro; }
            set { arcosRetro = value; }
        }

        public int Bajo
        {
            get { return bajo; }
            set { bajo = value; }
        }

        public int Num
        {
            get { return num; }
            set { num = value; }
        }

        public List<CVertice> Hijo
        {
            get { return hijo; }
            set { hijo = value; }
        }

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        public void setColor(int valor)
        {
            /** El rango de colores va de 0 a 765 **/
            int r = valor, g = 0, b = 0;
            if (r >= 200 && r >= 0)
            {
                r = 150;
                g = valor - 200;
                valor = g;
            }
            if (g >= 200 && g >= 0)
            {
                g = 180;
                b = valor - 200;
                valor = b;
            }
            if (b >= 200 && b >= 0)
            {
                b = 200;
            }
            color = Color.FromArgb(r + 50, g + 50, b + 50);
        }

        public int numAristas()
        {
            return listA.Count;
        }

        public int Coloreado
        {
            get { return coloreado; }
            set { coloreado = value; }
        }
        
        /////VERTICE
        //checa si este vertice se ha seleccionado
        public bool Intersect(Point p)
        {
            rect = new Rectangle(pos.X - diam / 2, pos.Y - diam / 2, diam, diam);
            return rect.IntersectsWith(new Rectangle(p,new Size(1,1)));
        }
        //dibujate vertice con sus respetivas aristas
        public void dibujate(Graphics g, int estilo)
        {
            Font font = new Font("Arial", 10);
            SolidBrush brocha = new SolidBrush(color);
            Pen pen = new Pen(colorContorno, grueso );
            String num = id.ToString();

            foreach (CArista arista in listA)
            {
                //dibujate arista
                arista.dibujate(g, estilo, diam);
            }

            //Contorno de Nodo y Relleno
            g.DrawEllipse(pen, pos.X - diam / 2, pos.Y - diam / 2, diam, diam);
            g.FillEllipse(brocha, pos.X - diam / 2, pos.Y - diam / 2, diam, diam);

            //Num Id 
            if( true )
                g.DrawString(num, font, Brushes.Black, pos.X - 5, pos.Y - 5);
            //else
              //  g.DrawString(idL.ToString(), font, Brushes.Black, pos.X - 5, pos.Y - 5);
            
            //grado del vertice
            //if (estilo == 0 && listA.Count > 0)
              //  g.DrawString(grado.ToString(), font, Brushes.Black, pos.X - 20, pos.Y + diam);
            /*if(estilo == 1 && listA.Count > 0)
            {
                g.DrawString("degExt "+  degExt.ToString(), font, Brushes.Black, pos.X - 5, pos.Y - c.DIAM);
                g.DrawString("degInt " + degInf.ToString(), font, Brushes.Black, pos.X - 5, pos.Y + c.DIAM);
            }*/
            
        }
        //elimina las arista con este vertice
        public void eliminaRelacionesCon(CVertice vertice)
        {
            List<CArista> relaciones = new List<CArista>();

            /*eliminamos las aristas que tengan relacion con el vertice v1(este),
             * v2 es el otro vertice por lo tanto eliminaremos v2 y 
             * decrementaremos el numeros de aristas de los v1*/
            foreach (CArista a in listA)
            {
                if (a.v2 == vertice)
                {
                    relaciones.Add(a);
                }
            }
            //Ahora eliminaremos la lista
            foreach (CArista a in relaciones)
            {
                listA.Remove(a);
            }
            //relaciones.Clear();

        }

        public void desmarcaAristas()
        {
            foreach (CArista a in listA)
            {
                a.marcada = false;
            }
        }

        ////ARISTA
        //Agrega Arista a este vertice
        public void agregaArista(CArista arista)
        {
            listA.Add(arista);
            grado++;
            //deg.incrementaGrado();
            //deg.agregaVecino(arista.v2.deg);
            if(arista.v1.id == id || arista.v1.idL==idL)
            {
                //degInf++;
                degExt++;                
            }
            if (arista.v2.id == id || arista.v2.idL == idL)
            {
                //degExt++;                
                degInf++;
            }
            
        }

        /*public CGradoVertice getGradoVertice()
        {
            return ;
        }*/

        public bool todosMarcados()
        {
            foreach (CArista ari in listA)
            {
                if (ari.v2.marcado == false)
                    return false;
            }
            return true;
        }

        public void desmarcaVecinos()
        {
            foreach (CArista ari in listA)
            {
                ari.v2.marcado = true;
            }
        }

        //elimina aristas de este vertice
        public bool eliminaArista(Point pos)
        {
            CArista a;
            for (int i = 0; i < listA.Count; i++)
            {
                a = listA[i];//para cada arista de esta lista se elimina
                if (a.v1 == a.v2)
                {
                    if(a.buscaOreja(pos, this.pos, diam) == true)
                    {
                        listA.Remove(a);
                        grado--;
                        degInf--;
                        degExt--;
                        return true;
                    }
                }
                else
                    if (a.curva)
                    {
                        if (a.buscaBezier(pos) == true)
                        {
                            listA.Remove(a);
                            grado--;
                            degInf--;
                            degExt--;
                            return true;
                        }
                    }
                    else
                        if (a.intersectaCon(pos)==true)
                        {
                            listA.Remove(a);
                            grado--;
                            degInf--;
                            degExt--;
                            return true;
                        }

            }
            return false;
        }

        public bool buscaArista(Point pos)
        {
            CArista a;
            for (int i = 0; i < listA.Count; i++)
            {
                a = listA[i];//para cada arista de esta lista se elimina
                if (a.v1 == a.v2)
                {
                    if (a.buscaOreja(pos, this.pos, diam) == true)
                    {
                        return true;
                    }
                }
                else
                    if (a.curva)
                    {
                        if (a.buscaBezier(pos) == true)
                            return true;
                    }
                    else
                    {
                        if (a.intersectaCon(pos) == true)
                            return true;
                    }
            }
            return false;
        }

        public CArista dameArista(Point pos)
        {
            CArista a;
            for (int i = 0; i < listA.Count; i++)
            {
                a = listA[i];//para cada arista de esta lista se elimina
                if (a.intersectaCon(pos) == true)
                {
                    return a;
                }
            }
            return null;
        }

        public CArista dameAristaCon(CVertice v)
        {
            foreach (CArista a in listA)
            {
                if (a.v2 == v)
                    return a;
            }
            return null;
        }
        public CArista dameAristaCon(int id)
        {
            foreach (CArista a in listA)
            {
                if (a.v2.id == id)
                    return a;
            }
            return null;
        }

        public CArista dameAristaSinMarca()
        {
            List<CArista> lA = new List<CArista>();
            CArista arista = null;
            foreach (CArista a in listA)
            {
                if (!a.marcada)
                {
                    lA.Add(a);
                    arista = lA[0];
                }
            }

            if (arista != null)
            {
                foreach (CArista a2 in lA)
                {
                    if (arista.v2.getListaAristas().Count < a2.v2.getListaAristas().Count)
                        arista = a2;
                }
                foreach (CArista a2 in lA)
                {
                    if (arista.v2.numMarcas() > a2.v2.numMarcas())
                        arista = a2;
                }
            }
            return arista;
        }

        public int numMarcas()
        {
            int marcas = 0;
            foreach (CArista a in listA)
            {
                if (a.marcada)
                    marcas++;
            }
            return marcas;
        }

        public List<CArista> getListaAristas()
        {
            return listA;
        }

        public List<CArista> dameRelacionesSM()
        {
            List<CArista> lA = new List<CArista>();
            foreach (CArista a in listA)
            {
                if (!a.marcada)
                    lA.Add(a);
            }
            return lA;
        }

        //Exclusiva para Aristas de retroceso
        public bool hayCaminoCon(CVertice v2)
        {
            List<CArista> pA = new List<CArista>();//El resultado esta en pA contiene las aristas que dibujan el camino
            List<CArista> aA; //Auxiliar de aristas para checar por cada vertice
            List<CVertice> aV1 = new List<CVertice>(); //auxiliar de vertices aV1 para comprobar en cada ciclo
            List<CVertice> aV2 = new List<CVertice>(); //Para almacenar los  vertices que pasaran a ser aV1 
            int watchdog = 0;

            List<CArista> auxA = new List<CArista>();

            aV1.Add(this);//Inicializamos con el primer vertice
            while (true)
            {
                //Recorremos la lista de Vertices  que tuvo relacion con el vertice anterior
                for (int i = 0; i < aV1.Count; i++)
                {
                    //Importante liberar esta lista cada ciclo
                    auxA.Clear();
                    //Pedimos relaciones con el vertice y las guardamos en aA
                    aA = aV1[i].dameRelacionesSM();
                    //Seleccionamos solo las del color q nos interesa                
                    foreach (CArista a in aA)
                    {
                        if (a.color == Color.DodgerBlue)
                            auxA.Add(a);
                    }
                    //Y se las asignamos aA y continua todo normalmente
                    aA = auxA;

                    //Recorremos las relaciones por cada vertice 
                    foreach (CArista a in aA)
                    {
                        //Si un vertice a.v2 apunta a un destino
                        //Quiere decir que si se encontro el destino
                        if (a.v2 == v2 && a.v2 != this)
                        {
                            //hacemos v2 a v1 para volver a calcular es un estilo recursivo
                            v2 = a.v1;
                            //Limpiamos los datos para evitar que se copie la basura de v2 a v1
                            aV1.Clear();
                            aV1.Add(this);
                            aV2.Clear();
                            //Copiamos aV1 en aV2
                            foreach (CVertice v in aV1)
                            {
                                aV2.Add(v);
                            }
                            ///////////////////
                            watchdog = 0;
                            break;

                        }
                        //Agregamos todos los vertices a aV2 para proximo ciclo
                        aV2.Add(a.v2);
                    }
                }

                //Limpiamos el auxiliar de lista de vertices1 (aV1)  
                aV1.Clear();
                //Copiamos aV2 en aV1
                foreach (CVertice v in aV2)
                {
                    aV1.Add(v);
                }
                //Y limpiamos aV2
                aV2.Clear();

                watchdog++;
                if (watchdog > 10)
                    break;

                if (v2 == this)
                {
                    return true;
                }
            }
            return false;
        }

     }
}
