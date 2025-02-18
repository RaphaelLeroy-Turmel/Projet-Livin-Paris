namespace ProjetGraphe
{
    internal class Program
    {// test
        static void Main(string[] args)
        {

            Graphe Karaté = new Graphe("Karaté", "soc-karate.mtx");
            Karaté.MatrixtoString();
            Karaté.ListedAdjacence();
            Karaté.ParcoursEnLargeur(Karaté.GetGraphe[0]);
            Karaté.ParcoursEnProfondeur(Karaté.GetGraphe[0]);
            

            //Karaté.AddRelationMatrix(1, 10);
            //Karaté.AddRelationMatrix(2, 2);
            //Karaté.MatrixtoString();
        }
    }
}
