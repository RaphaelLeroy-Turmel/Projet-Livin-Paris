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

        private void btnDeconnexion_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Restart(); // ou revenir à FormConnexion
        }
        private void lstPlats_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
