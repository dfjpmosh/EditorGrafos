using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace EditorTest
{
    public partial class Form1 : Form
    {
        CGrafo grafo;//grafo
        CVertice refV1, refV2;//referencias a vertices
        CArista arista;
        CVertice vertice;
        //Config copiaConfig;
        int id;//identificador del nodo;
        int diam, anchoContornoVert, anchoArista;
        Color colorVertice, colorContorno,colorArista;
        char idL;
        Point p1, p2;
        Bitmap bmp;
        Graphics g,pag;
        PaintEventArgs paintE;
        bool band;//bandera deja pintar una linea(arista)
        int opcion;//opcion para saber que operacion se va a realizar
        string camino;
        int it = 0;
        bool kuratowski;
        CGradoVertice deg;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            band = false;//no se puede pintar una arista
            p1 = new Point();
            p2 = new Point();
            bmp = new Bitmap(ClientSize.Width, ClientSize.Height);
            pag = CreateGraphics();
            g = Graphics.FromImage(bmp);
            grafo = new CGrafo();
            deg = new CGradoVertice();
            opcion = -1;
            //grafo.Config = new Config();
            //confDefault(config);
            id = 1;
            idL = 'A';
            diam=40;
            colorVertice = Color.White;
            colorContorno= Color.Black;
            anchoContornoVert = 3;
            colorArista = Color.Black;
            anchoArista = 3;

            toolMenu.Left = (this.Width - toolMenu.Width) / 2;
           // toolMenu.Top = (this.Width - toolMenu.Height) / 2;

            this.MouseDown += new MouseEventHandler(Form1_MouseDown);
            this.MouseMove += new MouseEventHandler(Form1_MouseMove);
            this.MouseUp += new MouseEventHandler(Form1_MouseUp);
            this.Paint += new PaintEventHandler(Form1_Paint);
            this.Resize += new EventHandler(Form1_Resize);
            this.guardar.Click += new EventHandler(guardar_Click);
            this.abrir.Click +=new EventHandler(abrir_Click);
            //this.ConfiguracionDatos.Click += new EventHandler(ConfiguracionDatos_Click);
            kuratowski = false;
            if (kuratowski)
            {
                contextKuratowski.Enabled = false;
            }
        }

        /*void ConfiguracionDatos_Click(object sender, EventArgs e)
        {
            Datos d = new Datos(grafo.Config);
            if (d.ShowDialog() == DialogResult.OK)
            {
                grafo.Config = d.CONFIG;
            }
        }*/

        void  abrir_Click(object sender, EventArgs e)
        {
            try
            {
                Stream stream;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    IFormatter formatter = new BinaryFormatter();
                    stream = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read, FileShare.None);
                    grafo = (CGrafo)formatter.Deserialize(stream);
                    stream.Close();
                    id = grafo.ListV[grafo.ListV.Count-1].id+1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Form1_Paint(sender, paintE);
        }
        CGrafo abrir_Click(string nombre)
        {
            CGrafo g;
            try
            {
                Stream stream;
                IFormatter formatter = new BinaryFormatter();
                stream = new FileStream(nombre, FileMode.Open, FileAccess.Read, FileShare.None);
                g = (CGrafo)formatter.Deserialize(stream);
                stream.Close();
                return g;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }
        void guardar_Click(object sender, EventArgs e)
        {
            Stream stream;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            { 
                IFormatter formatter = new BinaryFormatter();
                stream = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
                formatter.Serialize(stream, grafo);
                stream.Close();
            }
            this.Form1_Paint(sender, paintE);
        }

        void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                switch (opcion)
                {
                    case 1://mueve nodo                        
                        if (grafo != null)//si hay grafo
                        {
                            Cursor = Cursors.SizeAll;//cambiamos el cursor
                            refV1 = grafo.dameVertice(e.Location);//obtenemos el vertice
                                    //si es que se ha seleccionado uno
                        }
                        break;
                    case 3:                        
                        if (grafo != null)
                        {
                            Cursor = Cursors.NoMove2D;
                            refV1 = grafo.dameVertice(e.Location);
                        }
                    break;
                    case 5://arista no dirigida
                    if (grafo != null)//si el grafo contiene vertices
                    {
                        grafo = new CGrafoNoDirigido(grafo);
                        refV1 = grafo.dameVertice(e.Location);//checa si es un vertice
                        if (refV1 != null)//si es un vertice 
                        {
                            p1 = e.Location;//tomamos la localizacion del MouseButtons
                            band = true;// indicamos que si se puede pintar la arista
                            //pero todavia no creamos la relacion
                        }
                    }
                    break;
                    case 6://arista dirigida
                        if (grafo != null)//si el grafo contiene vertices
                        {
                            grafo = new CGrafoDirigido(grafo);
                            refV1 = grafo.dameVertice(e.Location);//checa si es un vertice
                            if (refV1 != null)//si es un vertice 
                            {
                                p1 = e.Location;//tomamos la localizacion del MouseButtons
                                band = true;// indicamos que si se puede pintar la arista
                                            //pero todavia no creamos la relacion
                            }
                        }
                        break;
                }
            }
            Form1_Paint(null, null);
        }

        void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (grafo.buscaArista(e.Location) == true)
                Cursor = Cursors.Hand;
            else
                Cursor = Cursors.Default;

            switch (opcion)
            {
                case 1://mueve vertice
                    if(refV1!=null)//si la referencia al vertice 
                    {               //es diferente de null
                        refV1.pos=e.Location;//se cambia la posicion del vertice.
                    }
                break;
                case 3:
                if (refV1 != null)
                {
                    if (grafo != null)
                    {
                        grafo.muevete(refV1.pos, e.Location);
                    }
                }
                break;
            }
            p2 = e.Location;//si el mouse se mueve capturamos la localizacion
            //this.Form1_Paint(sender, paintE);//mandamos llamas a paint
            Form1_Paint(null, null);
        }

        void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (kuratowski)
                    contextKuratowski.Show(p2);
                else
                {
                    //if (grafo.hayArista(p2))
                    if (grafo.buscaArista(p2))
                    {
                        contextArista.Show(e.X, e.Y);
                        arista = grafo.dameArista(p2);
                    }
                }
            }
            if (e.Button == MouseButtons.Left)//si se presiono el boton 
            {
                switch (opcion)
                {
                    case 0://nodo nuevo
                        //agregamos el nodo a la lista de vertices pero no a la del grafo
                        //sino a una temporal
                        grafo.agregaVertice((new CVertice(new Point(e.X, e.Y),idL, id, diam, colorVertice, colorContorno
                            , anchoContornoVert)));
                        id++;//aumentamos el identificador  
                        idL++;
                        break;
                    case 1://si se suelta el mouse deja de moverse el vertice
                        refV1 = null;//la referencia al mouse se hace null
                        break;
                    case 2://elimina nodo
                        if (grafo != null)//su hay grafo
                        {   
                            refV1 = grafo.dameVertice(e.Location);//se obtiene la referencia al vertice a eliminar
                            if (refV1 != null)//si hay referencia a un vertice
                            {
                                grafo.eliminaVertice(refV1);//eliminamos vertice
                            }
                            refV1 = null;
                            refV2 = null;
                        }
                        break;
                    case 3:
                        refV1 = null;
                    break;
                    case 5://crea arista no dirigida
                    if (grafo != null)//si hay grafo
                    {
                        refV2 = grafo.dameVertice(new Point(e.X, e.Y));//obtenemos la referencia al segundo vertices
                        if (refV1 != null && refV2 != null)//si hay referencias al vertice 1 y al 2
                        {
                            grafo.agregaArista(new CArista(refV1, refV2, colorArista, anchoArista));//agregamos arista al grafo
                            refV1 = null;
                            refV2 = null;
                            Dirigido.Enabled = false;
                            AristaElimina.Enabled = true;
                        }
                    }
                    break;
                    case 6://crea arista dirigida
                        if (grafo != null)//si hay grafo
                        {
                            refV2 = grafo.dameVertice(new Point(e.X, e.Y));//obtenemos la referencia al segundo vertices
                            if (refV1 != null && refV2 != null)//si hay referencias al vertice 1 y al 2
                            {
                                grafo.agregaArista(new CArista(refV1, refV2, colorArista,anchoArista));//agregamos arista al grafo
                                refV1 = null;
                                refV2 = null;
                                NoDirigido.Enabled = false;
                                AristaElimina.Enabled = true;
                            }
                        }
                        break;
                    case 7:
                        grafo.eliminaArista(e.Location);
                    break;
                }
            }
            Cursor = Cursors.Arrow;//actualizamos el cursor por la flecha
            band = false;//no se puede pintar arista
            Form1_Paint(null, null);
        }

        void Form1_Paint(object sender, PaintEventArgs e)
        {
            //g.SmoothingMode = SmoothingMode.AntiAlias;//suaviza el pintado 
            g.Clear(this.BackColor);//limpiamos el graphics
            paintE = e;//actualizamos el evento de paint            
            Pen pen;
            
            switch (opcion)
            { 
                case 0: //nuevo nodo
                    pen = new Pen(colorVertice, anchoContornoVert);//creamos pluam
                    g.DrawEllipse(pen, p2.X - diam / 2, p2.Y - diam / 2, diam, diam);
                break;
                case 5://pinta arista no dirigida
                    if (band)
                    {
                        pen = new Pen(colorArista, anchoArista);//creamos pluam
                        g.DrawLine(pen, p1, p2);
                        Cursor = Cursors.Hand;//cambiamos el cursor por una mano
                    }
                break;
                case 6://pinta arista dirigida
                    if (band)//si puede pintar arista
                    {
                        pen = new Pen(colorArista, anchoArista);//creamos pluam
                        AdjustableArrowCap tipo = new AdjustableArrowCap(10, 20);
                        tipo.Filled = true;
                        pen.CustomEndCap = tipo;
                                                
                        g.DrawLine(pen, p1, p2);
                        Cursor=Cursors.Hand;//cambiamos el cursor por una mano
                    }
                break; 
                case 8:
                    if (grafo != null)
                        grafo.dibujaCamino(g, camino, it);
                break;
            }

            if (grafo != null)
            {
                foreach (CVertice v in grafo.ListV)//para cada vertice de la lista de vertices 
                {
                    v.dibujate(g, 0);// este vertice dibujate
                }
            }

            if (grafo.numVertices() != 0)//si el grafo tiene elementos//grafo != null &&
            {
                grafo.dibujaGrafo(g, true);// dibuja grafo
                //Si hay grafo habilitamos
                nodoMueve.Enabled = true;
                nodoElimina.Enabled = true;
                grafoMueve.Enabled = true;
                grafoElimina.Enabled = true;

            }
            else
            {
                Dirigido.Enabled = true;
                NoDirigido.Enabled = true;
                //si no hay grafo deshabilitamos
                nodoMueve.Enabled = false;
                nodoElimina.Enabled = false;
                grafoMueve.Enabled = false;
                grafoElimina.Enabled = false;
                AristaElimina.Enabled = false;
            }
            pag.DrawImage(bmp, 0, 0);//pintamos imagen en el graphics            
        }

        void Form1_Resize(object sender, EventArgs e)
        {
            bmp = new Bitmap(ClientSize.Width, ClientSize.Height);//actualizamos el bitmap
            g = Graphics.FromImage(bmp);
            pag = CreateGraphics();
            toolMenu.Left = (this.Width - toolMenu.Width) / 2;
        }        

        private void nodoNuevo_Click(object sender, EventArgs e)
        {
            opcion = 0;
            nodoNuevo.Checked = true;
            nodoMueve.Checked = false;
            nodoElimina.Checked = false;
            Dirigido.Checked = false;
            NoDirigido.Checked = false;
            grafoMueve.Checked = false;
        }

        private void nodoMueve_Click(object sender, EventArgs e)
        {
            opcion = 1;
            nodoMueve.Checked = true;
            nodoNuevo.Checked = false;
            Dirigido.Checked = false;
            NoDirigido.Checked = false;
            grafoMueve.Checked = false;
        }

        private void nodoElimina_Click(object sender, EventArgs e)
        {
            opcion = 2;
            nodoElimina.Checked = true;
            nodoMueve.Checked = false;
            nodoNuevo.Checked = false;
            Dirigido.Checked = false;
            NoDirigido.Checked = false;
            grafoMueve.Checked = false;
        }

        private void Dirigido_Click(object sender, EventArgs e)
        {
            opcion = 6;
            Dirigido.Checked = true;
            nodoElimina.Checked = false;
            nodoMueve.Checked = false;
            nodoNuevo.Checked = false;
            NoDirigido.Checked = false;
        }

        private void grafoMueve_Click(object sender, EventArgs e)
        {
            opcion = 3;
            grafoMueve.Checked = true;
            Dirigido.Checked = false;
            nodoElimina.Checked = false;
            nodoMueve.Checked = false;
            nodoNuevo.Checked = false;
            NoDirigido.Checked = false;
        }

        private void grafoElimina_Click(object sender, EventArgs e)
        {
            //copiaConfig = grafo.Config;
            grafo = new CGrafo();
            //grafo.Config = copiaConfig;
            id = 1;
            idL = 'A';
            Form1_Paint(sender, paintE);
        }

        private void AristaElimina_Click(object sender, EventArgs e)
        {
            opcion = 7;
            AristaElimina.Checked = true;
            Dirigido.Checked = false;;
            nodoElimina.Checked = false;
            nodoMueve.Checked = false;
            nodoNuevo.Checked = false;
            NoDirigido.Checked = false;
        }

        private void NoDirigido_Click(object sender, EventArgs e)
        {
            opcion = 5;
            NoDirigido.Checked = true;
            nodoElimina.Checked = false;
            nodoMueve.Checked = false;
            nodoNuevo.Checked = false;
            Dirigido.Checked = false;
        }

        private void matrizAdyMenu_Click(object sender, EventArgs e)
        {
            if (grafo != null)
            {
                int[,] matrizAdy = grafo.matrizAdyacencia();
                Matriz_Adyacencia ma = new Matriz_Adyacencia(matrizAdy, grafo.numVertices());
                ma.ShowDialog();
            }
        }

        private void matrziInciMenu_Click(object sender, EventArgs e)
        {
            grafo.matrizIncidencia();
        }

        private void numeroDeNodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grafo.muestraNumVertices();
        }

        private void numeroDeAristaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grafo.muestraNumA();
        }

        private void caminoEulerMenuItem_Click(object sender, EventArgs e)
        {
            if (grafo != null)
            {
                if (grafo.tieneCircuito())
                {
                    camino = grafo.calculaEuler(g);
                    MessageBox.Show("Camino: " + camino);
                }
                else
                {
                    MessageBox.Show("No hay camino.");
                }
                
            }
        }
        private void circuitoEulerMenuItem_Click(object sender, EventArgs e)
        {
            if (grafo != null)
            {
                if (grafo.tieneCircuito())
                {
                    MessageBox.Show("Si tiene circuito euleriano");
                }
                else
                {
                    MessageBox.Show("No tiene circuito euleriano");
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            it++;
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Form1_Paint(sender, paintE);
        }


        private void isomorfismoMenuItem_Click(object sender, EventArgs e)
        {
            Form1 grafo2 = new Form1();
            grafo2.MenuPrinc.Enabled = false;
            grafo2.Visible = false;
            grafo2.botonListo.Visible = true;
            if (grafo2.ShowDialog() == DialogResult.OK)
            {
                if (grafo.numVertices() != grafo2.grafo.numVertices()
                    || grafo.numeroAristas() != grafo2.grafo.numeroAristas())
                {
                    MessageBox.Show("Los grafos No Son Isomorficos", "Fallo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    grafo.gradoNodos();
                    if( grafo.isomorfismo(grafo,grafo2.grafo))
                        MessageBox.Show("Los grafos son Isomorficos", "Exito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Los grafos No Son Isomorficos", "Fallo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void Corolarios_Click(object sender, EventArgs e)
        {
            grafo.Colorario();
        }

        private void Coloreados_Click(object sender, EventArgs e)
        {
            Color aux = grafo.ListV[0].Color;
            grafo.Coloreados();
            this.Form1_Paint(sender, paintE);
            for (int i = 0; i < 1000; i++)
            { 
            }
            foreach (CVertice v in grafo.ListV)
            {
                //v.Color = aux;
                //v.Coloreado = 0;
            }
        }

        private void esIsomorfico(CGrafo g1)
        {
            CGrafo g2 = new CGrafo();
            g2 = abrir_Click("K3,3");
            CGrafo g3 = new CGrafo();
            g3 = abrir_Click("K5");
            bool isomorfico=false;
            //if (g1.numVertices() == g2.numVertices() && g1.numeroAristas() == g2.numeroAristas())
            {
                if (g1.isomorfismo(g1, g2))
                {
                    isomorfico=true;
                    MessageBox.Show("No es plano, es isomorfico a K3,3 ", "Kuratowski",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    kuratowski = false;
                }
                else
                {                    
                    if (g1.isomorfismo(g1, g3))
                    {
                        isomorfico = true;
                        MessageBox.Show("No es plano, es isomorfico a K5 ", "Kuratowski",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        kuratowski = false;
                    }
                    else
                    {
                        isomorfico = false;
                        if (MessageBox.Show("Aun no se sabe si es plano.¿Desea continuar realizando operaciones?", "Kuratowski",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                        {
                            kuratowski = false;
                        }
                    }
                }
            }
            /*else
            {
                isomorfico = false;
                if (MessageBox.Show("Aun no se sabe si es plano.¿Desea continuar realizando operaciones?", "Kuratowski",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                {
                    kuratowski = false;
                }
            }*/
        }

        private void eliminacionKuratowski_Click(object sender, EventArgs e)
        {
            grafo.eliminaKuartowski(p2);
            this.Form1_Paint(sender, paintE);            
            esIsomorfico(grafo);
        }        

        private void sudivisionKuratowski_Click(object sender, EventArgs e)
        {            
            grafo.subdivisionKuartowski(new CVertice(p2, idL++, id++, diam, colorVertice,
                colorContorno, anchoContornoVert));
            this.Form1_Paint(sender, paintE);
            esIsomorfico(grafo);
        }

        private void contraccionKuratowski_Click(object sender, EventArgs e)
        {
            grafo.contraccionKuartowski(new CVertice(p2, idL++, id++, diam, colorVertice,
                colorContorno, anchoContornoVert));
            this.Form1_Paint(sender, paintE);
            esIsomorfico(grafo);
        }

        private void kuratowskiAutomatico_Click(object sender, EventArgs e)
        {
            if (grafo.numeroAristas() == grafo.numVertices())
            {
                MessageBox.Show("Es Plano");
            }
            else
            {
                if (!grafo.kuratowsky_k33() && !grafo.kuratowsky_k5())
                { 
                    MessageBox.Show("Es Plano");
                }                        
            }
        }

        private void kuratowskiIteractivo_Click(object sender, EventArgs e)
        {
            kuratowski = true;
        }

        private void costoSubContext_Click(object sender, EventArgs e)
        {
            AristaProp costoAri = new AristaProp("Costo");
            if (costoAri.ShowDialog() == DialogResult.OK)
            {
                if (costoAri.getCosto() > 0)
                {
                    arista.Costo = costoAri.getCosto();
                    arista.marcada = true;
                    foreach (CVertice w in grafo.ListV)
                    {
                        foreach (CArista a in w.getListaAristas())
                        {
                            if (arista.v1 == a.v2 && arista.v2 == a.v1)
                            {
                                a.Costo = costoAri.getCosto();
                                a.marcada = true;
                            }
                        }
                    }
                }
            }
        }

        private bool tieneCosto()
        {
            bool costo = true;
            foreach (CVertice v in grafo.ListV)
            {
                foreach (CArista a in v.getListaAristas())
                {
                    if (a.Costo == -1)
                    {
                        costo = false;
                        break;
                    }
                }
            }
            return costo;
        }

        private void floyd_Click(object sender, EventArgs e)
        {
            string cad = "Vertices  Camino          Longitud\n\n";
            int i=-1, j=-1;
            if (grafo != null )
            {
                if (tieneCosto())
                {
                    grafo.Floyd();
                    int[,] D = grafo.D;
                    int[,] P = grafo.P;
                    
                    if (P != null)
                    {
                        List<int> list = new List<int>();
                        foreach (CVertice v in grafo.ListV)
                        {
                            list.Add(v.id);
                        }
                        //CaminoVertices cam = new CaminoVertices(list);
                        //if (cam.ShowDialog() == DialogResult.OK)
                        for (i = 0; i < grafo.ListV.Count; i++)
                        {
                            for (j = 0; j < grafo.ListV.Count; j++)
                            {
                                //i = cam.getIni();
                                //j = cam.getFin();
                                cad += (i + 1) + "-" + (j + 1) + "            ";
                                llamaCamino(i, j, ref cad, ref P);
                                cad += "                  " + D[i, j] + "\n";
                            }
                            cad += "\n";
                        }
                        MessageBox.Show(cad);
                    }
                }
                else
                    MessageBox.Show("No todas las aristas tienen costo.");
            }
            
        }
        
        private void llamaCamino(int i, int j, ref string cad, ref int [,] matriz)
        {
            cad += (i+1).ToString()+ "- ";
            caminoFloyd(i, j, ref cad, ref matriz);
            cad += (j+1).ToString() + "- ";
        }
        private void caminoFloyd(int i, int j, ref string cad, ref int[,] matriz )
        { 
            int k = matriz[i,j];            
            if (k == 0)
            {
                return;
            }
            else 
            {
                caminoFloyd(i, k, ref cad, ref matriz);
                cad += (k+1).ToString() + "- ";
                caminoFloyd(k, j, ref cad, ref matriz);
            }
        }

        private void imprimeMatriz(int[,] m)
        {
            int n = (int)Math.Sqrt(m.Length);
            int valor;
            MatrizFloyd matriz = new MatrizFloyd(n);
            String[] row = new string[n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {

                    valor = m[i, j];
                    if (valor < 99999)
                    {
                        row[j] = Convert.ToString(valor);
                    }
                    else
                        row[j] = "infinito";
                }
                matriz.imprime(row);
            }
            matriz.ShowDialog();
        }

        private void centroGrafo_Click(object sender, EventArgs e)
        {
            string cad;
            if (grafo != null)
            {
                grafo.respalda();
                cad=grafo.centroGrafo();
                Form1_Paint(null, null);
                MessageBox.Show(cad);
                grafo.restaura();
            }
        }

        private void dijkstra_Click(object sender, EventArgs e)
        {
            CArista a;
            int[,] C = new int[grafo.ListV.Count, grafo.ListV.Count];
            List<int> list = new List<int>();

            for (int i = 0; i < grafo.ListV.Count; i++)
            {
                list.Add(grafo.ListV[i].id);
                for (int j = 0; j < grafo.ListV.Count; j++)
                {
                    a = grafo.ListV[i].dameAristaCon(grafo.ListV[j]);
                    if (i == j)
                    {
                        C[i, j] = 0;
                    }
                    else
                    {
                        if (a != null)
                        {
                            C[i, j] = a.Costo;
                        }
                        else
                            C[i, j] = 999999;
                    }
                }
            }
            CaminoVertices cam = new CaminoVertices(list);
            cam.label2.Visible=false;
            cam.comboVertFin.Visible=false;
            if (cam.ShowDialog() == DialogResult.OK)
            {
                int ivi = cam.getIni()-1;
                grafo.Dijkstra(C, ivi);
            }
        }

        private void cerraduraTransistiva_Click(object sender, EventArgs e)
        {
            CArista a;
            int[,] C = new int[grafo.ListV.Count, grafo.ListV.Count];

            for (int i = 0; i < grafo.ListV.Count; i++)
            {
                for (int j = 0; j < grafo.ListV.Count; j++)
                {
                    a = grafo.ListV[i].dameAristaCon(grafo.ListV[j]);
                    if (a != null)
                    {
                        C[i, j] = 1;
                    }
                    else
                        C[i, j] = 0;
                }
            }
            grafo.Warshall(C);
        }

        private void bosqueAbarcadorDeProfundidad_Click(object sender, EventArgs e)
        {            
            bool gda=grafo.BosqueAbarcadorProfundidad();
            Tipos_de_Arcos tipos = new Tipos_de_Arcos(gda);
            this.Form1_Paint(null, null);
            tipos.ShowDialog();
            grafo.respalda();
        }

        private void componentesFuertes_Click(object sender, EventArgs e)
        {
            int comp=grafo.ComponentesFuertes();
            this.Form1_Paint(sender, paintE);
            System.Windows.Forms.MessageBox.Show("El Numero de Componentes Fuertes es: " + Convert.ToString(comp));            
            grafo.restaura();
        }

        private void primToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool continua = true;
            if (grafo != null)
            {
                foreach (CVertice v in grafo.ListV)
                {
                    foreach (CArista a in v.getListaAristas())
                    {
                        if (a.Costo < 0)
                        {
                            continua = false;
                            break;
                        }
                    }
                }
                if (continua)
                    grafo.Prim();
                else
                    MessageBox.Show("Hay aristas sin costo.");
            }
        }

        private void kruskalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool continua = true;
            if (grafo != null)
            {
                foreach (CVertice v in grafo.ListV)
                {
                    foreach (CArista a in v.getListaAristas())
                    {
                        if (a.Costo < 0)
                        {
                            continua = false;
                            break;
                        }
                    }
                }
                if (continua)
                    grafo.Kruskal();
                else
                    MessageBox.Show("Hay aristas sin costo.");
            }
        }

        private void recorridoProfundidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grafo != null)
            {
                grafo.RecorridoProfundidad();
            }
        }

        private void recorridoAmplitudToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grafo != null)
            {
                grafo.ReccorridoAmplitud();
            }
        }

        private void puntosDeAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grafo != null)
            {
                grafo.PuntosArticulacion();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            grafo = new CGrafo();
            id = 1;
            this.Form1_Paint(sender, paintE);
        }

        private void gradoNodos_Click(object sender, EventArgs e)
        {
            if (grafo != null)
            {
                grafo.gradoNodos();
            }
        }

        private void conteoDeCaminoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grafo != null)
            {
                grafo.conteoCaminos();
            }
        }
        
    }
}
