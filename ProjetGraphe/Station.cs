using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST_Projet_Livin_Paris
{
    internal class Station
    {
        public int Id;
        public string LibelleStation;
        public List<float> ListeLibelleLigne; /// oui float car on rajoute +0,5 pour distinguer les lignes bis des lignes clasiques
        public double Longitude;
        public double Latitude;

        public Station(int id, List<float> libelleLigne, string libelleStation, double longitude, double latitude)
        {
            Id = id;
            LibelleStation = libelleStation;
            ListeLibelleLigne = libelleLigne;
            Longitude = longitude;
            Latitude = latitude;
        }
        public Station(int id, float libelleLigne, string libelleStation, double longitude, double latitude)
        {
            Id = id;
            LibelleStation = libelleStation;
            if (ListeLibelleLigne == null)
            {
                //Console.WriteLine("Liste de ligne nulle : création d'une station");
                ListeLibelleLigne = new List<float>();
                ListeLibelleLigne.Add(libelleLigne);
            }
            Longitude = longitude;
            Latitude = latitude;
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
