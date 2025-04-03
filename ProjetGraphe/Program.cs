using GraphVisualization;
using System.Diagnostics;

namespace ProjetGraphe///Raphael_LEROY_TURMEL_Thomas_LIOTIER_Loan_LU_CHI_VANG
{
    public class Program
    {// test
        static void Main(string[] args)
        {

            //Graphe Karaté = new Graphe("Karaté", "soc-karate.mtx");
            //Karaté.MatrixtoString();
            //Karaté.ListedAdjacence();
            //Karaté.ParcoursEnLargeur(Karaté.GetGraphe[0]);
            //Karaté.ParcoursEnProfondeur(Karaté.GetGraphe[0]);


            //Karaté.AddRelationMatrix(1, 10);
            //Karaté.AddRelationMatrix(2, 2);
            //Karaté.MatrixtoString();
            //bonjour

            //GraphViewModel Graphe = new GraphViewModel(Karaté.Matrix);
            //Graphe.GenerationImage(Karaté.Matrix);

            Graphe<Station> PlanMétro = new Graphe<Station>("Plan métro", "MetroParis feuille 1.csv", "metro Paris feuille 2.csv");
            PlanMétro.AfficheMatrice();
            //PlanMétro.VérifLien();
            var stations = GraphViewModel.ChargerStationsDepuisCSV("MetroParis feuille 1.csv");
            GraphViewModel Graphe = new GraphViewModel(stations,PlanMétro.Matrix);   
            Graphe.GenerationImage(stations, PlanMétro.Matrix);
        }
    }
}
