using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace EditorTest
{
    [Serializable]
    public class Config 
    {
        //Pantalla        
        Color colorFondo;
        //Vertice
        Color colorVertice;
        Color colorContornoVertice;
        int anchoContornoVertice;
        int diametro;        
        bool tipoId;//true:numero / false:letra
        //Arista
        Color colorArista;
        int anchoArista;

        public Config()
        {
            //pantalla            
            colorFondo = Color.White;
            //vertice
            colorVertice = Color.Turquoise;
            colorContornoVertice = Color.Black;
            diametro = 30;
            anchoContornoVertice = 3;
            tipoId=false;//true:numero / false:letra
            //arista
            colorArista = Color.Black;
            anchoArista = 3; 
        }

        public Color CP
        {
            get { return colorFondo; }
            set { colorFondo = value; }
        }
        public Color CV
        {
            get { return colorVertice; }
            set { colorVertice = value; }
        }
        public Color CCV
        {
            get { return colorContornoVertice; }
            set { colorContornoVertice = value; }
        }
        public int DIAM
        {
            get { return diametro; }
            set { diametro = value; }
        }
        public int ACV
        {
            get { return anchoContornoVertice; }
            set { anchoContornoVertice = value; }
        }
        public bool ID
        {
            get { return tipoId; }
            set { tipoId = value; }
        }
        public Color CA
        {
            get { return colorArista; }
            set { colorArista = value; }
        }
        public int AA
        {
            get { return anchoArista; }
            set { anchoArista = value; }
        }
    }
}
