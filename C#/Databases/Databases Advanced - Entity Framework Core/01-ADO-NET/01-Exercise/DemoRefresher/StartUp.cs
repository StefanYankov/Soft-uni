using System;
using Microsoft.Data.SqlClient;

namespace DemoRefresher
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            string server = "BG-5CG00410VW";
            using SqlConnection connection = new SqlConnection(string.Format(Configuration.ConnectionString, server, "master"));
            connection.Open();

            using (connection)
            {
                using SqlCommand sqlCommand = new SqlCommand(string.Format(Queries.CreateDatabase, Configuration.DatabaseName), connection);

            }
        }
    }
}
