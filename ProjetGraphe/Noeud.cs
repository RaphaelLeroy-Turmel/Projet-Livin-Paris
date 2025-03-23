using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetGraphe
{
    public class Noeud<T>
    {
        private int noeud_id;
        private List<Noeud<T>> relations;



        public Noeud(int noeud_id, List<Noeud<T>> relations)
        {
            this.noeud_id = noeud_id;
            this.relations = relations;
        }
        public Noeud(int noeud_id)
        {
            this.noeud_id = noeud_id;
            List<T> ListeDeRelations = new List<T>();
            
        }

        public List<Noeud<T>> Relations
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
