using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetGraphe
{
    public class Noeud<T>
    {
        private T element;
        private int noeud_id;
        public List<Noeud<T>> relations;



        public Noeud(int noeud_id,T element, List<Noeud<T>> relations)
        {
            this.noeud_id = noeud_id;
            this.element = element;
            this.relations = relations;
        }
        public Noeud(int noeud_id,T element)
        {
            this.noeud_id = noeud_id;
            this.element = element;
            relations= new List<Noeud<T>>();
            
        }
        public T Element
        {
            get { return element; }
            set { element = value; }
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
