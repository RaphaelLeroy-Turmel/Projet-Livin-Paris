using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetGraphe
{
    public class Lien
    {
        private Noeud noeudA;
        private Noeud noeudB;

        public Lien(Noeud noeudA, Noeud noeudB)
        {
            this.noeudA = noeudA;
            this.noeudB = noeudB;
        }
    }
}
