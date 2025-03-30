using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetGraphe
{
    internal class Station
    {
        public int id;
        public List<int> ListeDesLignes; /// <summary>
        /// Liste de toutes les lignes qui passent par cette station
        /// </summary>
        public string LibelleStation;
        public double Longitutde;
        public double Latitude;

        public Station( int id, int libelleLigne, string libelleStation, double longitutde, double latitude)
        {            
            this.id = id;
            ListeDesLignes.Add(libelleLigne);
            LibelleStation = libelleStation;
            Longitutde = longitutde;
            Latitude = latitude;
        }
        public bool AddLigne(int Ligne)
        {
            bool ans = false;
            if(!ListeDesLignes.Contains(Ligne)) 
            { ListeDesLignes.Add(Ligne);
                ans = true;
            }
            return ans;                   

        }

    }
}
