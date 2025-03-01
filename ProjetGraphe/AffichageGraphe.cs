using System;
using System.IO;
using System.Diagnostics;
using QuickGraph;
using SkiaSharp;
using System.Runtime.CompilerServices;


/// Recherche faites avec l'ia Deepseek, la première étape était de savoir quelles étaients les bibliothèques utiles pour faire un graphe.
/// Puis on a demandé comment faire un cercle pour afficher les noeuds dans cette forme pour que ce soit lisible
/// A l'aide l'ia on a compris les différentes instructions pour déssiner les arètes et les noeuds
/// Enfin on a demandé comment faire pour afficher l'image directement après l'exécutioin du code.
/// Ce qui nous donne ceci :

namespace GraphVisualization
{
    public class GraphViewModel
    {
        public BidirectionalGraph<string, Edge<string>> Graph { get; private set; }

        public GraphViewModel(int[,] adjacencyMatrix)
        {
            Graph = new BidirectionalGraph<string, Edge<string>>();
            int size = adjacencyMatrix.GetLength(0);

            for (int i = 0; i < size; i++)
            {
                Graph.AddVertex((i + 1).ToString());
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (adjacencyMatrix[i, j] == 1)
                    {
                        Graph.AddEdge(new Edge<string>((i + 1).ToString(), (j + 1).ToString()));
                    }
                }
            }
        }
        
        
        public void DrawGraph(string filePath)  ///Deepseek
        {
            int width = 1000, height = 1000; /// Taille de l'image augmentée
            using (var bitmap = new SKBitmap(width, height))
            using (var canvas = new SKCanvas(bitmap))
            using (var edgePaint = new SKPaint { Color = SKColors.DarkGray, StrokeWidth = 2 })
            {
                canvas.Clear(SKColors.White);
                int nodeCount = Graph.VertexCount;
                SKPoint[] positions = new SKPoint[nodeCount];

                /// Circular Layout pour placer les nœuds
                double angleIncrement = 2 * Math.PI / nodeCount;
                double radius = Math.Min(width, height) / 2.5;
                SKPoint center = new SKPoint(width / 2, height / 2);

                for (int i = 0; i < nodeCount; i++)
                {
                    double angle = i * angleIncrement;
                    float x = center.X + (float)(radius * Math.Cos(angle));
                    float y = center.Y + (float)(radius * Math.Sin(angle));
                    positions[i] = new SKPoint(x, y);
                }

                /// Dessiner les arêtes (lignes droites)
                foreach (var edge in Graph.Edges)
                {
                    int src = int.Parse(edge.Source) - 1;
                    int dst = int.Parse(edge.Target) - 1;
                    SKPoint start = positions[src];
                    SKPoint end = positions[dst];

                    /// Dessiner une ligne droite entre les deux nœuds
                    canvas.DrawLine(start, end, edgePaint);
                }

                /// Dessiner les nœuds
                using (var nodePaint = new SKPaint { Color = SKColors.LightBlue, Style = SKPaintStyle.Fill })
                using (var textPaint = new SKPaint { Color = SKColors.White, TextSize = 14, TextAlign = SKTextAlign.Center })
                {
                    for (int i = 0; i < nodeCount; i++)
                    {
                        canvas.DrawCircle(positions[i], 15, nodePaint); /// Taille des nœuds réduite
                        canvas.DrawText((i + 1).ToString(), positions[i].X, positions[i].Y + 5, textPaint);
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




        public void GenerationImage(int[,] MatriceAdjacence)
        {
            int[,] adjacencyMatrix = MatriceAdjacence;
           

            GraphViewModel graph = new GraphViewModel(adjacencyMatrix);
            string imagePath = "graph_output.png";
            graph.DrawGraph(imagePath);

            Console.WriteLine($"Graph image saved to {imagePath}");
            Process.Start(new ProcessStartInfo(imagePath) { UseShellExecute = true });
        }


    }
}