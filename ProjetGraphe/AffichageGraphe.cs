using System;
using System.IO;
using System.Diagnostics;
using QuickGraph;
using SkiaSharp;
using System.Runtime.CompilerServices;
using ProjetGraphe;
using System.Globalization;


/// Recherche faites avec l'ia Deepseek, la première étape était de savoir quelles étaients les bibliothèques utiles pour faire un graphe.
/// Puis on a demandé comment faire un cercle pour afficher les noeuds dans cette forme pour que ce soit lisible
/// A l'aide l'ia on a compris les différentes instructions pour déssiner les arètes et les noeuds
/// Enfin on a demandé comment faire pour afficher l'image directement après l'exécutioin du code.
/// Ce qui nous donne ceci :

namespace GraphVisualization///Raphael_LEROY_TURMEL_Thomas_LIOTIER_Loan_LU_CHI_VANG
{
    public class GraphViewModel
    {
        public BidirectionalGraph<string, Edge<string>> Graph { get; private set; }   /// Graphe orienté représentant les stations et connexions.                                                                                   
        private Dictionary<int, Station> stationsById;                                /// Dictionnaire liant les IDs aux objets Station.
        private List<(string, string)> cheminSurligne = new();                       /// Liste des arêtes (nom des stations) formant le chemin à surligner.
        private string resumeChemin = "";                                           /// Texte affichant le résumé du chemin (stations + durée).


