using MySql.Data.MySqlClient;
using System;

public class Cuisinier
{
    private readonly string connectionString = "server=localhost;user=root;database=livinparis;port=3306;password=root";

    public void AjouterCuisinierDepuisConsole()
    {
        Console.WriteLine("=== Ajout d'un nouveau cuisinier ===");

        Console.Write("Nom : "); string nom = Console.ReadLine();
        Console.Write("Prénom : "); string prenom = Console.ReadLine();
        Console.Write("Adresse : "); string adresse = Console.ReadLine();
        Console.Write("Métro : "); string metro = Console.ReadLine();
        Console.Write("Téléphone : "); string tel = Console.ReadLine();
        Console.Write("Email : "); string email = Console.ReadLine();
        Console.Write("Mot de passe : "); string mdp = Console.ReadLine();

        using var conn = new MySqlConnection(connectionString);
        conn.Open();

        string sql = @"
            INSERT INTO Utilisateurs
            (nom, prenom, adresse, metro_proche, telephone, email, mdp, est_cuisinier)
            VALUES (@nom, @prenom, @adresse, @metro, @tel, @email, @mdp, true);";

        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@nom", nom);
        cmd.Parameters.AddWithValue("@prenom", prenom);
        cmd.Parameters.AddWithValue("@adresse", adresse);
        cmd.Parameters.AddWithValue("@metro", metro);
        cmd.Parameters.AddWithValue("@tel", tel);
        cmd.Parameters.AddWithValue("@email", email);
        cmd.Parameters.AddWithValue("@mdp", mdp);

        cmd.ExecuteNonQuery();
        Console.WriteLine("Cuisinier ajouté avec succès.");
    }
    public void ListerClientsServis(int idCuisinier, DateTime? depuis = null)
    {
        using var conn = new MySqlConnection(connectionString);
        conn.Open();

        string sql = @"
            SELECT DISTINCT u.id_utilisateur, u.nom, u.prenom
            FROM Utilisateurs u
            JOIN Commandes c ON c.id_client = u.id_utilisateur
            JOIN Lignes_Commande lc ON lc.id_commande = c.id_commande
            JOIN Plats p ON p.id_plat = lc.id_plat
            WHERE p.id_cuisinier = @idCuisinier";

        if (depuis.HasValue)
        {
            sql += " AND c.date_commande >= @depuis";
        }

        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@idCuisinier", idCuisinier);
        if (depuis.HasValue)
            cmd.Parameters.AddWithValue("@depuis", depuis.Value);

        using var reader = cmd.ExecuteReader();

        Console.WriteLine("Clients servis :");
        Console.WriteLine("-------------------------------------------");
        while (reader.Read())
        {
            Console.WriteLine($"{reader.GetInt32(0)} - {reader.GetString(1)} {reader.GetString(2)}");
        }
        Console.WriteLine("-------------------------------------------");
    }
    public void ListerPlatsParFrequence(int idCuisinier)
    {
        using var conn = new MySqlConnection(connectionString);
        conn.Open();

        string sql = @"
            SELECT nom_plat, COUNT(*) AS nb
            FROM Plats
            WHERE id_cuisinier = @id
            GROUP BY nom_plat
            ORDER BY nb DESC";

        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@id", idCuisinier);

        using var reader = cmd.ExecuteReader();

        Console.WriteLine("Plats réalisés par fréquence :");
        Console.WriteLine("-------------------------------------------");
        while (reader.Read())
        {
            Console.WriteLine($"{reader.GetString(0)} - {reader.GetInt32(1)} fois");
        }
        Console.WriteLine("-------------------------------------------");
    }
    public void ListerCuisiniers()
    {
        using var conn = new MySqlConnection(connectionString);
        conn.Open();

        string sql = @"
        SELECT id_utilisateur, nom, prenom, adresse, email, telephone
        FROM Utilisateurs
        WHERE est_cuisinier = true
        ORDER BY nom ASC";

        using var cmd = new MySqlCommand(sql, conn);
        using var reader = cmd.ExecuteReader();

        Console.WriteLine("\nListe des cuisiniers :");
        Console.WriteLine("-------------------------------------------");

        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            string nom = reader.GetString(1);
            string prenom = reader.GetString(2);
            string adresse = reader.GetString(3);
            string email = reader.GetString(4);
            string tel = reader.GetString(5);

            Console.WriteLine($"{id} - {nom} {prenom} | {adresse} | {email} | {tel}");
        }

        Console.WriteLine("-------------------------------------------");
    }

    public void AfficherPlatDuJour(int idCuisinier)
    {
        using var conn = new MySqlConnection(connectionString);
        conn.Open();

        string sql = @"
            SELECT nom_plat, date_fabrication
            FROM Plats
            WHERE id_cuisinier = @id AND DATE(date_fabrication) = CURDATE()";

        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@id", idCuisinier);

        using var reader = cmd.ExecuteReader();

        Console.WriteLine("Plat(s) du jour :");
        while (reader.Read())
        {
            Console.WriteLine($"{reader.GetString(0)} (préparé le {reader.GetDateTime(1):yyyy-MM-dd})");
        }
    }
    public void SupprimerCuisinier(int id)
    {
        using var conn = new MySqlConnection(connectionString);
        conn.Open();

        string sql = "DELETE FROM Utilisateurs WHERE id_utilisateur = @id AND est_cuisinier = true";
        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@id", id);
        int result = cmd.ExecuteNonQuery();

        Console.WriteLine(result > 0 ? "Cuisinier supprimé." : "Aucun cuisinier supprimé.");
    }
    public void ModifierNomCuisinier(int id, string nouveauNom)
    {
        using var conn = new MySqlConnection(connectionString);
        conn.Open();

        string sql = "UPDATE Utilisateurs SET nom = @nom WHERE id_utilisateur = @id AND est_cuisinier = true";
        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@nom", nouveauNom);
        cmd.Parameters.AddWithValue("@id", id);

        int result = cmd.ExecuteNonQuery();
        Console.WriteLine(result > 0 ? "Nom du cuisinier modifié." : "Modification échouée.");
    }

}
