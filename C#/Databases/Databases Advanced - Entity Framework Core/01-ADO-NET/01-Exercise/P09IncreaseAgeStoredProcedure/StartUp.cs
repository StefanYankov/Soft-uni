using System;
using System.Data;
using Microsoft.Data.SqlClient;
using P01InitialSetup;

namespace P09IncreaseAgeStoredProcedure
{
    public class StartUp
    {
        public static void Main()
        {
            using SqlConnection connection =
                new SqlConnection(string.Format(Configuration.ConnectionString, Configuration.databaseName));
            connection.Open();
            using (connection)
            {
                int minionId = int.Parse(Console.ReadLine());

                // Create procedure
                using SqlCommand createCommand = new SqlCommand(Queries.CreateProcedure, connection);
                createCommand.ExecuteNonQuery();

                // Exec procedure
                using SqlCommand execCommand = new SqlCommand(Configuration.ProcedureName, connection);

                execCommand.CommandType = CommandType.StoredProcedure;
                execCommand.Parameters.AddWithValue("@Id", minionId);
                execCommand.ExecuteNonQuery();

                // Create reader to show result after procedure executes
                using SqlCommand selectCommand = new SqlCommand(Queries.SelectMinionNameAndAge, connection);
                selectCommand.Parameters.AddWithValue("@Id", minionId);

                using SqlDataReader reader = selectCommand.ExecuteReader();

                while (reader.Read())
                {
                    string minionName = (string)reader["Name"];
                    int minionAge = (int)reader["Age"];

                    Console.WriteLine($"{minionName} - {minionAge} years old");
                }
            }
        }
    }
}