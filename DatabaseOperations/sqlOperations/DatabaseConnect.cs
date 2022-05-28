using MySql.Data.MySqlClient;
using System;

namespace DatabaseOperations.sqlOperations
{
    public class DatabaseConnect
    {
        public MySqlConnection cnn { get; private set; }
        private DatabaseConnect()
        {

        }

        public bool connectToDb()
        {
            string connectionString = null;

            connectionString = "server=localhost;database=whatsapp;uid=root;pwd=;";
            cnn = new MySqlConnection(connectionString);
            if (cnn != null)
            {
                Console.WriteLine("Connection Open");
                return true;
            }
            Console.WriteLine("Connection FAILED");
            return false;
        }

        public static DatabaseConnect of()
        {
            DatabaseConnect databaseConnect = new DatabaseConnect();
            databaseConnect.connectToDb();
            return databaseConnect;
        }
    }
}
