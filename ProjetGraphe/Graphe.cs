using ProjetGraphe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;


namespace TEST_Projet_Livin_Paris
{
    internal class Graphe<T>
    {
        public int[,] MatriceAdjacence;
        public Dictionary<int, Noeud<T>> DictionnaireDeNoeuds;
        public Graphe(string filename1, string filename2)
        {
            DictionnaireDeNoeuds = new Dictionary<int, Noeud<T>>();
            using (var sr = new StreamReader(filename1, Encoding.UTF8))  // Utilisation du StreamReader avec encodage UTF-8
            {
                sr.ReadLine();
                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] colonnes = line.Split(';');
                    int IdStation = -1;
                    if (colonnes[0] != null && colonnes[0].Length > 0)
                    {
                        IdStation = Convert.ToInt32(colonnes[0]);
                    }
                    if (colonnes[0] == null || colonnes[0].Length <= 0)
                    {
                        Console.WriteLine("colonnes[0] est null ou vide");
                    }
                    float LibLigne = 0;
                    if (colonnes[1].Contains("bis"))
                    {
                        int indexBis = colonnes[1].IndexOf("bis");
                        string numLigneTemp = colonnes[1].Substring(0, indexBis).Trim();
                        if (float.TryParse(numLigneTemp, out float a))
                        {
                            a += 0.5f;
                            LibLigne = a;
                        }
                        else
                        {
                            Console.WriteLine("erreur à la ligne bis : " + colonnes[1]);
                            LibLigne = -1;
                        }
                    }
                    string LibStation = null;
                    if (colonnes[2] != null && colonnes[2].Length > 0)
                    {
                        LibStation = colonnes[2];
                        

                    }

                    if (LibStation == null) { Console.WriteLine("Libstation est null !! -----------------------------------------------"); }
                    if (colonnes[2] == null) { Console.WriteLine("colonnes[2] est null !! -----------------------------------------------"); }

                    double Longitude = 0;
                    if (colonnes[3] != null && colonnes[3].Length > 0)
                    {
                        Longitude = Convert.ToDouble(colonnes[3], CultureInfo.InvariantCulture);
                    }
                    double Latitude = 0;
                    if (colonnes[4] != null && colonnes[4].Length > 0)
                    {
                        Latitude = Convert.ToDouble(colonnes[4], CultureInfo.InvariantCulture);
                    }

                    Station station = new Station(IdStation, LibLigne, LibStation, Longitude, Latitude);
                    Noeud<T> noeud = new Noeud<T>(IdStation, (T)(object)station);
                    if (noeud.element is Station stationElement)
                    {
                        stationElement.ListeLibelleLigne.Add(LibLigne);
                    }
                    else
                    {
                        Console.WriteLine("Le type de noeud.element n'est pas Station.");
                    }
                    DictionnaireDeNoeuds.Add(IdStation, noeud);
                    line = sr.ReadLine();

                }
            }
            AjouteArcs(filename2);
            SupprimeDoublons();            
            VérifConcordanceId();
            MatriceAdjacence = CréerMatriceAdjacence(filename1, 333);            
        }


        public void AjouteArcs(string filename)
        {
            try
            {
                if (!File.Exists(filename))
                {
                    Console.WriteLine($"Le fichier '{filename}' n'existe pas.");
                    return;
                }

                using (StreamReader sr = new StreamReader(filename))
                {
                    sr.ReadLine();
                    string line = sr.ReadLine();
                    while (line != null)
                    {
                        string[] colonnes = line.Split(';');
                        int IdStation = -1;
                        if (colonnes[0] != null && colonnes[0] != "" && int.TryParse(colonnes[0], out IdStation))
                        {
                            IdStation = Convert.ToInt32(colonnes[0]);
                        }
                        else
                        {
                            // Erreur : valeur non convertible
                            Console.WriteLine("Impossible de convertir la valeur : " + colonnes[0]);
                        }

                        string LibStation = colonnes[1];
                        int IdStationPrécédente = -1;
                        if (colonnes[2] != null && colonnes[2].Length > 0)
                        {
                            IdStationPrécédente = int.Parse(colonnes[2]);
                        }
                        int IdStationSuivante = -1;
                        if (colonnes[3] != null && colonnes[3].Length > 0)
                        {
                            IdStationSuivante = int.Parse(colonnes[3]);
                        }
                        int TempsEntre2Stations = 2;
                        int TempsDeChangement = 2;
                        if (!DictionnaireDeNoeuds.ContainsKey(IdStation)) { Console.WriteLine("Ne contient pas station n°" + IdStation); }
                        //if(!DictionnaireDeNoeuds.ContainsKey(IdStationPrécédente)) { Console.WriteLine("Ne contient pas station précédente n°" + IdStationPrécédente+LibStation); }
                        //if(!DictionnaireDeNoeuds.ContainsKey(IdStationSuivante)){ Console.WriteLine("Ne contient pas station suivante n°" + IdStationSuivante + LibStation); }

                        //Console.WriteLine("Libell station : " + LibStation);

                        if (IdStationPrécédente != -1 && IdStation != 0 && DictionnaireDeNoeuds.ContainsKey(IdStation) && DictionnaireDeNoeuds.ContainsKey(IdStationPrécédente))
                        {
                            Noeud<T> noeudStation = DictionnaireDeNoeuds[IdStation];
                            Lien<T> lienSortantPrécédent = new Lien<T>(DictionnaireDeNoeuds[IdStation], DictionnaireDeNoeuds[IdStationPrécédente], TempsEntre2Stations);
                            Lien<T> lienEntrantPrécédent = new Lien<T>(DictionnaireDeNoeuds[IdStationPrécédente], DictionnaireDeNoeuds[IdStation], TempsEntre2Stations);
                            if (!noeudStation.ArcsEntrants.Contains(lienEntrantPrécédent))
                            {
                                noeudStation.ArcsEntrants.Add(lienEntrantPrécédent);
                            }

                            if (!noeudStation.ArcsSortants.Contains(lienSortantPrécédent))
                            {
                                noeudStation.ArcsSortants.Add(lienSortantPrécédent);
                            }


                        }
                        if (IdStationSuivante != -1 && IdStation != 0 && DictionnaireDeNoeuds.ContainsKey(IdStation) && DictionnaireDeNoeuds.ContainsKey(IdStationSuivante))
                        {
                            Noeud<T> noeudStation = DictionnaireDeNoeuds[IdStation];
                            Lien<T> lienSortantSuivant = new Lien<T>(DictionnaireDeNoeuds[IdStation], DictionnaireDeNoeuds[IdStationSuivante], TempsEntre2Stations);
                            Lien<T> lienEntrantSuivant = new Lien<T>(DictionnaireDeNoeuds[IdStationSuivante], DictionnaireDeNoeuds[IdStation], TempsEntre2Stations);
                            if (!noeudStation.ArcsEntrants.Contains(lienEntrantSuivant))
                            {
                                noeudStation.ArcsEntrants.Add(lienEntrantSuivant);
                            }
                            if (!noeudStation.ArcsSortants.Contains(lienSortantSuivant))
                            {
                                noeudStation.ArcsSortants.Add(lienSortantSuivant);
                            }

                        }
                        else
                        {
                            //Console.WriteLine($"Une des stations (IdStation : {IdStation}, IdStationPrécédente : {IdStationPrécédente}, IdStationSuivante : {IdStationSuivante}) n'existe pas dans le dictionnaire.");
                        }

                        line = sr.ReadLine(); // Lire la ligne suivante
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Erreur : Le fichier '{filename}' est introuvable. Détails : {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Erreur de lecture du fichier '{filename}'. Détails : {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Une erreur inattendue s'est produite. Détails : {ex.Message}");
            }
        }
        public bool VérifConcordanceId()
        {
            foreach (Noeud<T> noeud in DictionnaireDeNoeuds.Values)
            { /// vérifie que les Indices du noeud et de sa stations sont les memes
                if (noeud.element is Station station)
                {
                    if (noeud.Id != station.Id)
                    {
                        Console.WriteLine($"ERREURl'id du noeud : {noeud.Id} n'es pas le meme que sa station!'");
                        return false;
                    }

                }

            }
            Console.WriteLine("Tous les id des noeud et de leur station sont concordant.");
            return true;

        }
        public void SupprimeDoublons()
        {
            List<int> idsSupprimes = new List<int>(); /// Liste pour garder une trace des Id des noeuds à supprimer
            foreach (Noeud<T> noeudA in DictionnaireDeNoeuds.Values)
            {
                foreach (Noeud<T> noeudB in DictionnaireDeNoeuds.Values)
                {
                    if (noeudA.Id != noeudB.Id && noeudA.GetLibStation() == noeudB.GetLibStation() && noeudB is Station stationB)
                    {
                        foreach (Lien<T> LienE in noeudB.ArcsEntrants)
                        {
                            noeudA.ArcsEntrants.Add(LienE);
                        }
                        foreach (Lien<T> LienS in noeudB.ArcsSortants)
                        {
                            noeudA.ArcsSortants.Add(LienS);
                        }
                        foreach (float ligne in stationB.ListeLibelleLigne)
                        {
                            noeudA.AddLigne(ligne);
                        }
                        /// on supprime alors le noeud B 
                        idsSupprimes.Add(noeudB.Id);
                    }
                }
            }
            /// Suppression des noeuds marqués
            foreach (int id in idsSupprimes)
            {
                Console.WriteLine($"Suppressioin de la station en double : {DictionnaireDeNoeuds[id]}");
                DictionnaireDeNoeuds.Remove(id);
            }
        }
        public void SupprimeDoublon(Dictionary<int , Noeud<T>> DictionnaireDeNoeud)
        {
            // Groupement des stations par nom
            var groupes = DictionnaireDeNoeud.Values
                .GroupBy(n => n.GetLibStation())
                .Where(g => g.Count() > 1);

            foreach (var groupe in groupes)
            {
                // Choix d'un nœud principal à garder
                var noeudPrincipal = groupe.First();
                var noeudsADefusionner = groupe.Skip(1).ToList();

                foreach (var doublon in noeudsADefusionner)
                {
                    // Fusion des lignes (si Station)
                    if (doublon is Station stationDoublon)
                    {
                        foreach (var ligne in stationDoublon.ListeLibelleLigne)
                            noeudPrincipal.AddLigne(ligne);
                    }

                    // Rediriger les arcs sortants du doublon vers le noeud principal
                    foreach (var arcSortant in doublon.ArcsSortants)
                    {
                        var nouveauLien = new Lien<T>(noeudPrincipal, arcSortant.NoeudArrivée, arcSortant.Poids);
                        if (!ExisteDeja(noeudPrincipal.ArcsSortants, nouveauLien))
                            noeudPrincipal.ArcsSortants.Add(nouveauLien);
                    }

                    // Rediriger les arcs entrants du doublon vers le noeud principal
                    foreach (var arcEntrant in doublon.ArcsEntrants)
                    {
                        var nouveauLien = new Lien<T>(arcEntrant.NoeudDépart, noeudPrincipal, arcEntrant.Poids);
                        if (!ExisteDeja(noeudPrincipal.ArcsEntrants, nouveauLien))
                            noeudPrincipal.ArcsEntrants.Add(nouveauLien);
                    }

                    // Mise à jour des arcs dans les autres noeuds
                    foreach (var n in DictionnaireDeNoeud.Values)
                    {
                        // Corriger les arcs sortants
                        for (int i = 0; i < n.ArcsSortants.Count; i++)
                        {
                            if (n.ArcsSortants[i].NoeudArrivée.Id == doublon.Id)
                            {
                                n.ArcsSortants[i].NoeudArrivée = noeudPrincipal;
                            }
                        }

                        // Corriger les arcs entrants
                        for (int i = 0; i < n.ArcsEntrants.Count; i++)
                        {
                            if (n.ArcsEntrants[i].NoeudDépart.Id == doublon.Id)
                            {
                                n.ArcsEntrants[i].NoeudDépart = noeudPrincipal;
                            }
                        }
                    }

                    // Suppression du doublon du dictionnaire
                    //Console.WriteLine($"Suppression de la station en double : {doublon.GetLibStation()} (id {doublon.Id})");
                    DictionnaireDeNoeud.Remove(doublon.Id);
                }
            }
        }

        // Méthode d'aide pour éviter d'ajouter deux fois le même arc (même départ, arrivée, poids)
        private bool ExisteDeja(List<Lien<T>> liste, Lien<T> nouveau)
        {
            return liste.Any(l =>
                l.NoeudDépart.Id == nouveau.NoeudDépart.Id &&
                l.NoeudArrivée.Id == nouveau.NoeudArrivée.Id &&
                l.Poids == nouveau.Poids);
        }

        public int[,] CréerMatriceAdjacence(string filename, int size)
        {
            int count = 0;

            int[,] Matrice = new int[size, size];
            foreach (Noeud<T> noeud in DictionnaireDeNoeuds.Values)
            {
                if (noeud != null)
                {
                    count++;
                    if (noeud.ArcsEntrants != null)
                    {
                        foreach (Lien<T> lienE in noeud.ArcsEntrants)
                        {
                            Matrice[lienE.NoeudArrivée.Id, lienE.NoeudDépart.Id] = lienE.Poids;
                            Matrice[lienE.NoeudDépart.Id, lienE.NoeudArrivée.Id] = lienE.Poids;
                            //Console.WriteLine(lienE.toString());
                            if (lienE.NoeudDépart.element is Station nodeElementD && lienE.NoeudArrivée.element is Station nodeElementA)
                            {
                                if (nodeElementD.Id != lienE.NoeudDépart.Id || lienE.NoeudArrivée.Id != nodeElementA.Id)
                                {
                                    Console.WriteLine("error");
                                }
                            }
                        }
                    }
                    if (noeud.ArcsEntrants == null)
                    {
                        Console.WriteLine(" Problème génération matrice ArcsEntrant est nulle");
                    }
                    if (noeud.ArcsSortants != null)
                    {
                        foreach (Lien<T> lienS in noeud.ArcsSortants)
                        {
                            Matrice[lienS.NoeudArrivée.Id, lienS.NoeudDépart.Id] = lienS.Poids;
                            Matrice[lienS.NoeudDépart.Id, lienS.NoeudArrivée.Id] = lienS.Poids;
                            //Console.WriteLine($" NoeudDépart.Id : {lienS.NoeudDépart.Id} --> NoeudArrivée.Id : {lienS.NoeudArrivée.Id} : {lienS.Poids}");
                            //Console.WriteLine(lienS.toString());
                            if (lienS.NoeudDépart.element is Station nodeElementD && lienS.NoeudArrivée.element is Station nodeElementA)
                            {
                                if (nodeElementD.Id != lienS.NoeudDépart.Id || lienS.NoeudArrivée.Id != nodeElementA.Id)
                                {
                                    Console.WriteLine("error2");
                                }
                            }
                        }
                    }
                    if (noeud.ArcsSortants == null)
                    {
                        //Console.WriteLine(" Problème génération matrice ArcsSortant est nulle");
                    }

                }

            }
            Console.WriteLine("count de noeud e la matrice :" + count);
            return Matrice;

        }
        public void AfficherMatrice()
        {
            // Obtenir les dimensions de la matrice
            int lignes = MatriceAdjacence.GetLength(0);
            int colonnes = MatriceAdjacence.GetLength(1);

            // Afficher un en-tête pour les colonnes
            Console.Write("    ");
            for (int j = 0; j < colonnes; j++)
            {
                Console.Write($"{j,3} ");
            }
            Console.WriteLine();

            // Afficher une ligne de séparation
            Console.Write("    ");
            for (int j = 0; j < colonnes; j++)
            {
                Console.Write("----");
            }
            Console.WriteLine();

            // Afficher chaque ligne avec son indice
            for (int i = 0; i < lignes; i++)
            {
                Console.Write($"{i,2} | ");
                for (int j = 0; j < colonnes; j++)
                {
                    Console.Write($"{MatriceAdjacence[i, j],3} ");
                }
                Console.WriteLine();
            }
        }
        public void LireMatriceAdjacence()
        {
            for (int i = 0; i < MatriceAdjacence.GetLength(0); i++)
            {
                for (int j = 0; j < MatriceAdjacence.GetLength(1); j++)
                {
                    if (MatriceAdjacence[i, j] != 0)
                    {
                        DictionnaireDeNoeuds.TryGetValue(i, out var Nodei);
                        DictionnaireDeNoeuds.TryGetValue(j, out var Nodej);

                        Console.WriteLine($"{Nodei.Id}: {Nodei.GetLibStation()} <---> {Nodej.Id} : {Nodej.GetLibStation()}");
                    }
                }
            }
        }
        public void ListerLesLiensDeNoeud(string NomDeNoeud)
        {
            foreach (Noeud<T> station in DictionnaireDeNoeuds.Values)
            {
                if (station.element is Station elementstation)
                {
                    if (elementstation.LibelleStation == NomDeNoeud)
                    {
                        Console.Write($"Lien entrant dans {elementstation.LibelleStation} : ");
                        foreach (Lien<T> Lien in station.ArcsEntrants)
                        {
                            Console.Write(Lien.toString() + "      ");
                        }
                        Console.WriteLine();
                        Console.Write("lien sortant : ");
                        foreach (Lien<T> Lien in station.ArcsSortants)
                        {
                            Console.Write(Lien.toString() + "      ");
                        }
                        Console.WriteLine();
                    }
                }
            }
        }
        //public void PCC(string LibelleStart, string LibelleEnd)
        //{
        //    int IdStart = GetIdStationFromLibelle(LibelleStart);
        //    int IdEnd = GetIdStationFromLibelle(LibelleEnd);

        //    int[] distances = Dijkstra(IdStart);
        //    Console.WriteLine($"Plus court chemin de {LibelleStart} à {IdEnd} : ");
        //    for (int i = 0; i < IdEnd - 1; i++)
        //    {
        //        Console.Write(distances[i] + " --> ");

        //    }
        //    Console.WriteLine("Vous êtes arrivés ! (coût du chemin : ")

        //}
        public List<Station> PCC(string LibelleStart, string LibelleEnd)
        {
            // Trouver les IDs des stations à partir des libellés
            Dictionary<int, Noeud<T>> DictionnaireDeNoeud = new Dictionary<int, Noeud<T>>(DictionnaireDeNoeuds);
            SupprimeDoublon(DictionnaireDeNoeud);
            int startId = -1, endId = -1;
            List<Station> ListeStationChemin = new List<Station>();
            foreach (var kvp in DictionnaireDeNoeud)
            {
                if (kvp.Value.GetLibStation() == LibelleStart) { startId = kvp.Key; }
                    
                if (kvp.Value.GetLibStation() == LibelleEnd) { endId = kvp.Key; }
                    
            }

            if (startId == -1 || endId == -1)
            {
                Console.WriteLine("Station non trouvée.");
                return null;
            }
            //foreach (var kvp in DictionnaireDeNoeud)
            //{
            //    Console.WriteLine($"Station {kvp.Key} - {kvp.Value.GetLibStation()} a {kvp.Value.ArcsSortants.Count} voisins.");
            //}

            /// Exécution de Dijkstra
            var (pred, distances) = Dijkstra(startId, DictionnaireDeNoeud);
            // Reconstruction du chemin
            List<string> chemin = new List<string>();
            int current = endId;
            string RéponseChemin = "";
            while (current != -1)
            {
                if (DictionnaireDeNoeud.TryGetValue(current, out var node) && DictionnaireDeNoeud[current].element is Station CurrentStation)
                {
                    chemin.Insert(0, node.GetLibStation()); // On insère en début de liste
                    ListeStationChemin.Add(CurrentStation);
                    current = pred[current ];
                    
                }                
            }
            for (int i = 1;i< ListeStationChemin.Count-1; i++)
            {
                
                if (LigneCommune(ListeStationChemin[i - 1], ListeStationChemin[i + 1])== -1 && LigneCommune(ListeStationChemin[i], ListeStationChemin[i + 1]) != -1)
                {
                    string ChangementDeLigne = Convert.ToString(LigneCommune(ListeStationChemin[i], ListeStationChemin[i + 1]));
                    RéponseChemin += ListeStationChemin[i] + ("(ligne " + ChangementDeLigne+") --> ");
                }
                RéponseChemin += ListeStationChemin[i] + " --> ";


            }

            // Vérification : le chemin commence-t-il bien par la station de départ ?
            if (chemin.Count == 0 || chemin[0] != LibelleStart)
            {
                Console.WriteLine("Aucun chemin trouvé entre les deux stations.");
                return null;
            }

            // Construction de la chaîne à afficher
            string result = string.Join(" --> ", chemin);
            Console.WriteLine(result);
            Console.WriteLine("testtestest" + RéponseChemin);
            return ListeStationChemin;
        }
        
        public Tuple<int[], int[]> Dijkstra(int start, Dictionary<int, Noeud<T>> DictionnaireDeNoeud)
        {
            
            int size = 333;
            int[] distances = new int[size];
            int[] pred = new int[size];
            bool[] visited = new bool[size];

            for (int i = 0; i < size; i++)
            {
                distances[i] = int.MaxValue;
                pred[i] = -1;
            }

            distances[start] = 0;

            for (int count = 0; count < size - 1; count++)
            {
                // Trouver le noeud u non visité avec la plus petite distance
                int u = -1;
                int minDist = int.MaxValue;
                for (int i = 0; i < size; i++)
                {
                    if (!visited[i] && distances[i] < minDist)
                    {
                        minDist = distances[i];
                        u = i;
                    }
                }

                if (u == -1) break; // Tous les nœuds accessibles ont été traités

                visited[u] = true;

                // Mise à jour des voisins de u
                if (DictionnaireDeNoeud.TryGetValue(u, out var NodeU))
                {
                    //Console.WriteLine($"Exploration du nœud : {NodeU.GetLibStation()}");
                    foreach (Lien<T> lien in NodeU.ArcsSortants)
                    {
                        //Console.WriteLine($"  → vers {lien.NoeudArrivée.GetLibStation()}, poids = {lien.Poids}");                      
                
                    
                        int v = lien.NoeudArrivée.Id;
                        if (!visited[v])
                        {
                            int alt = distances[u] + lien.Poids;
                            if (alt < distances[v])
                            {
                                distances[v] = alt;
                                pred[v] = u;
                            }
                        }
                    }
                }
            }

            return new Tuple<int[], int[]>(pred, distances);
        }
        //public Tuple<int[],int[]> Dijkstra(int start)
        //{/// dictionnaire <distances,prédecésseurs>
        //    int size = 333;
        //    int[] distances = new int[size];
        //    int[]pred = new int[size];
        //    List<int> visited = new List<int>();

        //    for (int i = 0; i < size; i++)
        //    {
        //        distances[i] = int.MaxValue;
        //        pred[i] = -1;
        //    }
        //    distances[start] = 0;
        //    int CurrentNodeId = start;
        //    while (visited.Count <332)
        //    {
        //        if (DictionnaireDeNoeuds.TryGetValue(CurrentNodeId, out var CurrentNode))
        //        {
        //            //Console.WriteLine("Valeur trouvée : " + CurrentNode.element.ToString());
        //        }
        //        else
        //        {
        //            Console.WriteLine("Clé non trouvée.");
        //        }
        //        int distS_U = int.MaxValue;
        //        int u = -1;
        //        foreach (Lien<T> Lien in CurrentNode.ArcsSortants)
        //        {
        //            if (Lien.Poids < distS_U)
        //            {
        //                distS_U = Lien.Poids;
        //                u = Lien.NoeudArrivée.Id;
        //            }
        //        }
        //        visited.Add(CurrentNodeId);
        //        if (DictionnaireDeNoeuds.TryGetValue(u, out var NodeU))
        //        {
        //            //Console.WriteLine("Valeur trouvée : " + NodeU.element.ToString());
        //        }
        //        else
        //        {
        //            Console.WriteLine("Clé non trouvée.");
        //        }
        //        foreach (Lien<T> Lien in NodeU.ArcsSortants)
        //        {
        //            int v = Lien.NoeudArrivée.Id;
        //            if (!visited.Contains(v))
        //            {
        //                int alt = distS_U + Lien.Poids;
        //                if ( alt < distances[v])
        //                {
        //                    distances[v] = alt;
        //                    pred[v] = u;
        //                }

        //            }
        //        }

        //        distances[CurrentNodeId] = distS_U;
        //        pred[CurrentNodeId] = u;
        //    }
        //    Tuple < int[],int[]> ans= new Tuple<int[], int[]>(pred, distances);
        //    return ans;
        //}

        private int MinDistance(int[] distances, bool[] visited)
        {
            int min = int.MaxValue, minIndex = -1;
            for (int v = 0; v < 333; v++)   
            {
                if (!visited[v] && distances[v] <= min)
                {
                    min = distances[v];
                    minIndex = v;
                }
            }
            return minIndex;
        }

        public int GetIdStationFromLibelle(string Libelle)
        {
            foreach (Noeud<T> node in DictionnaireDeNoeuds.Values)
            {
                if (Libelle == node.GetLibStation()) { return node.Id; }
            }
            Console.WriteLine($"Le noeud de nom : {Libelle}");
            return -1;
        }

        static int LigneCommune(Station stationA, Station stationB)
        {
            foreach (int ligneA in stationA.ListeLibelleLigne)
            {
                foreach (int ligneB in stationB.ListeLibelleLigne)
                {
                    if (ligneA == ligneB) { return ligneA; }
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

        




    }
}
