using System;
using System.IO;
using System.Diagnostics;
using QuickGraph;
using SkiaSharp;
using System.Runtime.CompilerServices;

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
        //public void DrawGraph(string filePath)   //ChatGPT
        //{
        //    int width = 1000, height = 1000;
        //    using (var bitmap = new SKBitmap(width, height))
        //    using (var canvas = new SKCanvas(bitmap))
        //    using (var paint = new SKPaint { Color = SKColors.Black, StrokeWidth = 3 })
        //    {
        //        canvas.Clear(SKColors.White);
        //        int nodeCount = Graph.VertexCount;
        //        SKPoint[] positions = new SKPoint[nodeCount];
        //        Random rand = new Random();

        //        // Générer des positions aléatoires pour les nœuds
        //        for (int i = 0; i < nodeCount; i++)
        //        {
        //            positions[i] = new SKPoint(rand.Next(50, width - 50), rand.Next(50, height - 50));
        //        }

        //        // Dessiner les arêtes
        //        foreach (var edge in Graph.Edges)
        //        {
        //            int src = int.Parse(edge.Source) - 1;
        //            int dst = int.Parse(edge.Target) - 1;
        //            canvas.DrawLine(positions[src], positions[dst], paint);
        //        }

        //        // Dessiner les nœuds
        //        using (var nodePaint = new SKPaint { Color = SKColors.Blue, Style = SKPaintStyle.Fill })
        //        using (var textPaint = new SKPaint { Color = SKColors.White, TextSize = 20 })
        //        {
        //            for (int i = 0; i < nodeCount; i++)
        //            {
        //                canvas.DrawCircle(positions[i], 20, nodePaint);
        //                canvas.DrawText((i + 1).ToString(), positions[i].X - 8, positions[i].Y + 8, textPaint);
        //            }
        //        }

        //        // Sauvegarde de l'image
        //        using (var image = SKImage.FromBitmap(bitmap))
        //        using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
        //        using (var stream = File.OpenWrite(filePath))
        //        {
        //            data.SaveTo(stream);
        //        }
        //    }
        //}

        public void DrawGraph(string filePath)  //Deepseek
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