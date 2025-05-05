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
using ProjetGraphe;
using LivInParis.Data;
using MySql.Data.MySqlClient;
using System.Drawing.Text;

namespace ProjetGraphe
{
    public partial class FormEspaceClient : Form
    {
        private int idClient;
        public FormEspaceClient(int id)

        {
            InitializeComponent();
            idClient = id;
            lblBienvenue.Text = $"Bienvenue, client #{idClient}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lstCommandes.Items.Clear();

            using var conn = ConnexionDB.GetConnection();
            string query = @"
    SELECT c.id_commande,c.metro, c.date_commande, c.total, c.statut, 
           p.nom_plat, lc.quantite, lc.date_livraison
    FROM commandes c
    JOIN lignes_commande lc ON c.id_commande = lc.id_commande
    JOIN plats p ON p.id_plat = lc.id_plat
    WHERE c.id_client = @id
    ORDER BY c.date_commande DESC";

            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", idClient);

            using var reader = cmd.ExecuteReader();
            int lastId = -1;

            while (reader.Read())
            {
                int idCommande = reader.GetInt32("id_commande");
                DateTime date = reader.GetDateTime("date_commande");
                decimal total = reader.GetDecimal("total");
                string statut = reader.GetString("statut");
                string metro = reader.IsDBNull(reader.GetOrdinal("metro")) ? "Métro inconnu" : reader.GetString("metro");
                string nomPlat = reader.GetString("nom_plat");
                int quantite = reader.GetInt32("quantite");
                DateTime dateLivraison = reader.GetDateTime("date_livraison");

                if (idCommande != lastId)
                {
                    lstCommandes.Items.Add($"Commande #{idCommande} - {date:dd/MM/yyyy} - {statut} - Total: {total}€");
                    lastId = idCommande;
                }

                lstCommandes.Items.Add($"    {nomPlat} x{quantite} - Livraison le {dateLivraison:dd/MM/yyyy}");
            }

            if (lstCommandes.Items.Count == 0)
            {
                lstCommandes.Items.Add("Aucune commande trouvée.");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Restart();
        }



        private void lblBienvenue_Click(object sender, EventArgs e)
        {

        }
        public class LigneTemp
        {
            public int IdPlat;
            public string NomPlat;
            public int Quantite;
            public decimal Prix;
            public DateTime DateLivraison;
            public string Metro;
            public string AdresseLivraison;
            public string MoyenPaiement;
        }
        List<LigneTemp> panier = new List<LigneTemp>();


        private void button3_Click(object sender, EventArgs e)
        {
            if (panier.Count == 0)
            {
                MessageBox.Show("Le panier est vide.");
                return;
            }

            using var conn = ConnexionDB.GetConnection();
            using var trans = conn.BeginTransaction();

            try
            {
                // Étape 1 : Créer la commande
                string insertCommande = @"INSERT INTO Commandes (id_client, metro, date_commande, total, statut) 
                          VALUES (@id, @metro, NOW(), 0, 'En cours')";
                

                using var cmd1 = new MySqlCommand(insertCommande, conn, trans);
                cmd1.Parameters.AddWithValue("@metro", txtMetro.Text.Trim());
                cmd1.Parameters.AddWithValue("@id", idClient); // <-- assure-toi d'avoir stocké l'ID du client au login
                cmd1.ExecuteNonQuery();
                int idCommande = (int)cmd1.LastInsertedId;

                decimal total = 0;

                // Étape 2 : Ajouter les lignes de commande
                foreach (var ligne in panier)
                {
                    total += ligne.Quantite * ligne.Prix;

                    string insertLigne = @"INSERT INTO Lignes_Commande 
                (id_commande, id_plat, quantite, prix_unitaire, date_livraison, adresse_livraison)
                VALUES (@idCommande, @idPlat, @qte, @prix, @date, @adresse)";
                    using var cmd2 = new MySqlCommand(insertLigne, conn, trans);
                    cmd2.Parameters.AddWithValue("@idCommande", idCommande);
                    cmd2.Parameters.AddWithValue("@idPlat", ligne.IdPlat);
                    cmd2.Parameters.AddWithValue("@qte", ligne.Quantite);
                    cmd2.Parameters.AddWithValue("@prix", ligne.Prix);
                    cmd2.Parameters.AddWithValue("@date", ligne.DateLivraison);
                    cmd2.Parameters.AddWithValue("@adresse", ligne.AdresseLivraison);
                    cmd2.ExecuteNonQuery();
                }

                // Étape 3 : Mettre à jour le total
                string updateTotal = "UPDATE Commandes SET total = @total WHERE id_commande = @idCommande";
                using var cmd3 = new MySqlCommand(updateTotal, conn, trans);
                cmd3.Parameters.AddWithValue("@total", total);
                cmd3.Parameters.AddWithValue("@idCommande", idCommande);
                cmd3.ExecuteNonQuery();

                // Étape 4 : Ajouter la transaction
                string modePaiement = panier[0].MoyenPaiement; // même mode pour tout
                string insertTransac = @"INSERT INTO Transactions 
            (id_commande, montant, mode_paiement, date_transaction, statut)
            VALUES (@idCommande, @montant, @mode, NOW(), 'Effectuée')";
                using var cmd4 = new MySqlCommand(insertTransac, conn, trans);
                cmd4.Parameters.AddWithValue("@idCommande", idCommande);
                cmd4.Parameters.AddWithValue("@montant", total);
                cmd4.Parameters.AddWithValue("@mode", modePaiement);
                cmd4.ExecuteNonQuery();

                // Valider la transaction SQL
                trans.Commit();

                MessageBox.Show("Commande enregistrée !");
                panier.Clear();
                lstCommandes.Items.Clear();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using var conn = ConnexionDB.GetConnection();
            string sql = "SELECT id_plat, nom_plat FROM plats";

            using var cmd = new MySqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            var plats = new Dictionary<int, string>();
            while (reader.Read())
            {
                int id = reader.GetInt32("id_plat");
                string nom = reader.GetString("nom_plat");
                plats.Add(id, nom);
            }

            cmbPlats.DataSource = new BindingSource(plats, null);
            cmbPlats.DisplayMember = "Value";
            cmbPlats.ValueMember = "Key";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (cmbPlats.SelectedItem == null)
            {
                MessageBox.Show("Sélectionnez un plat.");
                return;
            }

            int idPlat = ((KeyValuePair<int, string>)cmbPlats.SelectedItem).Key;
            string nomPlat = ((KeyValuePair<int, string>)cmbPlats.SelectedItem).Value;
            string metro = txtMetro.Text.Trim();
            int quantite = (int)numQuantite.Value;
            DateTime dateLivraison = dateLivraisonPicker.Value;
            string adresse = txtAdresse.Text.Trim();
            string paiement = CB.Checked ? "Carte bancaire" : Especes.Checked ? "Espèces" : Paypal.Checked ? "Paypal" : "Inconnu";

            if (quantite <= 0 || string.IsNullOrWhiteSpace(adresse))
            {
                MessageBox.Show("Veuillez remplir tous les champs.");
                return;
            }

            // Ajoute au panier
            panier.Add(new LigneTemp
            {
                IdPlat = idPlat,
                NomPlat = nomPlat,
                Quantite = quantite,
                Prix = 9.99m, // à remplacer par une vraie valeur si besoin
                DateLivraison = dateLivraison,
                Metro = metro,
                AdresseLivraison = adresse + " (Métro : " + metro + ")",
                MoyenPaiement = paiement
            });

            lstCommandes.Items.Add($"{nomPlat} x{quantite} - Livraison le {dateLivraison:dd/MM} ({paiement})");
        }


        private void CB_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void ChargerPlats()
        {
            using var conn = ConnexionDB.GetConnection();
            string sql = "SELECT id_plat, nom_plat FROM plats";
            using var cmd = new MySqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            var plats = new Dictionary<int, string>();
            while (reader.Read())
                plats.Add(reader.GetInt32("id_plat"), reader.GetString("nom_plat"));

            cmbPlats.DataSource = new BindingSource(plats, null);
            cmbPlats.DisplayMember = "Value";
            cmbPlats.ValueMember = "Key";
        }


        private void FormEspaceClient_Load(object sender, EventArgs e)
        {
            try
            {
                ChargerPlats();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de chargement des plats : " + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lstCommandes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
