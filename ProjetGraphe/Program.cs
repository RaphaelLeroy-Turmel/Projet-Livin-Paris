namespace ProjetGraphe
{
    internal class Program
    {// test
        static void Main(string[] args)
        {
            Console.WriteLine("Linganguliguli");

            Graphe Karaté = new Graphe("Karaté", "soc-karate.mtx");

            Karaté.MatrixtoString();

            //Karaté.AddRelationMatrix(1, 10);
            //Karaté.AddRelationMatrix(2, 2);
            //Karaté.MatrixtoString();
        }
    }
}
