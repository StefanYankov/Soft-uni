using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;
using P01InitialSetup;

namespace P08IncreaseMinionAge
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using SqlConnection connection =
                new SqlConnection(string.Format(Configuration.ConnectionString, Configuration.databaseName));
            connection.Open();

            using (connection)
            {
                List<int> minionsIds = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                using SqlCommand updateCmd = new SqlCommand(Queries.UpdateMinions, connection);

                for (int i = 0; i < minionsIds.Count; i++)
                {
                    int currentId = minionsIds[i];
                    updateCmd.Parameters.AddWithValue("@Id", currentId);
                    updateCmd.ExecuteNonQuery();
                    updateCmd.Parameters.Clear();
                }

                using SqlCommand resultCmd = new SqlCommand(Queries.TakeMinionsNameAndAge, connection);
                using SqlDataReader reader = resultCmd.ExecuteReader();

                while (reader.Read())
                {
                    string minionName = (string)reader["Name"];
                    int minionAge = (int)reader["Age"];

                    Console.WriteLine($"{minionName} {minionAge}");
                }
            }
        }
    }
}