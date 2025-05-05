using ProjetGraphe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST_Projet_Livin_Paris
{///Raphaël_LEROY TURMEL Thomas LIOTIER Loan LU-CHI-VANG TD K
    internal class Noeud<T>
    {
        public int Id;
        public T element;
        public List<Lien<T>> ArcsEntrants;
        public List<Lien<T>> ArcsSortants;

        public Noeud(int Id, T element, List<Lien<T>> Le, List<Lien<T>> Ls)
        {
            this.Id = Id;
            this.element = element;
            this.ArcsEntrants = new List<Lien<T>>();
            this.ArcsSortants = new List<Lien<T>>();
            this.ArcsEntrants = Le;
            this.ArcsSortants = Ls;
        }
        public Noeud(int Id, T element)
        {
            this.Id = Id;
            this.element = element;
            this.ArcsEntrants = new List<Lien<T>>();
            this.ArcsSortants = new List<Lien<T>>();
        }

        public Noeud(Noeud<T> noeud)
        {
            this.Id = noeud.Id;
            this.element = noeud.element;
            this.ArcsSortants = noeud.ArcsSortants;
            this.ArcsEntrants = noeud.ArcsEntrants;
        }

        public string GetLibStation()
        {
            if (this.element is Station station)
            {
                return station.LibelleStation;
            }
            return null;
        }

        public void ArcToString()
        {
            foreach (Lien<T> lien in this.ArcsEntrants)
            {
                lien.toString();
            }
        }

        public void AddLigne(float ligne)
        {
            if (this.element is Station station && !station.ListeLibelleLigne.Contains(ligne))
            {
                station.ListeLibelleLigne.Add(ligne);
            }
            else if (this.element is Station station1)
            {
                Console.WriteLine("Ajout Impossible de la ligne à la station : " + station1.LibelleStation);
            }
            else
            {
                Console.WriteLine("SetLigne impossible !!");
            }
        }

    }
}
