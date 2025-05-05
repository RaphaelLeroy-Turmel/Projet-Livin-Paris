using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Text.Json;
using MySql.Data.MySqlClient;
using LivInParis.Data;

namespace LivInParis.Export
{
    // Classe représentant une commande pour l'export
    public class CommandeExport
    {
        public int IdCommande { get; set; }
        public int IdClient { get; set; }
        public DateTime DateCommande { get; set; }
        public decimal PrixTotal { get; set; }
    }

    public static class Exporteur
    {
        // Récupère toutes les commandes de la BDD
        public static List<CommandeExport> GetCommandes()
        {
            var commandes = new List<CommandeExport>();

            using var conn = ConnexionDB.GetConnection();
            string query = "SELECT id_commande, id_client, date_commande, total FROM commandes";

            using var cmd = new MySqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                commandes.Add(new CommandeExport
                {
                    IdCommande = reader.GetInt32("id_commande"),
                    IdClient = reader.GetInt32("id_client"),
                    DateCommande = reader.GetDateTime("date_commande"),
                    PrixTotal = reader.GetDecimal("total")
                });
            }

            return commandes;
        }

        // Exporte la liste de commandes en fichier XML
        public static void ExporterCommandesEnXml(string cheminFichier)
        {
            var commandes = GetCommandes();
            var serializer = new XmlSerializer(typeof(List<CommandeExport>));

            using var writer = new StreamWriter(cheminFichier);
            serializer.Serialize(writer, commandes);
        }

        // Exporte la liste de commandes en fichier JSON
        public static void ExporterCommandesEnJson(string cheminFichier)
        {
            var commandes = GetCommandes();
            var json = JsonSerializer.Serialize(commandes, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(cheminFichier, json);
        }

        // Exemple d'appel depuis un bouton pour XML
        public static void ExporterDepuisInterfaceXml()
        {
            string chemin = "commandes.xml";
            try
            {
                ExporterCommandesEnXml(chemin);
                MessageBox.Show("Export XML terminé : " + chemin);
                System.Diagnostics.Process.Start("explorer.exe", chemin);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur export XML : " + ex.Message);
            }
        }

        // Exemple d'appel depuis un bouton pour JSON
        public static void ExporterDepuisInterfaceJson()
        {
            string chemin = "commandes.json";
            try
            {
                ExporterCommandesEnJson(chemin);
                MessageBox.Show("Export JSON terminé : " + chemin);
                System.Diagnostics.Process.Start("explorer.exe", chemin);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur export JSON : " + ex.Message);
            }
        }
    }
}