        public GraphViewModel(List<Station> stations, int[,] adjacencyMatrix)     /// Constructeur : initialise le graphe avec les stations et la matrice d'adjacence.
        {
            Graph = new BidirectionalGraph<string, Edge<string>>();
            stationsById = new Dictionary<int, Station>();

            for (int i = 0; i < stations.Count; i++)
            {
                Station station = stations[i];
                stationsById[station.Id] = station;
                Graph.AddVertex(station.LibelleStation);
            }

            int size = adjacencyMatrix.GetLength(0);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (adjacencyMatrix[i, j] != 0 && i < stations.Count && j < stations.Count)
                    {
                        Station stationA = stations[i];
                        Station stationB = stations[j];

                        if (stationA.LigneCommune(stationB) != -1)
                        {
                            string srcName = stationA.LibelleStation;
                            string dstName = stationB.LibelleStation;
                            Graph.AddEdge(new Edge<string>(srcName, dstName));
                        }
                        else
                        {
                            // Console.WriteLine($"Aucune ligne commune entre {stationA.LibelleStation} et {stationB.LibelleStation}");
                        }
                    }
                }
            }
        }

        public static List<Station> ChargerStationsDepuisCSV(string cheminFichier)      /// Charge les données des stations depuis un fichier CSV.
        {
            var stations = new List<Station>();
            using (var reader = new StreamReader(cheminFichier, System.Text.Encoding.GetEncoding("iso-8859-1")))
            {
                string header = reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    var parts = line.Split(';');

                    try
                    {
                        int id = int.Parse(parts[0]);
                        int ligne = int.Parse(parts[1]);
                        string libelleStation = parts[2];
                        double longitude = double.Parse(parts[3], CultureInfo.InvariantCulture);
                        double latitude = double.Parse(parts[4], CultureInfo.InvariantCulture);

                        var station = new Station(id, ligne, libelleStation, longitude, latitude);
                        stations.Add(station);
                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine($"Erreur de parsing à la ligne : {line} → {ex.Message}");
                    }
                }
            }
            return stations;
        }

        public void SetCheminSurligne(List<int> chemin, List<Station> stations, int[,] matriceAdjacence, List<int> idList)      /// Définit un chemin à surligner et calcule le temps total du trajet.
        {
            cheminSurligne.Clear();
            int totalTemps = 0;

            for (int i = 0; i < chemin.Count - 1; i++)
            {
                int idA = chemin[i];
                int idB = chemin[i + 1];

                int indexA = idList.IndexOf(idA);
                int indexB = idList.IndexOf(idB);

                if (indexA == -1 || indexB == -1)
                    continue;

                Station stationA = stations.FirstOrDefault(s => s.Id == idA);
                Station stationB = stations.FirstOrDefault(s => s.Id == idB);

                if (stationA != null && stationB != null)
                {
                    cheminSurligne.Add((stationA.LibelleStation, stationB.LibelleStation));
                    totalTemps += matriceAdjacence[indexA, indexB];
                }
            }

            if (chemin.Count >= 2)
            {
                int idStart = chemin.First();
                int idEnd = chemin.Last();
                var stationStart = stations.FirstOrDefault(s => s.Id == idStart)?.LibelleStation ?? "?";
                var stationEnd = stations.FirstOrDefault(s => s.Id == idEnd)?.LibelleStation ?? "?";
                resumeChemin = $"{stationStart} → {stationEnd} : {totalTemps} min";
            }
        }

        public void DrawGraph(string filePath)      /// Dessine le graphe dans une image avec les arêtes et les stations positionnées.
        {
            int width = 2000, height = 2000;
            using (var bitmap = new SKBitmap(width, height))
            using (var canvas = new SKCanvas(bitmap))
            {
                canvas.Clear(SKColors.White);

                double minLon = double.MaxValue, maxLon = double.MinValue;  /// Trouver les bornes géographiques pour adapter à l'image
                double minLat = double.MaxValue, maxLat = double.MinValue;

                foreach (var station in stationsById.Values)
                {
                    minLon = Math.Min(minLon, station.Longitude);
                    maxLon = Math.Max(maxLon, station.Longitude);
                    minLat = Math.Min(minLat, station.Latitude);
                    maxLat = Math.Max(maxLat, station.Latitude);
                }

                Dictionary<string, SKPoint> positions = new();       /// Conversion des coordonnées GPS en coordonnées image
                foreach (var station in stationsById.Values)
                {
                    float x = (float)((station.Longitude - minLon) / (maxLon - minLon) * (width - 100) + 50);
                    float y = (float)((1 - (station.Latitude - minLat) / (maxLat - minLat)) * (height - 100) + 50);
                    positions[station.LibelleStation] = new SKPoint(x, y);
                }

                foreach (var edge in Graph.Edges)   /// Dessin des arêtes
                {
                    if (positions.ContainsKey(edge.Source) && positions.ContainsKey(edge.Target))
                    {
                        bool isPath = cheminSurligne.Contains((edge.Source, edge.Target)) || cheminSurligne.Contains((edge.Target, edge.Source));
                        var paint = new SKPaint
                        {
                            Color = isPath ? SKColors.Red : SKColors.DarkGray,
                            StrokeWidth = isPath ? 4 : 2,
                            IsAntialias = true
                        };
                        canvas.DrawLine(positions[edge.Source], positions[edge.Target], paint);
                    }
                }
                /// Dessin des noeuds (stations)
                using (var nodePaint = new SKPaint { Color = SKColors.SteelBlue, Style = SKPaintStyle.Fill })
                using (var textPaint = new SKPaint { Color = SKColors.Black, TextSize = 16, TextAlign = SKTextAlign.Center })
                {
                    foreach (var kvp in positions)
                    {
                        var name = kvp.Key;
                        var point = kvp.Value;
                        canvas.DrawCircle(point, 10, nodePaint);
                        canvas.DrawText(name, point.X, point.Y - 15, textPaint);
                    }

                    if (!string.IsNullOrWhiteSpace(resumeChemin))   /// Texte du résumé du trajet
                    {
                        using (var resumePaint = new SKPaint { Color = SKColors.Black, TextSize = 32, TextAlign = SKTextAlign.Right })
                        {
                            canvas.DrawText(resumeChemin, 1950, 1950, resumePaint);
                        }
                    }
                }

                /// Sauvegarde de l'image
                using (var image = SKImage.FromBitmap(bitmap))
                using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
                using (var stream = File.OpenWrite(filePath))
                {
                    data.SaveTo(stream);
                }
            }
        }

        public void GenerationImage(List<Station> stations, int[,] matriceAdjacence)          /// Génére et affiche une image du graphe avec le chemin surligné (s'il y en a un).
        {
            GraphViewModel graph = new GraphViewModel(stations, matriceAdjacence);
            graph.cheminSurligne = this.cheminSurligne;
            graph.resumeChemin = this.resumeChemin;
            string imagePath = "graph_output.png";
            graph.DrawGraph(imagePath);

            Console.WriteLine($"Graph image saved to {imagePath}");
            Process.Start(new ProcessStartInfo(imagePath) { UseShellExecute = true });
        }

    }
}


