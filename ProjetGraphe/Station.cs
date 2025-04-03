using GraphSharp.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetGraphe///Raphael_LEROY_TURMEL_Thomas_LIOTIER_Loan_LU_CHI_VANG
{
    public class Station 
    {
        public int Id;
        public List<int> ListeDesLignes { get; set; }/// <summary>
                                                     /// Liste de toutes les lignes qui passent par cette station
                                                     /// </summary>
        public string LibelleStation;
        public double Longitude;
        public double Latitude;

        public Station( int id, int libelleLigne, string libelleStation, double longitutde, double latitude)
        {
            this.Id = id;
            ListeDesLignes = new List<int>();
            AddLigne(libelleLigne);
            LibelleStation = libelleStation;
            Longitude = longitutde;
            Latitude = latitude;
        }
        public bool AddLigne(int Ligne)
        {
            bool ans = false;
            if(ListeDesLignes == null)
            {
                Console.WriteLine("ligne est nulleee");
                return ans;
            }

            if(!ListeDesLignes.Contains(Ligne)) 
            { ListeDesLignes.Add(Ligne);
                ans = true;
            }
            return ans;                   

        }

        public string StationtoString()
        {
            string listedlignes = "";
            foreach (int ligne in ListeDesLignes) {
                listedlignes += Convert.ToString( ligne);
                listedlignes += ", ";
            
            }
             return $"ID: {this.Id} , Libelle station {this.LibelleStation} , ligne(s) {listedlignes}";
             
        }

    }
}
