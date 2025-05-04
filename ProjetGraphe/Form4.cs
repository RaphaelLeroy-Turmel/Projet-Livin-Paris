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

        }
    }
}
