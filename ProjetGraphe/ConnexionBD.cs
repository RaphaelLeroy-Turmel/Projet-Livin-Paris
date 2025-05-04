using MySql.Data.MySqlClient;
using TEST_Projet_Livin_Paris;
using ProjetGraphe;
using LivInParis;

namespace LivInParis.Data
{
    public static class ConnexionDB
    {
        // ⚠️ À personnaliser selon ta configuration MySQL
        private static string server = "localhost";
        private static string user = "root";
        private static string password = "root";  // ← change ceci
        private static string database = "livinparis";

        private static string connectionString =
            $"server={server};user={user};password={password};database={database};port=3306;";

        /// <summary>
        /// Retourne une connexion MySQL ouverte
        /// </summary>
        public static MySqlConnection GetConnection()
        {
            var conn = new MySqlConnection(connectionString);
            conn.Open();
            return conn;
        }
    }
}
