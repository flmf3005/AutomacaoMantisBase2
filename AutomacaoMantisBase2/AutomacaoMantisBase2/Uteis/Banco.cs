using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomacaoMantisBase2.Uteis
{
    class Banco
    {
        private static SqlConnection GetDBConnection()
        {
            string connectionString = "Data Source=OLTP-SQLHOM.localiza.corp,1633;Initial Catalog=db_green;Integrated Security=SSPI;Persist Security Info=True;MultipleActiveResultSets=True";

            //string connectionString = "Data Source=" + Properties.Settings.Default.DB_URL + "," + Properties.Settings.Default.DB_PORT + ";" +
            //                          "Initial Catalog=" + Properties.Settings.Default.DB_NAME + ";" + 
            //                          "User ID=" + Properties.Settings.Default.DB_USER + "; " +
            //                          "Password=" + Properties.Settings.Default.DB_PASSWORD + ";";

            SqlConnection connection = new SqlConnection(connectionString);

            return connection;
        }
    }
}
