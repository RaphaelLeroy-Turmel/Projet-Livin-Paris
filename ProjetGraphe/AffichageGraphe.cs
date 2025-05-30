﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickGraph;
using SkiaSharp;
namespace TEST_Projet_Livin_Paris
{///Raphaël_LEROY TURMEL Thomas LIOTIER Loan LU-CHI-VANG TD K
    internal class GraphViewModel<T>
    {
        public BidirectionalGraph<string, Edge<string>> SchémaDeGraphe { get; private set; }   /// Graphe orienté représentant les stations et connexions.
        private List<(string, string)> cheminSurligne = new();                       /// Liste des arêtes (nom des stations) formant le chemin à surligner.
        private string resumeChemin = "";                                           /// Texte affichant le résumé du chemin (stations + durée).
        public Graphe<T> graphe;
        List<string> CheminStation;



        public GraphViewModel(List<Station> stations, int[,] adjacencyMatrix, Graphe<T> graphe, List<string> CheminStation)     /// Constructeur : initialise le graphe avec les stations et la matrice d'adjacence.
        {
            this.SchémaDeGraphe = new BidirectionalGraph<string, Edge<string>>();
            this.graphe = graphe;
            this.CheminStation = new List<string>(CheminStation);
            for (int i = 0; i < stations.Count; i++)
            {
                SchémaDeGraphe.AddVertex(stations[i].LibelleStation);
            }

            int size = adjacencyMatrix.GetLength(0);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (adjacencyMatrix[i, j] != 0 && i < stations.Count && j < stations.Count)
                    {
                        Station stationA = stations[i - 1];
                        Station stationB = stations[j - 1];

                        if (stationA.LigneCommune(stationB) != -1)
                        {
                            string srcName = stationA.LibelleStation;
                            string dstName = stationB.LibelleStation;
                            SchémaDeGraphe.AddEdge(new Edge<string>(srcName, dstName));
                        }
                        else
                        {
                            // Console.WriteLine($"Aucune ligne commune entre {stationA.LibelleStation} et {stationB.LibelleStation}");
                        }
                    }
                }
            }
            string imagePath = "graph_output.png";
            DrawGraph(imagePath);
            SetCheminSurligne(CheminStation, stations, graphe.MatriceAdjacence);

            Console.WriteLine($"Image du graphe sauvegardée dans {imagePath}");
            Process.Start(new ProcessStartInfo(imagePath) { UseShellExecute = true });
        }
        //aaaaaaaaa
        public void SetCheminSurligne(List<string> chemin, List<Station> stations, int[,] matriceAdjacence)      /// Définit un chemin à surligner et calcule le temps total du trajet.
        {
            cheminSurligne.Clear();
            int totalTemps = 0;

            for (int i = 0; i < chemin.Count - 1; i++)
            {
                string LibelleA = chemin[i];
                string LibelleB = chemin[i + 1];

                //int indexA = idList.IndexOf(idA);
                //int indexB = idList.IndexOf(idB);

                //if (indexA == -1 || indexB == -1)
                //    continue;

                Station stationA = stations.FirstOrDefault(s => s.LibelleStation == LibelleA);
                Station stationB = stations.FirstOrDefault(s => s.LibelleStation == LibelleB);
                //foreach(Noeud<T> node in graphe.DictionnaireDeNoeuds.Values )
                //{
                //    if (stationA.LibelleStation == node.GetLibStation() && idA != node.Id)
                //    {
                //        Console.WriteLine("Les noeuds ne concordents pas avec station Adans SetCheminSurLigne");
                //    }
                //    if (stationB.LibelleStation == node.GetLibStation() && idB != node.Id)
                //    {
                //        Console.WriteLine("Les noeuds ne concordents pas avec station B dans SetCheminSurLigne");
                //    }


                //}

                if (stationA != null && stationB != null)
                {
                    cheminSurligne.Add((stationA.LibelleStation, stationB.LibelleStation));

                    totalTemps += matriceAdjacence[stationA.Id, stationB.Id];
                }
            }

            if (chemin.Count >= 2)
            {
                string LibStart = chemin.First();
                string LibEnd = chemin.Last();
                var stationStart = stations.FirstOrDefault(s => s.LibelleStation == LibStart)?.LibelleStation ?? "?";
                var stationEnd = stations.FirstOrDefault(s => s.LibelleStation == LibEnd)?.LibelleStation ?? "?";
                resumeChemin = $"{stationStart} -> {stationEnd} : {totalTemps} min";
            }
            foreach (var statchemin in cheminSurligne)
            {
                //Console.WriteLine($"item 1 : {statchemin.Item1} --> item2 :{statchemin.Item2}");
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

                foreach (Noeud<T> node in graphe.DictionnaireDeNoeuds.Values)
                {
                    //Console.WriteLine(" azertyuytrezae :" + node.ArcsEntrants[0].toString());

                    if (node.element is Station station)
                    {
                        minLon = Math.Min(minLon, station.Longitude);
                        maxLon = Math.Max(maxLon, station.Longitude);
                        minLat = Math.Min(minLat, station.Latitude);
                        maxLat = Math.Max(maxLat, station.Latitude);
                        //Console.WriteLine(minLat+ " "+ maxLat+ " "+minLon+"  "+ maxLon);
                    }
                    else
                    {
                        Console.WriteLine("erreur vous essayer de dessiner un graphe avec autrechose que des Stations");
                    }


                }

                Dictionary<string, SKPoint> positions = new();       /// Conversion des coordonnées GPS en coordonnées image

                foreach (Noeud<T> node in graphe.DictionnaireDeNoeuds.Values)
                {
                    if (node.element is Station station)
                    {
                        float x = (float)((station.Longitude - minLon) / (maxLon - minLon) * (width - 100) + 50);
                        float y = (float)((1 - (station.Latitude - minLat) / (maxLat - minLat)) * (height - 100) + 50);
                        positions[station.LibelleStation] = new SKPoint(x, y);

                    }

                }

                foreach (var edge in SchémaDeGraphe.Edges)   /// Dessin des arêtes
                {
                    if (positions.ContainsKey(edge.Source) && positions.ContainsKey(edge.Target))
                    {

                        bool isPath = false;

                        foreach (var tuple in cheminSurligne)
                        {
                            string a = tuple.Item1;
                            string b = edge.Source;
                            Console.WriteLine("item1" + a + " et edge " + b);
                            if (a == b)
                            {
                                isPath = true;
                            }
                        }

                        //else
                        //{
                        //    Console.WriteLine($"IsPath is NOT true for: {edge.Source} -> {edge.Target}");
                        //}

                        ////Console.WriteLine("edge.Source : " + edge.Source + "       edge.Target : " + edge.Target);
                        //if (isPath) { Console.WriteLine("ISPATH"); }
                        //if (!isPath) { Console.WriteLine("ISNotPATH"); }
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
                //using (var textPaint = new SKPaint { Color = SKColors.Black, TextSize = 16, TextAlign = SKTextAlign.Center })
                using (var textPaint = new SKPaint { Color = SKColors.Black, TextSize = 16, TextAlign = SKTextAlign.Center, Typeface = SKTypeface.FromFamilyName("Roboto") })
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
    }
}
