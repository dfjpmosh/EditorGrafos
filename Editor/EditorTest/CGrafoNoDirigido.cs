using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;


namespace EditorTest
{
    [Serializable]
    class CGrafoNoDirigido: CGrafo
    {
        private int tiempo;
        public CGrafoNoDirigido():base()
        { 

        }
        public CGrafoNoDirigido(CGrafo g)
        {
            listV = g.ListV;
//            configuracion = g.Config;
        }
        public override void muevete(Point p1, Point p2)
        {
            int dx = p2.X - p1.X;
            int dy = p2.Y - p1.Y;

            foreach (CVertice v in listV)
            {
                v.pos.X += dx;
                v.pos.Y += dy;
            }

        }
        public override bool esDirigigo()
        {
            return false;
        }
        public override void dibujaGrafo(Graphics g, bool activo)
        {
            foreach (CVertice vertice in listV)
            {
                vertice.dibujate(g, 0);
                if (!activo)
                {
                    vertice.dibujate(g, 0);
                }
            }
        }
        public override void agregaArista(CArista arista)
        {
            CVertice v1 = arista.v1;
            CVertice v2 = arista.v2;
            v2.agregaArista(new CArista(v2,v1,arista.color,arista.ancho));
            v1.agregaArista(arista);
        }
        //Elimina Arista
        public override void eliminaArista(Point pos)
        {
            foreach (CVertice v in listV)
            {
                v.eliminaArista(pos);

            }
        }

        public override int numeroAristas()
        {
            int num = 0;
            foreach (CVertice v in listV)
            {
                num += v.getListaAristas().Count;
            }
            return num/2;
        }

        
   /*     public override int[,] calculaFloyd()
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
        }*/

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

