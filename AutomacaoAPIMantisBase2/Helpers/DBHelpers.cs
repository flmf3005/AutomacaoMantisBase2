using AutomacaoAPIMantisBase2.Queries;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AutomacaoAPIMantisBase2.Helpers
{
    public class DBHelpers
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
            ExecuteQuery(Queries.Queries.InicializaTestes);
        }

    }
}
