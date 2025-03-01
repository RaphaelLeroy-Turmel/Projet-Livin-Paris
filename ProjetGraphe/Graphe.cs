using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProjetGraphe
{
    public class Graphe
    {
        private string nom_de_graphe = "";
        private int[,] matrix = new int[,] { };/// matrice d'adjacence
        private string filename = "";
        private int taille = 0;/// nombre d'arêtes
        private int ordre = 0;/// nombre de sommets/noeuds
        private Noeud[] graphe = new Noeud[0];
        

        public Noeud[] GetGraphe
        {
            get { return graphe; }
            set { graphe = value; }
        }

        public int[,] Matrix
        {
            get { return matrix; }
            set { matrix = value; }
        }
        
        
        public Graphe(string nom,string filename) 
        {
            this.nom_de_graphe = nom;
            this.filename = filename;
            
            StreamReader sr = new StreamReader(this.filename);
            sr.ReadLine();
            string[] relation = new string[0];
            int b = 0;
            string line = sr.ReadLine();
            while (line!=null)
            {              
                if (line.Length > 0 && line[0] != '%')
                {                   
                    b++;
                }
                if(b == 1)
                {
                    relation = line.Split(' ');
                    this.ordre = Convert.ToInt32(relation[0]);
                    graphe = new Noeud[ordre];
                    matrix = new int[ordre, ordre];/// on sait que la matrice est carré et symétrique car les relations entre les membres sont réciproques
                }
                if (b>1)
                {
                    relation = line.Split(' ');
                    int A = Convert.ToInt32(relation[0]); /// noeud A
                    int B = Convert.ToInt32(relation[1]); /// noeud B
                    this.matrix[A-1 , B-1 ] = 1;
                    Console.WriteLine($"A :{A} , B :{B} ");
                    this.matrix[(B-1) , (A-1)] = 1;
                    taille++;
                }

                line = sr.ReadLine();
            }
            CréerGraphe();
            sr.Close();
        }
        

        public void CréerGraphe()
        {
            
            for(int i=0 ; i < matrix.GetLength(0) ; i++)
            {
                Noeud X = new Noeud(i);///on créer un noeud n°i
                graphe[i] = X; /// on ajoute ce noeud au tableau de noeud (le graphe)
                              
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 1)
                    {
                        this.graphe[i].Relations.Add(graphe[j]);
                        
                    }
                }

            }

                
        }
        public void ListedAdjacence()
        {

            for(int i =0; i < graphe.Length; i++)
            {
                if (graphe[i]!= null &&  graphe[i].Relations != null && graphe[i].Relations.Count != 0)
                {
                    Console.WriteLine("Relations du noeud " + (i+1) + " : ");
                    for (int j = 0; j < graphe[i].Relations.Count; j++)
                    {
                        Console.Write(  (graphe[i].Relations[j].Noeud_Id +1) + " ; ");




                    }
                    Console.WriteLine();
                }
            }

        }
        

        public void AddRelationMatrix(int noeudA , int noeudB)
        {
            

            this.matrix[noeudB-1, noeudA-1] = 1;
            this.matrix[noeudA-1, noeudB-1] = 1;

        }
        public void ParcoursEnLargeur(Noeud ActualNode)
        /// méthode itérative de parcours
        ///Actual Node est le noeud actuel ou en est l'algorithme de parcours il commence par le noeud renseigné par l'utiliisateur ( j'ai commencé au noeud 1)
        {///J'utilise une File (propriété FIFO nécéssaire pour ce type de parcours)
            Console.WriteLine("Parcours en largeur d'abord du graphe ");
            Queue<Noeud> File = new Queue<Noeud> ();
            List<int> IdNodeIsExplored = new List<int>();

            File.Enqueue(graphe[ActualNode.Noeud_Id]);
            int count = 0;
            while (File.Count != 0)
            {
                ActualNode= (File.Dequeue());
                Console.WriteLine("Noeud n°" + ((ActualNode.Noeud_Id)+1));

                foreach (Noeud NoeudVoisin in ActualNode.Relations) 
                {
                    if(!IdNodeIsExplored.Contains(NoeudVoisin.Noeud_Id))
                    {
                        File.Enqueue(NoeudVoisin);
                        IdNodeIsExplored.Add(NoeudVoisin.Noeud_Id);
                    }
                    if (IdNodeIsExplored.Contains(NoeudVoisin.Noeud_Id))
                    {
                        count++;
                    }
                
                
                }             
            }
            if (IdNodeIsExplored.Count == this.ordre) Console.WriteLine($"Le graphe {nom_de_graphe} est connexe");
            if (IdNodeIsExplored.Count < this.ordre) Console.WriteLine($"Le graphe {nom_de_graphe} n'est pas connexe");
            if (count > 0) Console.WriteLine($"Le graphe contient des cycles");
            Console.WriteLine(" end ");          

        }

        public void ParcoursEnProfondeur (Noeud ActualNode)/// méthode itérative de parcours
        {///Actual Node est le noeud actuel ou en est l'algorithme de parcours il commence par le noeud renseigné par l'utiliisateur ( j'ai commencé au noeud 1)
            ///J'utilise une Pile (propriété FILO nécéssaire pour ce type de parcours)
            Console.WriteLine("Parcours en profondeur d'abord du graphe ");
            Stack<Noeud> Pile = new Stack<Noeud>();
            Pile.Push(ActualNode);
            List<int> IdNodeIsExplored = new List<int>();
            while (Pile != null && Pile.Count >0)
            {
                Console.WriteLine("Noeud n°" + ((ActualNode.Noeud_Id) + 1));
                IdNodeIsExplored.Add(ActualNode.Noeud_Id);
                foreach (Noeud Node in ActualNode.Relations)
                {
                    if (!IdNodeIsExplored.Contains(Node.Noeud_Id) && !Pile.Contains(Node))
                    {
                        Pile.Push(Node);
                    }
                }
                ActualNode = Pile.Pop();               

            }
        }

        
        
        
        public void MatrixtoString()
        {
            
            for( int i =-1; i<matrix.GetLength(0); i++)
            {
                if (i >-1) 
                {
                    if (i < 9)
                    {
                        Console.Write( " " + (i+1)+"   ");
                    }
                    else
                    {
                        Console.Write( (i+1)+"   ");
                    }
                }
                if (i == -1)
                {
                    Console.Write("   ");
                }


                for ( int j =0;j<matrix.GetLength(1); j++)
                {
                    if(i == -1)
                    {                        
                        if (j < 10)
                        {
                            Console.Write("  "+(j+1) );
                        }
                        else
                        {
                            Console.Write(" "+(j +1) );
                        }
                    }
                    else 
                    { 
                        if(matrix[i, j] < 10)
                        {
                            Console.Write(matrix[i, j] + "  ");
                        }
                        else
                        {
                            Console.Write(matrix[i, j] + " ");
                        }
                       
                    }
                    
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine($"Ci dessus la matrice du graphe :{nom_de_graphe} de taille {taille} et d'ordre {ordre}.");
            Console.WriteLine();
        }/// Affichage dans la console de la matrice d'adjacence
        

    }

    
}
