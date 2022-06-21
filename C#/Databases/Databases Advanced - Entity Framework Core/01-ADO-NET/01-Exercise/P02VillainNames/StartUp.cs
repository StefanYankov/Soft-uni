using System;
using Microsoft.Data.SqlClient;
using P01InitialSetup;

namespace P02VillainNames
{
    public class StartUp
    {
        public static void Main()
        {
            using SqlConnection connection = new SqlConnection(string.Format(Configuration.ConnectionString, Configuration.databaseName));
            connection.Open();

            using (connection)
            {
                using SqlCommand sqlCommand = new SqlCommand(Queries.VillainNames, connection);

                try
                {
                    using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        string villainName = (string)sqlDataReader["Name"];
                        int minionsCount = (int)sqlDataReader["MinionsCount"];

                        Console.WriteLine($"{villainName} - {minionsCount}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Invalid operation: {ex.Message}");
                }
            }
        }
    }
}