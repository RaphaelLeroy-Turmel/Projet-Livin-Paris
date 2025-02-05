namespace ProjetGraphe
{
    internal class Program
    {// test
        static void Main(string[] args)
        {
            Console.WriteLine("Linganguliguli");

            Graphe Karaté = new Graphe("Karaté", "soc-karate.mtx");
            Karaté.MatrixtoString();
            Karaté.ListedAdjacence();
            Karaté.ParcoursEnLargeur(Karaté.GetGraphe[0].Noeud_Id);

            //Graphe GrapheTest = new Graphe("GrapheTest", "PetitGrapheTest.txt");
            //GrapheTest.MatrixtoString();
            //GrapheTest.ListedAdjacence();
            //GrapheTest.ParcoursEnLargeur(GrapheTest.GetGraphe[0].Noeud_Id);

            //Karaté.AddRelationMatrix(1, 10);
            //Karaté.AddRelationMatrix(2, 2);
            //Karaté.MatrixtoString();
        }
    }
}
