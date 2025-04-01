using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetGraphe
{
    public class Noeud<T>
    {
        public T element;
        public int noeud_id;
        public List<Lien<T>> relationsEntrantes;
        public List<Lien<T>> relationsSortantes;



        public Noeud(int noeud_id,T element, List<Lien<T>> relationsE, List<Lien<T>> relationsS)
        {
            this.noeud_id = noeud_id;
            this.element = element;
            this.relationsEntrantes = relationsE;
            this.relationsSortantes = relationsS;
        }

        public Noeud(Noeud<T> noeud) 
        {
            this.element = noeud.element;
            this.relationsEntrantes = noeud.relationsEntrantes;
            this.relationsEntrantes = noeud.relationsEntrantes;
            this.relationsEntrantes = noeud.relationsEntrantes;
        }
        public Noeud(int noeud_id,T element)
        {
            this.noeud_id = noeud_id;
            this.element = element;
            relationsEntrantes= new List<Lien<T>>();
            relationsSortantes= new List<Lien<T>>();
            
        }
        public T Element
        {
            get { return element; }
            set { element = value; }
        }

        
      
    }
}
