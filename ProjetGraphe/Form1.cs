using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TEST_Projet_Livin_Paris; // Pour Graphe<T> et Station

namespace ProjetGraphe
{
    internal partial class FormColoration : Form
    {
        private Graphe<Station> graphe;
        private Dictionary<int, int> couleurs;
        private Dictionary<int, PointF> positions; // Pour positionner les stations

        public FormColoration(Graphe<Station> graphe, Dictionary<int, int> couleurs)
        {
            InitializeComponent();
            this.graphe = graphe;
            this.couleurs = couleurs;
            this.DoubleBuffered = true;
            this.WindowState = FormWindowState.Maximized;
            this.Text = "Coloration du Graphe";
            this.BackColor = Color.White;

            // Calcule les positions des stations une seule fois
            positions = CalculerPositions();
        }

        private Dictionary<int, PointF> CalculerPositions()
        {
            var positions = new Dictionary<int, PointF>();
            int margin = 100;
            int width = this.ClientSize.Width - 2 * margin;
            int height = this.ClientSize.Height - 2 * margin;
            int n = graphe.DictionnaireDeNoeuds.Count;

            int i = 0;
            foreach (var kvp in graphe.DictionnaireDeNoeuds)
            {
                double angle = 2 * Math.PI * i / n;
                float x = margin + width / 2 + (float)(Math.Cos(angle) * width / 2.5);
                float y = margin + height / 2 + (float)(Math.Sin(angle) * height / 2.5);
                positions[kvp.Key] = new PointF(x, y);
                i++;
            }
            return positions;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Définir une palette de couleurs (ajouter plus si besoin)
            Color[] palette = new Color[]
            {
                Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Purple,
                Color.Teal, Color.Brown, Color.Magenta, Color.Cyan, Color.Gold
            };

            // Dessine les arêtes
            foreach (var noeud in graphe.DictionnaireDeNoeuds.Values)
            {
                PointF posA = positions[noeud.Id];
                foreach (var lien in noeud.ArcsSortants)
                {
                    PointF posB = positions[lien.NoeudArrivée.Id];
                    g.DrawLine(Pens.LightGray, posA, posB);
                }
            }

            // Dessine les noeuds avec couleur
            foreach (var kvp in graphe.DictionnaireDeNoeuds)
            {
                int id = kvp.Key;
                PointF pos = positions[id];
                int colorIndex = couleurs.ContainsKey(id) ? couleurs[id] % palette.Length : 0;
                Brush brush = new SolidBrush(palette[colorIndex]);

                g.FillEllipse(brush, pos.X - 10, pos.Y - 10, 20, 20);
                g.DrawEllipse(Pens.Black, pos.X - 10, pos.Y - 10, 20, 20);

                string label = kvp.Value.GetLibStation();
                g.DrawString(label, new Font("Segoe UI", 8), Brushes.Black, pos.X + 12, pos.Y - 6);
            }
        }

        private void FormColoration_Load(object sender, EventArgs e)
        {

        }
    }
}