        public override bool Colorario()
        {
            if (numVertices() >= 3)
            {
                if (numeroAristas() <= (3 * numVertices()) - 6)
                {
                    MessageBox.Show("Es plano.", "Corolario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (numeroAristas() <= (2 * numVertices() - 4))
                    {
                        MessageBox.Show("Es plano.", "Corolario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No es plano.", "Corolario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Hay pocos vertices deben de haber minimo 3", "Corolario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return false;
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
                if( v.Coloreado== 0 )
                {
                    v.Coloreado++;
                    for(i=0;i<v.getListaAristas().Count;i++)
                    {
                        if (v.getListaAristas()[i].v2.Coloreado == v.Coloreado)
                        {
                            v.Coloreado++;
                            i = -1;
                        }
                    }
                }
            }

            int vcrom=0;
            foreach (CVertice v in ListV)
            {
                if(v.Coloreado>vcrom)
                {
                    vcrom=v.Coloreado;
                }
            }            

            foreach (CVertice v in ListV)
            {               
                v.setColor(v.Coloreado*(765 / (vcrom + 1)));
            }

            MessageBox.Show("El valor Cromatico es: " + Convert.ToString(vcrom));

        }
        public override void contraccionKuartowski(CVertice v)
        {
            CArista a;
            //List<CArista> elimAri = new List<CArista>();
            CVertice vU, vV;
            foreach (CVertice vert in listV)
            {
                a = vert.dameArista(v.pos);
                if (a != null)
                {
                    vU = a.v1;
                    vV = a.v2;
                    eliminaArista(v.pos);                    
                    agregaVertice(v);
                    for (int i = 0; i < vU.getListaAristas().Count; i++)
                    { 
                        CArista ari=vU.getListaAristas()[i];
                        agregaArista(new CArista(v, ari.v2, ari.color, ari.ancho));
                        ari.v2.grado--;
                    }
                    for (int i = 0; i < vV.getListaAristas().Count; i++)
                    {
                        CArista ari = vV.getListaAristas()[i];
                        agregaArista(new CArista(v, ari.v2, ari.color, ari.ancho));
                        ari.v2.grado--;
                    }
                    eliminaVertice(vU);
                    eliminaVertice(vV);
                    break;
                }
            }
        }

        public override void eliminaKuartowski(Point pos)
        {
            eliminaArista(pos);
        }

        public override void subdivisionKuartowski(CVertice v)
        {
            CArista a;
            foreach (CVertice vert in listV)
            {
                a = vert.dameArista(v.pos);
                if (a != null)
                {
                    eliminaArista(v.pos);
                    agregaVertice(v);
                    agregaArista(new CArista(a.v1,v,a.color,a.ancho));
                    agregaArista(new CArista(v,a.v2,a.color,a.ancho));                    
                    break;
                }
            }
        }

        public override bool kuratowsky_k33()
        {
            desmarcaAristas();
            int n = listV.Count;
            bool exit = false;
            CVertice vert1Grupo1, vert2Grupo1, vert3Grupo1;
            CVertice vert1Grupo2, vert2Grupo2, vert3Grupo2;

            for (int it1 = 0; it1 < n; it1++)
            {
                vert1Grupo1 = listV[it1];
                for (int it2 = 0; it2 < n; it2++)
                {
                    vert2Grupo1 = listV[it2];
                    for (int it3 = 0; it3 < n; it3++)
                    {
                        vert3Grupo1 = listV[it3];
                        for (int cit1 = 0; cit1 < n; cit1++)
                        {
                            vert1Grupo2 = listV[cit1];
                            for (int cit2 = 0; cit2 < n; cit2++)
                            {
                                vert2Grupo2 = listV[cit2];
                                for (int cit3 = 0; cit3 < n; cit3++)
                                {
                                    vert3Grupo2 = listV[cit3];
                                    if (
                                        vert1Grupo1.numAristas() >= 3 &&
                                        vert2Grupo1.numAristas() >= 3 &&
                                        vert3Grupo1.numAristas() >= 3 &&
                                        vert1Grupo2.numAristas() >= 3 &&
                                        vert2Grupo2.numAristas() >= 3 &&
                                        vert3Grupo2.numAristas() >= 3
                                        )
                                        if (
                                            recorrido(vert1Grupo1, vert1Grupo2) &&
                                            recorrido(vert1Grupo1, vert2Grupo2) &&
                                            recorrido(vert1Grupo1, vert3Grupo2) &&
                                            recorrido(vert2Grupo1, vert1Grupo2) &&
                                            recorrido(vert2Grupo1, vert2Grupo2) &&
                                            recorrido(vert2Grupo1, vert3Grupo2) &&
                                            recorrido(vert3Grupo1, vert1Grupo2) &&
                                            recorrido(vert3Grupo1, vert2Grupo2) &&
                                            recorrido(vert3Grupo1, vert3Grupo2) &&
                                            vert1Grupo1.numMarcas() == 3 &&
                                            vert2Grupo1.numMarcas() == 3 &&
                                            vert3Grupo1.numMarcas() == 3 &&
                                            vert1Grupo2.numMarcas() == 3 &&
                                            vert2Grupo2.numMarcas() == 3 &&
                                            vert3Grupo2.numMarcas() == 3
                                        )
                                        {
                                            exit = true;
                                            foreach (CVertice v in listV)
                                            {

                                                if (v != vert1Grupo1 && v != vert2Grupo1 && v != vert3Grupo1 && v != vert1Grupo2 && v != vert2Grupo2 && v != vert3Grupo2)
                                                {
                                                    if (v.numMarcas() > 2)
                                                        exit = false;
                                                }
                                            }
                                            if (exit)
                                                if (MessageBox.Show("No Plano, porque tiene K3,3.", "Planaridad Kuratowski",
                                                        MessageBoxButtons.OK) == DialogResult.OK)
                                                {
                                                    return true;
                                                }

                                        }
                                        else
                                            desmarcaAristas();

                                }

                            }

                        }
                    }
                }
            }
            return false;
        }
        public override bool kuratowsky_k5()
        {
            desmarcaAristas();
            int n = listV.Count;
            bool exit = false;
            CVertice v1, v2, v3, v4, v5;

            for (int it1 = 0; it1 < n; it1++)
            {
                v1 = listV[it1];
                for (int it2 = 0; it2 < n; it2++)
                {
                    v2 = listV[it2];
                    for (int it3 = 0; it3 < n; it3++)
                    {
                        v3 = listV[it3];
                        for (int it4 = 0; it4 < n; it4++)
                        {
                            v4 = listV[it4];
                            for (int it5 = 0; it5 < n; it5++)
                            {
                                v5 = listV[it5];
                                if (v1.numAristas() > 3 && v2.numAristas() > 3 && v3.numAristas() > 3 &&
                                    v4.numAristas() > 3 && v5.numAristas() > 3)
                                {
                                    if (
                                        recorrido(v1, v2) &&
                                        recorrido(v1, v3) &&
                                        recorrido(v1, v4) &&
                                        recorrido(v1, v5) &&
                                        recorrido(v2, v3) &&
                                        recorrido(v2, v4) &&
                                        recorrido(v2, v5) &&
                                        recorrido(v3, v4) &&
                                        recorrido(v3, v5) &&
                                        recorrido(v4, v5) &&

                                        v1.numMarcas() == 4 &&
                                        v2.numMarcas() == 4 &&
                                        v3.numMarcas() == 4 &&
                                        v4.numMarcas() == 4 &&
                                        v5.numMarcas() == 4

                                    )
                                    {
                                        exit = true;
                                        foreach (CVertice v in listV)
                                        {
                                            if (v != v1 && v != v2 && v != v3 && v != v4 && v != v5)
                                            {
                                                if (v.numMarcas() > 2)
                                                    exit = false;
                                            }                                            
                                        }

                                        if (exit)
                                            if (MessageBox.Show("No Plano, porque tiene K5.", "Planaridad Kuratowski",
                                                    MessageBoxButtons.OK) == DialogResult.OK)
                                            {
                                                return true;
                                            }
                                    }
                                    else
                                        desmarcaAristas();
                                }
                            }

                        }

                    }
                }
            }
            return false;
        }

        public bool recorrido(CVertice v1, CVertice v2)
        {
            List<CArista> pA = new List<CArista>();//El resultado esta en pA contiene las aristas que dibujan el camino
            List<CArista> aA; //Auxiliar de aristas para checar por cada vertice
            List<CVertice> aV1 = new List<CVertice>(); //auxiliar de vertices aV1 para comprobar en cada ciclo
            List<CVertice> aV2 = new List<CVertice>(); //Para almacenar los  vertices que pasaran a ser aV1 
            int watchdog = 0;

            if (listV.Contains(v1) && listV.Contains(v2) && v1 != v2)
            {
                aV1.Add(v1);//Inicializamos con el primer vertice
                while (true)
                {
                    //Recorremos la lista de Vertices  que tuvo relacion con el vertice anterior
                    for (int i = 0; i < aV1.Count; i++)
                    {
                        //Pedimos relaciones con el vertice y las guardamos en aA
                        aA = aV1[i].dameRelacionesSM();
                        //Recorremos las relaciones por cada vertice 
                        foreach (CArista a in aA)
                        {
                            //Si un vertice a.v2 apunta a un destino
                            //Quiere decir que si se encontro el destino
                            if (a.v2 == v2 && a.v2 != v1)
                            {
                                //Coloreamos dos aristas porque es no dirigido
                                //a.v2.dameAristaCon(aV1[i]).setColor(Color.DarkGray);
                                //a.setColor(Color.DarkGray);

                                //Guardamos el camino de Aristas en pA
                                pA.Add(a.v2.dameAristaCon(aV1[i]));
                                pA.Add(a);

                                //hacemos v2 a v1 para volver a calcular es un estilo recursivo
                                v2 = a.v1;
                                //Limpiamos los datos para evitar que se copie la basura de v2 a v1
                                aV1.Clear();
                                aV1.Add(v1);
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
                    if (watchdog > 9)
                        break;


                    if (v2 == v1)
                    {
                        foreach (CArista a in pA)
                            a.marcada = true;
                        return true;
                    }

                }
            }
            return false;
        }

        public void desmarcaAristas()
        {
            foreach (CVertice v in listV)
            {
                v.desmarcaAristas();
            }
        }

        public override void gradoNodos()
        {
            string grados = "";
            int cont = 0;
            foreach (CVertice v in listV)
            {
                cont = 0;
                foreach (CArista a in v.getListaAristas())
                {
                    if (a.v1.id == v.id)
                    {
                        cont++;
                    }
                }
                v.grado = cont;
                grados += "Deg (" + v.id.ToString() + ")= " + cont.ToString() + ".\n";
            }

            MessageBox.Show(grados, "Grados de los Nodos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        public override void matrizIncidencia()
        {
            int[,] mInc = new int[numVertices(), numeroAristas()];

            for (int i = 0; i < numVertices(); i++)
                for (int j = 0; j < numeroAristas(); j++)
                    mInc[i, j] = 0;

            for (int i = 0; i < numVertices(); i++)
            {
                for (int j = 0; j < numeroAristas(); j++)
                {
                    foreach (CArista corre in listV[i].getListaAristas())
                    {
                        if (listV[i] == corre.v1)
                        {
                            mInc[i, j] = corre.v1.id;
                        }
                    }
                }
            }
        }

        public int componentes()
        {
            int res = 0;
            List<CArista> lA;
            //Inicializacion////////////
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
            bpfCF(listV[0]);

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

            foreach (CVertice v in listV)
            {
                if (v.marcado == false)
                {
                    res++;
                    bpfCF2(v);
                }
            }


            foreach (CVertice v in listV)
            {
                v.marcado = false;
            }
            return res;
        }
        void bpfCF(CVertice v)
        {

            v.marcado = true;
            List<CArista> listA = ordena(v.dameRelacionesSM(), 0);
            //Hay que ordenar la listA de menor a Mayor
            foreach (CArista a in listA)
            {
                if (a.v2.marcado == false)
                {
                    //Aristas de arbol
                    //a.setColor(Color.DodgerBlue);
                    bpfCF(a.v2);
                }
            }
            v.id2 = tiempo;
            tiempo++;
        }
        void bpfCF2(CVertice v)
        {

            v.marcado = true;
            List<CArista> listA = ordena(v.dameRelacionesSM(), 1);
            //Hay que ordenar la listA de menor a Mayor
            foreach (CArista a in listA)
            {
                if (a.v2.marcado == false)
                {
                    //Aristas de arbol
                    //a.setColor(Color.DodgerBlue);
                    bpfCF2(a.v2);
                }
            }
        }

        List<CArista> ordena(List<CArista> listA, int criterio)
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

        public override void dibujaCamino(Graphics g, String camino, int iter)
        {
            List<int> lnum = new List<int>();
            string[] str2 = camino.Split(',');
            foreach (string str1 in str2)
            {
                lnum.Add(Convert.ToInt32(str1));
            }

            if (lnum.Count - 1 > iter)
            {
                listV[lnum[iter]].dameAristaCon(listV[lnum[iter + 1]]).marcada = true;
                listV[lnum[iter + 1]].dameAristaCon(listV[lnum[iter]]).marcada = true;
            }
            else
            {
                foreach (CVertice vert in listV)
                {
                    List<CArista> aristas;
                    aristas = vert.getListaAristas();
                    foreach (CArista arista in aristas)
                    {
                        arista.marcada = false;
                    }
                }
            }
        }


        public override bool tieneCamino()
        {
            int tolerancia = 0; //Si permanece en Cero hay Circuito
            foreach (CVertice v in listV)
            {
                if (v.getListaAristas().Count % 2 != 0)
                {
                    tolerancia++;
                    if (tolerancia > 2)
                    {
                        System.Windows.Forms.MessageBox.Show("No es Euler");
                        return false;
                    }
                }
                if (v.getListaAristas().Count == 0)
                {
                    return false;
                }
                int var = componentes();
                if (var > 1)
                {
                    System.Windows.Forms.MessageBox.Show("Grafo No conectado");
                    return false;
                }

            }
            return true;  //Si hay Caminos
        }
        public override bool tieneCircuito()
        {

            foreach (CVertice v in listV)
            {
                if (v.getListaAristas().Count % 2 != 0)
                {
//                    System.Windows.Forms.MessageBox.Show("No es Euler");
                    return false;
                }

                if (v.getListaAristas().Count == 0)
                {
  //                  System.Windows.Forms.MessageBox.Show("No es Euler");
                    return false;
                }

            }
            int var = componentes();
            if (var > 1)
            {
    //            System.Windows.Forms.MessageBox.Show("Grafo No conectado");
                return false;
            }
            return true;  //Si hay Caminos   
        }

        public override String calculaEuler(Graphics g)
        {
            CVertice v = listV[0];
            foreach (CVertice vtce in listV)
            {
                if (vtce.getListaAristas().Count % 2 != 0)
                    v = vtce;
            }

            CArista a = v.dameAristaSinMarca();
            //inicializamos cadena que indica el camino
            //con el primer elemento de la lista
            String SubCircuito = "";
            String strCamino = "";

            while (a != null)
            {
                //Buscamos que ya no haya caminos en ningun vertice
                SubCircuito = SubCircuito + (Convert.ToString(v.id));

                //Marcamos la arista de v2 a v1
                a.v2.dameAristaCon(v).marcada = true;
                v = a.v2;
                a.marcada = true;
                a = v.dameAristaSinMarca();

                //Este caso es por si ya ya no tiene salida el recorrido
                // y busca vertices aún con caminos disponibles
                if (a == null)
                {   //Checar
                    SubCircuito = SubCircuito + ", ";
                    SubCircuito = SubCircuito + (Convert.ToString(v.id));
                    foreach (CVertice vt in listV)
                    {
                        a = vt.dameAristaSinMarca();
                        if (a != null)
                        {
                            v = vt;
                            break;
                        }
                    }
                    //Aqui la concatenacion de cadenas
                    //Caso para un solo circuito
                    if (strCamino == "")
                    {
                        strCamino = SubCircuito;
                        SubCircuito = "";
                    }//Caso para mas de un subcircuito
                    else
                    {
                        for (int i = 0; i < strCamino.Length; i++)
                        {   //si strCamino se encuentra un caracter similar
                            //con respecto a camino de cero
                            if (strCamino[i] == SubCircuito[1])
                            {
                                //SubCircuito = SubCircuito.Remove(SubCircuito.Length-3);
                                SubCircuito = SubCircuito.Remove(1, 3);
                                //hacemos una inserccion ordenada de toda la cadena camino
                                strCamino = strCamino.Insert(i + 2, SubCircuito);
                                SubCircuito = "";
                                break;
                            }
                        }

                    }
                }
                SubCircuito = SubCircuito + ", ";
            }

            //Desmarcamos las Aristas
            foreach (CVertice vert in listV)
            {
                List<CArista> aristas;
                aristas = vert.getListaAristas();
                foreach (CArista arista in aristas)
                {
                    arista.marcada = false;
                }
            }

            //Regresamos la cadena del camino
            return strCamino;
        }

        public override void Prim()
        {
            List<CVertice> V = new List<CVertice>();
            List<CVertice> U = new List<CVertice>();
            List<CArista> T = new List<CArista>();
            List<CVertice> tmp = new List<CVertice>();
            tmp = listV;
            Color color = listV[0].getListaAristas()[0].color;
            int ancho = listV[0].getListaAristas()[0].ancho;

            int menor = int.MaxValue;
            CVertice u = null;
            CVertice v = listV[0];

            foreach (CVertice vert in tmp)
            {
                V.Add(vert);
            }
            U.Add(v);
            V.Remove(v);

            while (V.Count != 0)
            {
                foreach (CVertice correU in U)
                {
                    foreach (CVertice correV in tmp)
                    {
                        if (correV.id == correU.id)
                        {
                            foreach (CArista a in correV.getListaAristas())
                            {
                                if (a.Costo < menor && V.Contains(a.v2))
                                {
                                    menor = a.Costo;
                                    v = a.v2;
                                    u = correU;
                                }
                            }
                            break;
                        }
                    }
                }
                U.Add(v);
                V.Remove(v);
                CArista t = new CArista(u, v, color, ancho);
                T.Add(t);
                menor = int.MaxValue;
            }
            string arbol = "T={ ";
            foreach (CArista a in T)
            {
                arbol += " (" + a.v1.id.ToString() + "," + a.v2.id.ToString() + ") ";
            }
            arbol += "}";
            MessageBox.Show(arbol, "Arbol Abarcador de Costo Minimo",MessageBoxButtons.OK);
        }

        public List<CArista> Sort(List<CArista> Q)
        {
            Q.Sort(
                delegate(CArista x, CArista y)
                {
                    return x.Costo.CompareTo(y.Costo);
                }
                );
            return Q;
        }    


        public override void Kruskal()
        {
            List<Componente> C = new List<Componente>();
            List<CArista> Q = new List<CArista>(), T= new List<CArista>();
            List<CVertice> verticesU = new List<CVertice>();
            List<CVertice> verticesV = new List<CVertice>();
            CArista uv = null;
            CVertice u = null, v = null;
            int compU=-1, compV=-1;


            desmarcaAristas();
            foreach (CVertice vert in listV)
            {
                foreach (CArista a in vert.getListaAristas())
                {
                    if (!a.marcada)
                    {
                        a.marcada = true;
                        foreach (CVertice w in listV)
                        {
                            foreach (CArista espejo in w.getListaAristas())
                            {
                                if (espejo.v1 == a.v2 && espejo.v2 == a.v1)
                                {
                                    espejo.marcada = true;
                                }
                            }
                        }
                        Q.Add(a);
                    }
                }
            }
            Q=Sort(Q);
            for (int i = 0; i < listV.Count; i++)
            { 
                C.Add(new Componente(i+1,listV[i]));
            }

            while (T.Count < listV.Count - 1)
            {
                uv = Q[0];
                Q.Remove(uv);
                compU = -1;
                compV = -1;
                foreach (Componente c in C)
                {
                    compU = c.encuentra(uv.v1);
                    if (compU != -1)
                        break;
                }

                foreach (Componente c in C)
                {
                    compV = c.encuentra(uv.v2);
                    if (compV != -1)
                        break;
                }

                if (compU != compV)
                {
                    T.Add(uv);

                    C[compV-1].agregaVertices(C[compU-1].Lista);
                    C[compU-1].vaciaLista();
                }
            }
            string arbol = "T={ ";
            foreach (CArista a in T)
            {
                arbol += " (" + a.v1.id.ToString() + "," + a.v2.id.ToString() + ") ";
            }
            arbol += "}";
            MessageBox.Show(arbol, "Arbol Abarcador de Costo Minimo", MessageBoxButtons.OK);
        }

        public override void RecorridoProfundidad()
        {
            List<CArista> tmp = new List<CArista>();
            List<CVertice> vertices= listV;
            desmarcar();
            CVertice v = null;
            foreach (CVertice aux in vertices)
            {                
                if (!aux.marcado)
                {
                    v = aux;
                    recProfRecursivo(aux, ref tmp);
                }
            }
            string arbolProf = "T={ ";
            foreach (CArista a in tmp)
            {
                arbolProf += " (" + a.v1.id.ToString() + "," + a.v2.id.ToString() + ") ";
            }
            arbolProf += "}";
            MessageBox.Show(arbolProf, "Búsqueda en profundidad", MessageBoxButtons.OK);
        }

        private void recProfRecursivo(CVertice nodo, ref List <CArista>tmp)
        {            
            nodo.marcado = true;
            List<CVertice> adyNodo= new List<CVertice>();
            foreach(CArista a in nodo.getListaAristas() )
            {
                adyNodo.Add(a.v2);
            }
            adyNodo=SortID(adyNodo);
            foreach (CVertice v in adyNodo)
            {
                if (!v.marcado)
                {
                    if (!tmp.Contains(new CArista(nodo, v, Color.Black, 5)))
                    {
                        tmp.Add(new CArista(nodo, v, Color.Black, 5));
                    }
                    recProfRecursivo(v, ref tmp);                                        
                }                
            }
        }

        public List<CVertice> SortID(List<CVertice> Adyacentes)
        {
            Adyacentes.Sort(
                delegate(CVertice x, CVertice y)
                {
                    return x.id.CompareTo(y.id);
                }
                );
            return Adyacentes;
        }    

        public override void ReccorridoAmplitud()
        {
            desmarcar();
            List<CVertice> vertices = new List<CVertice>(), Q = new List<CVertice>() ;
            List<CArista> T = new List<CArista>();
            CVertice ini = listV[0];
            CVertice u = null;

            ini.marcado = true;
            foreach (CVertice v in listV)
                vertices.Add(v);
            vertices.Remove(ini);
            Q.Add(ini);            

            while (vertices.Count >= 1)
            {
                u = Q[0];
                Q.Remove(u);
                List<CVertice> adyU= new List<CVertice>();
                foreach(CArista a in u.getListaAristas() )
                {
                    adyU.Add(a.v2);
                }
                adyU = SortID(adyU);
                foreach (CVertice w in adyU)
                {
                    if (!w.marcado)
                    {
                        w.marcado = true;
                        Q.Add(w);
                        T.Add(new CArista(u, w, Color.Black, 5));
                        vertices.Remove(w);
                    }
                }
            }

            string arbolProf = "T={ ";
            foreach (CArista a in T)
            {
                arbolProf += " (" + a.v1.id.ToString() + "," + a.v2.id.ToString() + ") ";
            }
            arbolProf += "}";
            MessageBox.Show(arbolProf, "Recorrido en Amplitud", MessageBoxButtons.OK);
        }

        public override void PuntosArticulacion()
        {
            int j = 0; 
            List<CArista> tmp = new List<CArista>();
            foreach (CVertice v in ListV)
            {
                v.Bajo = int.MaxValue;
                v.Hijo = new List<CVertice>();
                v.Num = int.MaxValue;
            }
            desmarcar();
            tmp=rp(1,tmp);
            foreach (CVertice v in listV)
            {
                foreach (CVertice w in listV)
                {
                    if (v.Num + 1 == w.Num)
                    {
                        v.Hijo.Add(w);
                    }
                }
            }
            int raices = 0;
            foreach (CArista a in tmp)
            {
                if (listV[0].id == a.v1.id || listV[0].id == a.v2.id)
                {
                    raices++;
                }
            }

            desmarcar();
            rp(2,tmp);
            string cad1 = "",cad2="", datos="";
            bool puntos = false;
            int cont = 0;
            //listV[0].Hijo.Count
            if ( raices > 1)
            {                
                cad1+="La raiz es un Punto de Articulacion.\n";
                puntos = true;
            }
            else
            {
                cad1 += "La raiz No es un Punto de Articulacion.\n";
            }
            for (int i = 1; i < listV.Count; i++)
            { 
                foreach(CVertice v in listV[i].Hijo )
                {
                    if (v.Bajo >= listV[i].Num)
                    {
                        cad2 += "El nodo " + listV[i].id.ToString() + ": Es un Punto de Articulacion.\n";
                        cont++;                        
                        puntos = true;
                    }
                }
            }

            if (cont > 0)
            {
                cad1 += "Puntos de Articulación = " + cont.ToString();
            }
            else
            {
                cad1 += "No hay puntos de Articulacion.";
            }

            if (puntos)
            {
                cad2 += "\nNo es Biconexo.";
            }
            else
            {
                cad2 += "\nEs Biconexo.";
            }

            foreach (CVertice v in listV)
            {
                datos += "\nVertice " + v.id.ToString() + ":  Num= " + v.Num +" ; "+ " Bajo= " + v.Bajo.ToString();
            }

            MessageBox.Show(datos + "\n\n" + cad1 + "\n" + cad2, "Puntos de Articulacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private List<CArista> rp(int vuelta, List<CArista> tmp)
        {
            List<CVertice> vertices = listV;
            int cont = 1;
            desmarcar();
            if(vuelta==1)
                tmp = new List<CArista>();
            foreach (CVertice aux in vertices)
            {
                if (!aux.marcado)
                {
                    if (vuelta == 1)
                        rp_num(aux, ref cont, ref tmp);
                    else
                        if (vuelta == 2)                        
                            rp_bajo(aux, tmp);
                }
            }
            /*string arbolProf = "T={ ";
            foreach (CArista a in tmp)
            {
                arbolProf += " (" + a.v1.id.ToString() + "," + a.v2.id.ToString() + ") ,";
            }
            arbolProf += "}";
            MessageBox.Show(arbolProf, "Búsqueda en profundidad", MessageBoxButtons.OK, MessageBoxIcon.Information);
            int i;*/
            return tmp;
        }
        private void rp_num(CVertice nodo, ref int cont, ref List<CArista> tmp)
        {
            nodo.marcado = true;
            nodo.Num = cont;
            cont++;
            
            List<CVertice> adyNodo = new List<CVertice>();
            foreach (CArista a in nodo.getListaAristas())
            {
                adyNodo.Add(a.v2);
            }
            adyNodo = SortID(adyNodo);
            foreach (CVertice v in adyNodo)
            {
                if (!v.marcado)
                {
                    if (!tmp.Contains(new CArista(nodo, v, Color.Black, 5)))
                    {
                        tmp.Add(new CArista(nodo, v, Color.Black, 5));
                    }
                    rp_num(v, ref cont, ref tmp);
                }
                else
                {
                    nodo.ArcosRetro.Add(v);                    
                }
            }
        }
        private void rp_bajo(CVertice nodo, List<CArista> tmp)
        {
            nodo.marcado = true;
            List<CVertice> adyNodo = new List<CVertice>();
            foreach (CArista a in nodo.getListaAristas())
            {
                adyNodo.Add(a.v2);
            }
            adyNodo = SortID(adyNodo);
            foreach (CVertice v in adyNodo)
            {
                if (!v.marcado)
                {
                    rp_bajo(v, tmp);
                }
            }
            nodo.Bajo = min(nodo, tmp);
        }   
        private int min(CVertice nodo, List<CArista> tmp)
        {
            int min = int.MaxValue;
            int z_num=int.MaxValue;            
            int y_bajo=int.MaxValue;
            int n_num = nodo.Num;
            if (nodo.Num == 3)
            {
                int j=0;
            }

            bool retro = true;
            if (nodo.Hijo.Count > 0)
            {
                foreach (CVertice v in nodo.Hijo)
                {
                    if (v.Num < y_bajo)
                    {
                        y_bajo = v.Bajo;
                    }                
                }                    
            }
               
            foreach (CVertice v in nodo.ArcosRetro)
            {
                retro = true;
                foreach (CArista a in tmp)
                {
                    if (nodo.id == a.v2.id && v.id == a.v1.id)
                    {
                        retro = false;
                        break;
                    }
                }
                if (v.Num < z_num && retro)
                {
                    z_num = v.Num;
                }                
            }
            if (n_num <= z_num && n_num <= y_bajo)
            {
                min = n_num;
            }
            else 
            {
                if (z_num <= n_num && z_num <= y_bajo)
                {
                    min = z_num;
                }
                else
                {
                    if (y_bajo <= n_num && y_bajo <= z_num)
                    {
                        min = y_bajo;
                    }
                }
            }            
            return min;
        }
        
    }
}

