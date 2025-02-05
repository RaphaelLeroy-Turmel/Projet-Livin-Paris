﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProjetGraphe
{
    internal class Graphe
    {
        private string nom_de_graphe = "";
        private int[,] matrix = new int[,] { };
        private string filename = "";
        private int taille = 0;/// nombre d'arêtes
        private int ordre = 0;/// nombre de sommets/noeuds
        private Noeud[] graphe = new Noeud[0];


        public Noeud[] GetGraphe
        {
            get { return graphe; }
            set { graphe = value; }
        }
        
        public Graphe(string nom,string filename) 
        {
            this.nom_de_graphe = nom;
            this.filename = filename;
            
            StreamReader sr = new StreamReader(this.filename);
            sr.ReadLine();
            bool p = false;
            string[] relation=new string[0];
            int b = 0;
            string line = sr.ReadLine();
            while (sr!=null)
            {
                
                
                if (line[0] != '%')
                {
                    p = true;
                    b++;
                }
                if( p & b == 1)
                {
                    relation = line.Split(' ');
                    this.ordre = Convert.ToInt32(relation[0]);
                    graphe = new Noeud[ordre];
                    matrix = new int[ordre, ordre];/// on sait que la matrice est carré et symétrique car les relations entre les membres sont réciproques
                }
                if (p & (b>1))
                {
                    relation = line.Split(' ');
                    int A = Convert.ToInt32(relation[0]); /// noeud A
                    int B = Convert.ToInt32(relation[1]); /// noeud B
                    this.matrix[A-1 , B-1 ] = 1;
                    Console.WriteLine($"a :{A} , B :{B} ");
                    this.matrix[B-1 , A-1] = 1;
                    taille++;
                }

                line = sr.ReadLine();
            }
            CréerGraphe();
        
        }
        

        public void CréerGraphe()
        {
            this.graphe = new Noeud[ordre];
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
        public void ParcoursEnLargeur(int NodeNumber)
        {
            Console.WriteLine("Parcours en largeur du graphe ");
            bool p = true;
            Queue<Noeud> File = new Queue<Noeud> ();
            List<int> NodeIsExplored = new List<int>();
            File.Enqueue(graphe[NodeNumber]);
            while (p)
            {
                int count = 0;
                 NodeNumber = (File.Dequeue()).Noeud_Id;
                Console.WriteLine("Noeud n°" + (NodeNumber+1));
                
                while (count < this.graphe[NodeNumber].Relations.Count)
                {

                    if (!NodeIsExplored.Contains(count))
                    {
                        File.Enqueue(graphe[count]);
                        NodeIsExplored.Add(count);
                    }
                    count++;
                   
                }
                if(File.Count == 0)
                {
                    p = false;
                }

            }
            Console.WriteLine(" end ");
            

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
