using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;
using P01InitialSetup;

namespace P07PrintAllMinionNames
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
                using SqlCommand sqlCommand = new SqlCommand(Queries.TakeMinionNames, connection);

                using SqlDataReader sqlReader = sqlCommand.ExecuteReader();

                List<string> originalNames = new List<string>(sqlReader.FieldCount);

                while (sqlReader.Read())
                {
                    string name = (string)sqlReader["Name"];
                    originalNames.Add(name);
                }

                Console.WriteLine($"Original order: {Environment.NewLine + string.Join(Environment.NewLine, originalNames)}");

                Console.WriteLine(string.Concat(Enumerable.Repeat("-",10)));

                Console.WriteLine("New order:");

                while (originalNames.Count != 0)
                {
                    Console.WriteLine(originalNames[0]);
                    originalNames.RemoveAt(0);

                    if (originalNames.Count == 0)
                    {
                        break;
                    }

                    Console.WriteLine(originalNames.Last());
                    originalNames.RemoveAt(originalNames.Count - 1);
                }
            }
        }
    }
}
