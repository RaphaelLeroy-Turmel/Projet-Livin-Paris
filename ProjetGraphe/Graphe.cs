using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetGraphe
{
    internal class Graphe
    {
        private string nom_de_graphe = "";
        private int[,] graphe = new int[,] { };

        public Graphe(string nom, string filename) 
        {
            this.nom_de_graphe = nom;

            StreamReader sr = new StreamReader(filename);
            sr.ReadLine();
            while (sr!=null)
            {


            }
        
        }

    }
}
