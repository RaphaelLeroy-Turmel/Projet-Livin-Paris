﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TEST_Projet_Livin_Paris;
using ProjetGraphe;
using LivInParis.Data;
using MySql.Data.MySqlClient;

namespace ProjetGraphe
{
    public partial class FormEspaceCuisinier : Form
    {
        private int idCuisinier;

        public FormEspaceCuisinier(int id)
        {
            InitializeComponent();
            idCuisinier = id;
        }

        private void btnPlatsFreq_Click(object sender, EventArgs e)
        {
            lstPlats.Items.Clear();
            using var conn = ConnexionDB.GetConnection(); // si tu modifies ta classe
            string sql = @"SELECT nom_plat, COUNT(*) AS nb
                       FROM Plats
                       WHERE id_cuisinier = @id
                       GROUP BY nom_plat
                       ORDER BY nb DESC";

            using var cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", idCuisinier);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string nomPlat = reader.GetString("nom_plat");
                int nb = reader.GetInt32("nb");
                lstPlats.Items.Add($"{nomPlat} - {nb} fois");
            }

        }

                private void btnClient_Click(object sender, EventArgs e)
                {
                    lstPlats.Items.Clear();
                    using var conn = ConnexionDB.GetConnection();

                    string sql = @"
                                SELECT u.nom, u.prenom, c.metro,
               c.id_commande,
               GROUP_CONCAT(p.nom_plat SEPARATOR ', ') AS plats,
               SUM(lc.quantite) AS total_plats
        FROM utilisateurs u
        JOIN commandes c ON u.id_utilisateur = c.id_client
        JOIN lignes_commande lc ON lc.id_commande = c.id_commande
        JOIN plats p ON lc.id_plat = p.id_plat
        WHERE p.id_cuisinier = @id
        GROUP BY c.id_commande, u.id_utilisateur, u.nom, u.prenom, c.metro
        ORDER BY c.id_commande DESC;";

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", idCuisinier);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string nom = reader.GetString("nom");
                string prenom = reader.GetString("prenom");
                string metro = reader.IsDBNull(reader.GetOrdinal("metro")) ? "N/A" : reader.GetString("metro");
                int idCommande = reader.GetInt32("id_commande");
                int totalPlats = reader.GetInt32("total_plats");
                string plats = reader.IsDBNull(reader.GetOrdinal("plats")) ? "Aucun" : reader.GetString("plats");

                lstPlats.Items.Add($"Commande #{idCommande} - {prenom} {nom} - {totalPlats} plat(s) : {plats} - Métro : {metro}");
            }
        }

        private void btnDeconnexion_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Restart(); // ou revenir à FormConnexion
        }
        private void lstPlats_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nom = txtNomPlat.Text.Trim();
            string type = this.txtTypePlat.Text.Trim();
            string ingredients = txtIngredients.Text.Trim();
            string nationalite = txtNationalite.Text.Trim();
            string fabricationText = DateFab.Value.ToString("yyyy-MM-dd");
            string peremptionText = DatePer.Value.ToString("yyyy-MM-dd");
            string nbPersonnesText = txtNbPersonnes.Text.Trim();
            bool vegetarien = chkVegetarien.Checked;
            bool vegan = chkVegan.Checked;

            if (string.IsNullOrWhiteSpace(nom) || string.IsNullOrWhiteSpace(type) ||
                string.IsNullOrWhiteSpace(fabricationText) || string.IsNullOrWhiteSpace(peremptionText) ||
                string.IsNullOrWhiteSpace(nbPersonnesText))
            {
                lblErreur.Text = "Veuillez remplir les champs obligatoires.";
                lblErreur.Visible = true;
                lblSucces.Visible = false;
                return;
            }

            if (!int.TryParse(nbPersonnesText, out int nbPersonnes) ||
                !DateTime.TryParse(fabricationText, out DateTime fabrication) ||
                !DateTime.TryParse(peremptionText, out DateTime peremption))
            {
                lblErreur.Text = "Format invalide pour date ou nombre.";
                lblErreur.Visible = true;
                lblSucces.Visible = false;
                return;
            }
            fabrication = fabrication.Date;
            peremption = peremption.Date;

            try
            {
                using var conn = ConnexionDB.GetConnection();
                string sql = @"
            INSERT INTO plats 
            (id_cuisinier, nom_plat, type_plat, nombre_personnes, date_fabrication, date_peremption, 
             nationalite, regime_alimentaire, ingredients, prix_par_personne)
            VALUES 
            (@id, @nom, @type, @nb, @fabrication, @peremption, @nationalite, @regime, @ingredients, @prix)";

                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", idCuisinier); // Doit être passé au formulaire
                cmd.Parameters.AddWithValue("@nom", nom);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@nb", nbPersonnes);
                cmd.Parameters.AddWithValue("@fabrication", fabrication);
                cmd.Parameters.AddWithValue("@peremption", peremption);
                cmd.Parameters.AddWithValue("@nationalite", nationalite);
                cmd.Parameters.AddWithValue("@regime", GetRegime(vegetarien, vegan));
                cmd.Parameters.AddWithValue("@ingredients", ingredients);
                cmd.Parameters.AddWithValue("@prix", 9.99); // Prix fixe ou calculable

                cmd.ExecuteNonQuery();
                lblSucces.Text = "Plat ajouté avec succès !";
                lblSucces.Visible = true;
                lblErreur.Visible = false;

                ListerPlats(); // rafraîchit la liste
            }
            catch (Exception ex)
            {
                lblErreur.Text = "Erreur : " + ex.Message;
                lblErreur.Visible = true;
                lblSucces.Visible = false;
            }
        }
        private string GetRegime(bool vegetarien, bool vegan)
        {
            if (vegetarien && vegan) return "Végétarien, Végan";
            if (vegetarien) return "Végétarien";
            if (vegan) return "Végan";
            return "Aucun";
        }
        private void ListerPlats()
        {
            lstPlats.Items.Clear();

            using var conn = ConnexionDB.GetConnection();
            string sql = "SELECT nom_plat, date_fabrication, regime_alimentaire FROM plats WHERE id_cuisinier = @id";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", idCuisinier);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string nom = reader.GetString("nom_plat");
                string regime = reader.GetString("regime_alimentaire");
                DateTime date = reader.GetDateTime("date_fabrication");
                lstPlats.Items.Add($"{nom} (fabriqué le {date:dd/MM/yyyy}{regime})");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FormEspaceCuisinier_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListerPlats();
        }

        private void DateFab_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnrecherche_Click(object sender, EventArgs e)
        {
            string file1 = "MetroParisUTF8 feuille 1.txt";
            string file2 = "Métro paris UTF8 feuille2 v2.txt";
            string file3 = "PetiteFeuille1.txt";
            string file4 = "PetiteFeuille2.txt";
            string depart = txtDepart.Text.Trim();
            string arrivee = txtArrivee.Text.Trim();

            if (string.IsNullOrWhiteSpace(depart) || string.IsNullOrWhiteSpace(arrivee))
            {
                MessageBox.Show("Veuillez entrer les deux stations.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // ⚠️ Mets bien les bons chemins vers tes fichiers CSV
                Graphe<Station> graphe = new Graphe<Station>(file1, file2);
                List<Station> trajet = graphe.PCC(depart, arrivee);

                if (trajet == null || trajet.Count == 0)
                {
                    MessageBox.Show($"Aucun chemin trouvé entre {depart} et {arrivee}.", "Résultat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Itinéraire :");
                foreach (Station s in trajet)
                {
                    sb.AppendLine($"→ {s.LibelleStation} (ligne(s) : {string.Join(", ", s.ListeLibelleLigne)})");
                }

                MessageBox.Show(sb.ToString(), "Trajet trouvé");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du calcul du trajet : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
