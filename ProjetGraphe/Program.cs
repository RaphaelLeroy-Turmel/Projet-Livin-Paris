using GraphVisualization;
using System.Diagnostics;
using System;
using MySql.Data.MySqlClient;

namespace ProjetGraphe///Raphael_LEROY_TURMEL_Thomas_LIOTIER_Loan_LU_CHI_VANG
{
    public class Program
    {// test
        static void Main(string[] args)
        {


            Graphe<Station> PlanMétro = new Graphe<Station>("Plan métro", "MetroParis feuille 1.csv", "Métro paris feuill2 v2.csv");
            
            
            var stations = GraphViewModel.ChargerStationsDepuisCSV("MetroParis feuille 1.csv");
            GraphViewModel Graphe = new GraphViewModel(stations, PlanMétro.Matrix);
            Graphe.GenerationImage(stations, PlanMétro.Matrix);




            new Affichage();
        }
    }
}
