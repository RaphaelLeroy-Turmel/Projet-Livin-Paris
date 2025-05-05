using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST_Projet_Livin_Paris
{///Raphaël_LEROY TURMEL Thomas LIOTIER Loan LU-CHI-VANG TD K
    internal class Station
    {
        public int Id;
        public string LibelleStation;
        public List<float> ListeLibelleLigne; /// float car on rajoute +0,5 pour distinguer les lignes bis des lignes clasiques ex ligne 7 a un id : 7 et l'id de 7 bis est 7,5
        public double Longitude;
        public double Latitude;

        public Station(int id, List<float> libelleLigne, string libelleStation, double longitude, double latitude)
        {
            Id = id;
            LibelleStation = libelleStation;
            ListeLibelleLigne = new List<float>(libelleLigne);
            Longitude = longitude;
            Latitude = latitude;
        }
        public Station(int id, float libelleLigne, string libelleStation, double longitude, double latitude)
        {
            Id = id;
            LibelleStation = libelleStation;
            if (ListeLibelleLigne == null)
            {
                
                ListeLibelleLigne = new List<float>();
                ListeLibelleLigne.Add(libelleLigne);
            }
            Longitude = longitude;
            Latitude = latitude;
        }
        public void AddLigne(float IdLigne)
        {
            if (!ListeLibelleLigne.Contains(IdLigne)) { this.ListeLibelleLigne.Add(IdLigne); }
            else { Console.WriteLine("Ajout impossible la ligne est deja présente dans la liste !"); }

        }

        public int LigneCommune(Station stationB)
        {
            foreach (int ligne in ListeLibelleLigne)
            {
                foreach (int ligneB in stationB.ListeLibelleLigne)
                {
                    if (ligne == ligneB)
                    {
                        return ligne;
                    }
                }
            }
            return -1;
        }
    }
}
