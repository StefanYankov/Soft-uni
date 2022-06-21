using Microsoft.Data.SqlClient;
using System;

namespace P01InitialSetup
{
    public class StartUp
    {
        public static void Main()
        {
            using SqlConnection connection = new SqlConnection(string.Format(Configuration.ConnectionString, "master"));
            connection.Open();

            using (connection)
            {
                using SqlCommand sqlCommand = new SqlCommand(string.Format(Queries.CreateDatabase, Configuration.databaseName), connection);

                try
                {
                    sqlCommand.ExecuteNonQuery();
                    Console.WriteLine($"Successfully created database {Configuration.databaseName}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Invalid operation: {ex.Message}");
                    return;
                }

                using SqlCommand useSqlCommand = new SqlCommand(string.Format(Queries.UseCurrentDatabase, Configuration.databaseName), connection);

                useSqlCommand.ExecuteNonQuery();

                foreach (var query in Queries.CreateTablesQueries)
                {
                    using SqlCommand createTableCmd = new SqlCommand(query, connection);

                    try
                    {
                        createTableCmd.ExecuteNonQuery();
                        Console.WriteLine($"Successfully created table");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Invalid operation: {ex.Message}");
                    }
                }

                foreach (var query in Queries.InsertQueries)
                {
                    using SqlCommand insertCmd = new SqlCommand(query, connection);

                    try
                    {
                        int affectedRows = insertCmd.ExecuteNonQuery();
                        Console.WriteLine("Successfully inserted data into table");
                        Console.WriteLine($"Affected rows: {affectedRows}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Invalid operation: {ex.Message}");
                    }
                }
            }
        }
    }
}