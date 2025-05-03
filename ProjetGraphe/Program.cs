using System.Runtime.CompilerServices;
using System.Diagnostics;
using System;
using MySql.Data.MySqlClient;
using TEST_Projet_Livin_Paris;

namespace ProjetGraphe///Raphael_LEROY_TURMEL_Thomas_LIOTIER_Loan_LU_CHI_VANG
{
    public class Program
    {// test
        static void Main(string[] args)
        {


            string file1 = "MetroParis feuille 1.csv";
            string file2 = "Métro paris feuill2 v2.csv";
            Graphe<Station> PlanMétro = new Graphe<Station>(file1, file2);
            List<Station> ListeDeStation = new List<Station>();
            foreach (Noeud<Station> Noeud in PlanMétro.DictionnaireDeNoeuds.Values)
            {
                ListeDeStation.Add(Noeud.element);
            }
            GraphViewModel<Station> Graphe = new GraphViewModel<Station>(ListeDeStation, PlanMétro.MatriceAdjacence, PlanMétro);
            



            new Affichage();
        }
    }
}
