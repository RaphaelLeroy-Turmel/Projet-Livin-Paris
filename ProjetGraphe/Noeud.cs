using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetGraphe
{
    public class Noeud
    {
        private int noeud_id;
        private List<Noeud> relations;



        public Noeud(int noeud_id, List<Noeud> relations)
        {
            this.noeud_id = noeud_id;
            this.relations = relations;
        }
        public Noeud(int noeud_id)
        {
            this.noeud_id = noeud_id;
            List<Noeud> ListeDeRelations = new List<Noeud>();
            this.relations = ListeDeRelations;
        }

        public List<Noeud> Relations
        {
            get { return relations; }
            set { relations = value; }
        }
         public int Noeud_Id
        {
            get { return noeud_id; }
            set { noeud_id = value; }
        }
    }
}
