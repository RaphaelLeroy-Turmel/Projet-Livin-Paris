using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetGraphe
{
    public class Lien<T>
    {
        private Noeud<T> noeudA;
        private Noeud<T> noeudB;

        public Lien(Noeud<T> noeudA, Noeud<T> noeudB)
        {
            this.noeudA = noeudA;
            this.noeudB = noeudB;
        }
    }
}
