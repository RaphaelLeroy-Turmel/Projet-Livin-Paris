using Microsoft.VisualBasic;
using QuickGraph.Algorithms.MaximumFlow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Collections.Specialized.BitVector32;

namespace ProjetGraphe///Raphael_LEROY_TURMEL_Thomas_LIOTIER_Loan_LU_CHI_VANG
{
    public class Graphe<T>
    {
        private string nom_de_graphe = "";
        private int[,] AdjencyMatrix = new int[,] { };/// matrice d'adjacence
        
        private int taille = 0;/// nombre d'arêtes
        private int ordre = 0;/// nombre de sommets/noeuds
        
        private List<Noeud<T>> ListeDeNoeuds = new List<Noeud<T>>();


        
        public int[,] Matrix
        {
            get { return AdjencyMatrix; }
            set { AdjencyMatrix = value; }
        }

        public Graphe(string nom, string filename1, string filename2)
        {
            this.nom_de_graphe = nom;
            ListeDeNoeuds = new List<Noeud<T>>();
            
            StreamReader sr = new StreamReader(filename1);
            sr.ReadLine(); // Ignore la première ligne 

            string line = sr.ReadLine();
            while (line != null)
            {
                string[] colonne = line.Split(';'); 
                

                // Vérification du nombre de colonnes (évite IndexOutOfRangeException)
                if (colonne.Length < 7)
                {
                    Console.WriteLine($"Ligne ignorée : {line} (données incomplètes)");
                    line = sr.ReadLine();
                    continue;
                }

                // Conversion de ID Station
                int IdStation = Convert.ToInt32(colonne[0]);
                if (int.TryParse(colonne[1], out int LibelleLigne))
                {
                    //Console.WriteLine($"Conversion réussie : {LibelleLigne}");
                }
                else
                {
                    Console.WriteLine($"Erreur de conversion : '{colonne[1]}' n'est pas un entier valide.");
                }

                string LibelleStation = colonne[2];
                double Longitude = Convert.ToDouble(colonne[3], CultureInfo.InvariantCulture);/// CultureInfo.Invariant permet de convertir en double peut importante si le séparateur décimal est un point ou une virgule
                double Latitude = Convert.ToDouble(colonne[4], CultureInfo.InvariantCulture);
                
                // Création d'un objet station
                Station station = new Station(IdStation, LibelleLigne, LibelleStation, Longitude, Latitude);
                
                // Création d'un noeud générique dans lequel on met une station qui dérive de T
                Noeud<T> noeud = new Noeud<T>(IdStation, (T)(object)station);
                if (noeud.element is Station stationElement)
                {
                    stationElement.AddLigne(LibelleLigne);                   
                }
                else
                {
                    Console.WriteLine("Le type de noeud.element n'est pas Station.");
                }

                ListeDeNoeuds.Add(noeud);
                
                line = sr.ReadLine(); // Lire la ligne suivante
            }

            AddArcs(filename2);
            SuppDoublons();

            AdjencyMatrix = MatriceAdjacence();

            //foreach (Noeud<T> noeud in ListeDeNoeuds)
            //{
            //    if (noeud.element is Station stationElement)
            //    {
            //        Console.WriteLine(stationElement.toString() + "hehe            " + stationElement.ListeDesLignes.Count());
            //    }

            //}

            //SuppDoublons(); // on supprime et fusionne les stations en doublons
            sr.Close();
            foreach(Noeud<T> noeud in ListeDeNoeuds) {
                if (noeud.element is Station stationElement)
                {
                    Console.WriteLine(stationElement.StationtoString());
                }
            }


        }


