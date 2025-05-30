﻿using MySql.Data.MySqlClient;
using TEST_Projet_Livin_Paris;
using ProjetGraphe;
using LivInParis;

namespace LivInParis.Data
{///Raphaël_LEROY TURMEL Thomas LIOTIER Loan LU-CHI-VANG TD K
    public static class ConnexionDB
    {

        private static string server = "localhost";
        private static string user = "root";
        private static string password = "root";
        private static string database = "livinparis";

        private static string connectionString =
            $"server={server};user={user};password={password};database={database};port=3306;";

        public static MySqlConnection GetConnection()
        {
            var conn = new MySqlConnection(connectionString);
            conn.Open(); /// Ouvre immédiatement la connexion
            return conn;
        }
    }
}

