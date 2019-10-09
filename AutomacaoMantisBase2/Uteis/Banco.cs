using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomacaoMantisBase2.Uteis
{
    class Banco
    {
        private static MySqlConnection GetDBConnection()
        {
            string connectionString = "Server= 192.168.99.100; Port= 3306; Database= bugtracker; UID= root; Password= root; SslMode= none";

            MySqlConnection connection = new MySqlConnection(connectionString);

            return connection;
        }

        public static void ExecuteQuery(string query)
        {
            using (MySqlCommand cmd = new MySqlCommand(query, GetDBConnection()))
            {
                cmd.CommandTimeout = Int32.Parse(ConfigurationManager.AppSettings["timeout"].ToString());
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
        }

        public static void InicializarTestes()
        {
            ExecuteQuery(Queries.InicializaTestes);
        }
    }
}