        public void AddArcs(string filename2)
        {/// on lit la feuille n°2 qui contient les arcs
            StreamReader Lecteur = new StreamReader(filename2);
            Lecteur.ReadLine(); // Ignore la première ligne 

            string line = Lecteur.ReadLine();
            while (line != null )
            {
                string[] colonne = line.Split(';');

                int stationID = Convert.ToInt32(colonne[0]);
                string stationLibelle = colonne[1];
                int IDprécédent = 0;
                int IDSuivant = 0;
                int tempsTrajet = 0;
                if ( colonne[2]!= "")
                {
                     IDprécédent = Convert.ToInt32(colonne[2]);
                }
                if (colonne[3] != "")
                {
                     IDSuivant = Convert.ToInt32(colonne[3]);
                }
                if (colonne[4] != "")
                {
                     tempsTrajet = Convert.ToInt32(colonne[4]);
                }
                //if (colonne[4] == "")
                //{
                //    Random random = new Random();
                //    int randomNumber = random.Next(1, 6);
                //    tempsTrajet = randomNumber;
                //}
                if (colonne[5] != "")
                {
                    int tempsChangement = Convert.ToInt32(colonne[5]);
                }

                Noeud<T> Station = ListeDeNoeuds[stationID - 1];
                Noeud<T> StationPrécédente = null;
                Noeud<T> StationSuivante = null;
                if (IDprécédent > 0) {
                    StationPrécédente = ListeDeNoeuds[IDprécédent - 1];
                }
                if(IDSuivant < 332 && IDSuivant>2) {

                    StationSuivante = ListeDeNoeuds[IDSuivant - 1]; 
                }
                
                if (StationPrécédente != null && Station.element is Station stationElmnt && StationPrécédente.element is Station stationElmntPré )
                {
                    if (stationElmnt.ListeDesLignes[0] == stationElmntPré.ListeDesLignes[0])
                    {
                        
                        Lien<T> LienE = new Lien<T>(StationPrécédente, Station);
                        LienE.tempsTrajet = tempsTrajet;
                        Station.relationsEntrantes.Add(LienE);
                        Console.WriteLine(" temps de trajet entrant" +LienE.tempsTrajet);


                    }

                }
                if (StationSuivante != null && Station.element is Station stationElmnt1  && StationSuivante.element is Station stationElmntSui)
                {
                   
                    if (stationElmnt1.ListeDesLignes[0] == stationElmntSui.ListeDesLignes[0])
                    {                        
                        Lien<T> LienS = new Lien<T>(Station, StationSuivante);
                        LienS.tempsTrajet = tempsTrajet;                        
                        Station.relationsSortantes.Add(LienS);
                        Console.WriteLine(" temps de trajet sortant" +LienS.tempsTrajet);
                    }                   

                }



                line = Lecteur.ReadLine(); // Lire la ligne suivante
            }
            Lecteur.Close();

        }

        public void SuppDoublons()
        {
            foreach (Noeud<T> noeudA in ListeDeNoeuds)
            {
                foreach (Noeud<T> noeudB in ListeDeNoeuds)
                {
                    if (noeudA.element is Station SA && noeudB.element is Station SB)
                    {
                        if ( SA.Id != SB.Id && SB.LibelleStation == SA.LibelleStation)
                        {
                            string LA = String.Join(" ", SA.ListeDesLignes);

                            foreach (Lien<T> lienE in noeudB.relationsEntrantes)
                            {
                                if (!noeudA.relationsEntrantes.Contains(lienE))
                                {
                                    noeudA.relationsEntrantes.Add(lienE);                                    
                                }

                            }
                            foreach (Lien<T> lienS in noeudB.relationsSortantes)
                            {
                                if (!noeudA.relationsSortantes.Contains(lienS))
                                {
                                    noeudA.relationsSortantes.Add(lienS);
                                    
                                }

                            }
                            SA.AddLigne(SB.ListeDesLignes[0]);

                            //string LB = String.Join(" ", SB.ListeDesLignes);
                            //Console.WriteLine($" lignes de A : {LA} et lignes de B : {LB}");
                            //string AB = String.Join("", SA.ListeDesLignes);
                            //Console.WriteLine($"ligne finale : ");
                            //foreach (int ligneID in SA.ListeDesLignes) { Console.WriteLine(ligneID); }
                        }
                        
                    }
                }
            }
           
        }

        static int LigneCommune(Station stationA, Station stationB)
        {
            foreach( int ligneA in stationA.ListeDesLignes)
            {
                foreach(int ligneB in stationB.ListeDesLignes)
                {
                    if(ligneA == ligneB) { return ligneA; }
                }
            }
            return -1;
        }

        // Méthode pour vérifier si une station existe déjà dans le graphe
        private Noeud<T> ContientStation(List<Noeud<T>> liste, string libelle)
        {
            foreach (var noeud in liste)
            {
                if (noeud.element is Station station && station.LibelleStation == libelle)
                {
                    return noeud;
                }
            }
            return null;
        }
        
        public int[,] MatriceAdjacence()
        {
            int[,] matrice = new int[331, 331];
            foreach( Noeud<T> noeud in ListeDeNoeuds)
            {
                foreach(Lien<T> lien in noeud.relationsEntrantes)
                {
                    matrice[lien.noeudDépart.noeud_id, lien.noeudArrivé.noeud_id] = -(lien.tempsTrajet);
                    matrice[lien.noeudArrivé.noeud_id, lien.noeudDépart.noeud_id] = -(lien.tempsTrajet);
                }
                foreach (Lien<T> lien in noeud.relationsSortantes)
                {
                    matrice[lien.noeudDépart.noeud_id, lien.noeudArrivé.noeud_id] = (lien.tempsTrajet);
                    matrice[lien.noeudArrivé.noeud_id, lien.noeudDépart.noeud_id] = (lien.tempsTrajet);
                }

            }
            return matrice;
        }
        public void VérifLien()
        {
            foreach (Noeud<T> noeud in ListeDeNoeuds)
            {
                foreach (Lien<T> lien in noeud.relationsEntrantes)
                {
                    Console.WriteLine(lien.noeudArrivé.noeud_id+" temps de trajet : " + lien.tempsTrajet);
                }
                foreach (Lien<T> lien in noeud.relationsSortantes)
                {
                    Console.WriteLine(lien.noeudArrivé.noeud_id + " temps de trajet : " + lien.tempsTrajet);
                }

            }
        }



