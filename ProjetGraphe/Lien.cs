using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST_Projet_Livin_Paris
{
    internal class Lien<T>
    {


        public Noeud<T> NoeudDépart;
        public Noeud<T> NoeudArrivée;
        public int Poids;

        public Lien(Noeud<T> noeudDépart, Noeud<T> noeudArrivée, int poid)
        {
            this.NoeudDépart = noeudDépart;
            this.NoeudArrivée = noeudArrivée;
            this.Poids = poid;
        }
        public string toString()
        {
            string a = NoeudDépart.GetLibStation();
            string b = NoeudArrivée.GetLibStation();

            return (a + " --> " + b);
        }

    }
}
