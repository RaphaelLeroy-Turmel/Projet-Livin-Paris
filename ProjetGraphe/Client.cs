using System;
using MySql.Data.MySqlClient;
    public class Clients
    {
        private string connectionString = "SERVER=localhost;UID=root;DATABASE=livinparis;PORT=3306;PASSWORD=root";

        public void AjouterClient()
        {
            Console.WriteLine("\n--- Ajout d'un nouveau client ---");
            Console.Write("Nom : "); string nom = Console.ReadLine();
            Console.Write("Prénom : "); string prenom = Console.ReadLine();
            Console.Write("Adresse : "); string adresse = Console.ReadLine();
            Console.Write("Métro proche : "); string metro = Console.ReadLine();
            Console.Write("Téléphone : "); string tel = Console.ReadLine();
            Console.Write("Email : "); string email = Console.ReadLine();
            Console.Write("Mot de passe : "); string mdp = Console.ReadLine();

            using var conn = new MySqlConnection(connectionString);
            conn.Open();

            string sql = @"
            INSERT INTO Utilisateurs 
            (nom, prenom, adresse, metro_proche, telephone, email, mdp, est_client)
            VALUES (@nom, @prenom, @adresse, @metro, @tel, @email, @mdp, true)";

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@nom", nom);
            cmd.Parameters.AddWithValue("@prenom", prenom);
            cmd.Parameters.AddWithValue("@adresse", adresse);
            cmd.Parameters.AddWithValue("@metro", metro);
            cmd.Parameters.AddWithValue("@tel", tel);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@mdp", mdp);
            int result = cmd.ExecuteNonQuery();
        }
        public void SupprimerClient()
        {
            Console.Write("\nID du client à supprimer : ");
            int id = int.Parse(Console.ReadLine());

            using var conn = new MySqlConnection(connectionString);
            conn.Open();

            string sql = "DELETE FROM Utilisateurs WHERE id_utilisateur = @id AND est_client = true";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);

            int result = cmd.ExecuteNonQuery();
            if (result > 0) { Console.WriteLine("Client supprimé"); }
        }
        public void ModifierClient()
        {
            Console.Write("\nID du client à modifier : ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Nouveau nom : ");
            string nouveauNom = Console.ReadLine();

            using var conn = new MySqlConnection(connectionString);
            conn.Open();

            string sql = "UPDATE Utilisateurs SET nom = @nom WHERE id_utilisateur = @id AND est_client = true";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@nom", nouveauNom);
            cmd.Parameters.AddWithValue("@id", id);

            int result = cmd.ExecuteNonQuery();
            if (result > 0) { Console.WriteLine("Client modifié"); }
        }
        public void ListerClientsParRue()
        {
            using var conn = new MySqlConnection(connectionString);
            conn.Open();

            string sql = @"
        SELECT id_utilisateur, nom, prenom, adresse
        FROM Utilisateurs
        WHERE est_client = true
        ORDER BY SUBSTRING_INDEX(SUBSTRING_INDEX(adresse, ',', 1), ' ', -2);";

            using var cmd = new MySqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            Console.WriteLine("\n Clients triés par rue :");
        Console.WriteLine("-------------------------------------------");
        while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string nom = reader.GetString(1);
                string prenom = reader.GetString(2);
                string adresse = reader.GetString(3);

                Console.WriteLine($"{id} - {nom} {prenom} | {adresse}");
            }
        Console.WriteLine("-------------------------------------------");
    }
        public void ListerClientsParMontant()
        {
            using var conn = new MySqlConnection(connectionString);
            conn.Open();

            string sql = @"
        SELECT 
            u.id_utilisateur, 
            u.nom, 
            u.prenom, 
            u.adresse, 
            IFNULL(SUM(c.total), 0) AS montant_total
        FROM Utilisateurs u
        LEFT JOIN Commandes c ON c.id_client = u.id_utilisateur
        WHERE u.est_client = true
        GROUP BY u.id_utilisateur
        ORDER BY montant_total DESC;";

            using var cmd = new MySqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            Console.WriteLine("\n Clients triés par montant d'achats cumulés :");
        Console.WriteLine("-------------------------------------------");
        while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string nom = reader.GetString(1);
                string prenom = reader.GetString(2);
                string adresse = reader.GetString(3);
                decimal montant = reader.GetDecimal(4);

                Console.WriteLine($"{id} - {nom} {prenom}  {adresse} | Total achats : {montant}");
            }
        Console.WriteLine("-------------------------------------------");
    }
        public void ListerClientsParNom()
        {
            using var conn = new MySqlConnection(connectionString);
            conn.Open();

            string sql = @"
        SELECT id_utilisateur, nom, prenom, adresse
        FROM Utilisateurs
        WHERE est_client = true
        ORDER BY nom ASC, prenom ASC;";

            using var cmd = new MySqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            Console.WriteLine("\n Clients triés par nom :");
        Console.WriteLine("-------------------------------------------");
        while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string nom = reader.GetString(1);
                string prenom = reader.GetString(2);
                string adresse = reader.GetString(3);

                Console.WriteLine($"{id} - {nom} {prenom} {adresse}");
            }
        Console.WriteLine("-------------------------------------------");
    }
    }
