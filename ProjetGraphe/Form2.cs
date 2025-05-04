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
                SELECT c.id_commande, c.date_commande
                FROM commandes c
                WHERE c.id_client = @id";

            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", idClient);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int idCommande = reader.GetInt32("id_commande");
                DateTime date = reader.GetDateTime("date_commande");

                lstCommandes.Items.Add($"Commande #{idCommande} - {date:dd/MM/yyyy}");
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
    }
}
