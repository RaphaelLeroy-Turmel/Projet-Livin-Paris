using LivInParis.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TEST_Projet_Livin_Paris;

namespace ProjetGraphe
{
    public partial class FormEspaceAdmin : Form
    {
        public FormEspaceAdmin()
        {
            InitializeComponent();
        }


        private void lblTitre_Click(object sender, EventArgs e)
        {

        }

        private void btnDeconnexion_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Restart();
        }

        private void btnCuisiniers_Click(object sender, EventArgs e)
        {
            lstResultats.Items.Clear();

            using var conn = ConnexionDB.GetConnection();
            string sql = "SELECT id_utilisateur, nom, prenom FROM utilisateurs WHERE est_cuisinier = true";

            using var cmd = new MySqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32("id_utilisateur");
                string nom = reader.GetString("nom");
                string prenom = reader.GetString("prenom");
                lstResultats.Items.Add($"Cuisinier #{id} : {prenom} {nom}");
            }

        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            lstResultats.Items.Clear();

            using var conn = ConnexionDB.GetConnection();
            string sql = "SELECT id_utilisateur, nom, prenom FROM utilisateurs WHERE est_client = true";

            using var cmd = new MySqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32("id_utilisateur");
                string nom = reader.GetString("nom");
                string prenom = reader.GetString("prenom");
                lstResultats.Items.Add($"Client #{id} : {prenom} {nom}");
            }
        }

        private void btnPlats_Click(object sender, EventArgs e)
        {
            lstResultats.Items.Clear();

            using var conn = ConnexionDB.GetConnection();
            string sql = "SELECT id_plat, nom_plat FROM plats";

            using var cmd = new MySqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32("id_plat");
                string nom = reader.GetString("nom_plat");
                lstResultats.Items.Add($"Plat #{id} : {nom}");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbTriClient.Items.Clear();
            cmbTriClient.Items.Add("Nom alphabétique");
            cmbTriClient.Items.Add("Rue");
            cmbTriClient.Items.Add("Montant des achats cumulés");
            cmbTriClient.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lstResultats.Items.Clear();

            if (cmbTriClient.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un critère de tri.");
                return;
            }

            string tri = cmbTriClient.SelectedItem.ToString();

            string sql = "";

            if (tri == "Nom alphabétique")
            {
                sql = @"SELECT nom, prenom FROM utilisateurs WHERE est_client = true ORDER BY nom, prenom";
            }
            else if (tri == "Rue")
            {
                sql = @"SELECT nom, prenom, adresse FROM utilisateurs WHERE est_client = true ORDER BY adresse";
            }
            else if (tri == "Montant des achats cumulés")
            {
                sql = @"
            SELECT u.nom, u.prenom, SUM(lc.quantite * p.prix_par_personne) AS total
            FROM utilisateurs u
            JOIN commandes c ON u.id_utilisateur = c.id_client
            JOIN lignes_commande lc ON lc.id_commande = c.id_commande
            JOIN plats p ON p.id_plat = lc.id_plat
            WHERE u.est_client = true
            GROUP BY u.id_utilisateur
            ORDER BY total DESC";
            }

            using var conn = ConnexionDB.GetConnection();
            using var cmd = new MySqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (tri == "Montant des achats cumulés")
                {
                    string nom = reader.GetString("nom");
                    string prenom = reader.GetString("prenom");
                    decimal total = reader.GetDecimal("total");
                    lstResultats.Items.Add($"{prenom} {nom} - {total} €");
                }
                else if (tri == "Rue")
                {
                    string nom = reader.GetString("nom");
                    string prenom = reader.GetString("prenom");
                    string rue = reader.GetString("adresse");
                    lstResultats.Items.Add($"{prenom} {nom} - {rue}");
                }
                else
                {
                    string nom = reader.GetString("nom");
                    string prenom = reader.GetString("prenom");
                    lstResultats.Items.Add($"{prenom} {nom}");
                }
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnMetro_Click(object sender, EventArgs e)
        {
            string file1 = "MetroParisUTF8 feuille 1.txt";
            string file2 = "Métro paris UTF8 feuille2 v2.txt";
            Graphe<Station> PlanMétro = new Graphe<Station>(file1, file2);
            List<Station> ListeDeStation = new List<Station>();
            foreach (Noeud<Station> Noeud in PlanMétro.DictionnaireDeNoeuds.Values)
            {
                ListeDeStation.Add(Noeud.element);
            }
            string LibelleStart = "Porte Maillot";
            string LibelleEnd = "Saint-Fargeau";
            List<int> CheminStation = new List<int>();
            foreach (Station station in PlanMétro.PCC(LibelleStart, LibelleEnd))
            {
                CheminStation.Add(station.Id);
            }
            PlanMétro.DictionnaireDeNoeuds.TryGetValue(1, out var node);

            GraphViewModel<Station> Graphe = new GraphViewModel<Station>(ListeDeStation, PlanMétro.MatriceAdjacence, PlanMétro, CheminStation);
        }

        private void picLogo_Click(object sender, EventArgs e)
        {

        }
    }
}
