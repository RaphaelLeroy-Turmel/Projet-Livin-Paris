using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetGraphe
{
    internal class Noeud
    {
        private int noeud_id;
        private Noeud[,] relations;



        public Noeud(int noeud_id, Noeud[,] relations)
        {
            this.noeud_id = noeud_id;
            this.relations = relations;
        }
    }
}
