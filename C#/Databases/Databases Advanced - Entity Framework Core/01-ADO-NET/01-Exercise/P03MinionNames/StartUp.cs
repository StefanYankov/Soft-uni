using System;
using Microsoft.Data.SqlClient;
using P01InitialSetup;

namespace P03MinionNames
{
    public class StartUp
    {
        public static void Main()
        {
            using SqlConnection connection = new SqlConnection(string.Format(Configuration.ConnectionString, Configuration.databaseName));
            connection.Open();

            Console.Write("Please add the required villain Id: ");
            int villainId = int.Parse(Console.ReadLine());
            using (connection)
            {
                using SqlCommand idCommand = new SqlCommand(Queries.VillainsIdQuery, connection);

                idCommand.Parameters.AddWithValue("@Id", villainId);

                string villainName = (string)idCommand.ExecuteScalar();

                if (villainName == null)
                {
                    Console.WriteLine($"No villain with ID {villainId} exists in the database.");
                    return;
                }

                using SqlCommand minionsCommand = new SqlCommand(Queries.MinionsQuery, connection);

                minionsCommand.Parameters.AddWithValue("@Id", villainId);

                SqlDataReader sqlDataReader = minionsCommand.ExecuteReader();

                using (sqlDataReader)
                {
                    Console.WriteLine($"Villain: {villainName}");

                    int counter = 1;
                    while (sqlDataReader.Read())
                    {
                        string minionName = (string)sqlDataReader["MinionName"];

                        if (sqlDataReader.HasRows)
                        {
                            int minionAge = (int)sqlDataReader["MinionAge"];

                            Console.WriteLine($"{counter}. {minionName} {minionAge}");
                            counter++;
                        }
                        else
                        {
                            Console.WriteLine("(no minions)");
                        }
                    }
                }
            }
        }
    }
}