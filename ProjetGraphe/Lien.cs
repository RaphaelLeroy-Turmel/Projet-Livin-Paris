using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetGraphe
{
    public class Lien<T>
    {
        public Noeud<T> noeudDépart;
        public Noeud<T> noeudArrivé;
        public int tempsTrajet;

        public Lien(Noeud<T> noeudA, Noeud<T> noeudB)
        {
            this.noeudDépart = noeudA;
            this.noeudArrivé = noeudB;
        }

        
    }
}