        /*
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
                    graphe = new Noeud<T>[ordre];
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
        */

        //public void CréerGraphe()
        //{

        //    for(int i=0 ; i < matrix.GetLength(0) ; i++)
        //    {
        //        Noeud<Station> X = new Noeud<Station>(i);///on créer un noeud n°i
        //        ListeDeNoeuds[i] = X; /// on ajoute ce noeud au tableau de noeud (le graphe)

        //    }
        //    for (int i = 0; i < matrix.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < matrix.GetLength(1); j++)
        //        {
        //            if (matrix[i, j] == 1)
        //            {
        //                this.ListeDeNoeuds[i].Relations.Add(ListeDeNoeuds[j]);

        //            }
        //        }

        //    }


        //}




        //public void ParcoursEnLargeur(Noeud<Station> ActualNode)
        ///// méthode itérative de parcours
        /////Actual Node est le noeud actuel ou en est l'algorithme de parcours il commence par le noeud renseigné par l'utiliisateur ( j'ai commencé au noeud 1)
        //{///J'utilise une File (propriété FIFO nécéssaire pour ce type de parcours)
        //    Console.WriteLine("Parcours en largeur d'abord du graphe ");
        //    Queue<Noeud<Station>> File = new Queue<Noeud<Station>> ();
        //    List<int> IdNodeIsExplored = new List<int>();

        //    File.Enqueue(ListeDeNoeuds[ActualNode.element.id]);
        //    int count = 0;
        //    while (File.Count != 0)
        //    {
        //        ActualNode= (File.Dequeue());
        //        Console.WriteLine("Noeud n°" + ((ActualNode.Noeud_Id)+1));

        //        foreach (Noeud<Station> NoeudVoisin in ActualNode.Relations) 
        //        {
        //            if(!IdNodeIsExplored.Contains(NoeudVoisin.Noeud_Id))
        //            {
        //                File.Enqueue(NoeudVoisin);
        //                IdNodeIsExplored.Add(NoeudVoisin.Noeud_Id);
        //            }
        //            if (IdNodeIsExplored.Contains(NoeudVoisin.Noeud_Id))
        //            {
        //                count++;
        //            }


        //        }             
        //    }
        //    if (IdNodeIsExplored.Count == this.ordre) Console.WriteLine($"Le graphe {nom_de_graphe} est connexe");
        //    if (IdNodeIsExplored.Count < this.ordre) Console.WriteLine($"Le graphe {nom_de_graphe} n'est pas connexe");
        //    if (count > 0) Console.WriteLine($"Le graphe contient des cycles");
        //    Console.WriteLine(" end ");          

        //}

        //public void ParcoursEnProfondeur (Noeud<T> ActualNode)/// méthode itérative de parcours
        //{///Actual Node est le noeud actuel ou en est l'algorithme de parcours il commence par le noeud renseigné par l'utiliisateur ( j'ai commencé au noeud 1)
        //    ///J'utilise une Pile (propriété FILO nécéssaire pour ce type de parcours)
        //    Console.WriteLine("Parcours en profondeur d'abord du graphe ");
        //    Stack<Noeud<T>> Pile = new Stack<Noeud<T>>();
        //    Pile.Push(ActualNode);
        //    List<int> IdNodeIsExplored = new List<int>();
        //    while (Pile != null && Pile.Count >0)
        //    {
        //        Console.WriteLine("Noeud n°" + ((ActualNode.Noeud_Id) + 1));
        //        IdNodeIsExplored.Add(ActualNode.Noeud_Id);
        //        foreach (Noeud<T> Node in ActualNode.Relations)
        //        {
        //            if (!IdNodeIsExplored.Contains(Node.Noeud_Id) && !Pile.Contains(Node))
        //            {
        //                Pile.Push(Node);
        //            }
        //        }
        //        ActualNode = Pile.Pop();               

        //    }
        //}

        public void AfficheMatrice()
        {
            for(int i =0; i< AdjencyMatrix.GetLength(0); i++)
            {
                for(int j =0; j<AdjencyMatrix.GetLength(1); j++)
                {
                    Console.Write( AdjencyMatrix[i, j] +"  ");
                }

            }
        }
        
        
        public void MatrixtoString()
        {
            
            for( int i =-1; i<AdjencyMatrix.GetLength(0); i++)
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


                for ( int j =0;j<AdjencyMatrix.GetLength(1); j++)
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
                        if(AdjencyMatrix[i, j] < 10)
                        {
                            Console.Write(AdjencyMatrix[i, j] + "  ");
                        }
                        else
                        {
                            Console.Write(AdjencyMatrix[i, j] + " ");
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
