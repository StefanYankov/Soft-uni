using System;
using Microsoft.Data.SqlClient;
using P01InitialSetup;

namespace P06RemoveVillain
{
    public class StartUp
    {
        public static void Main()
        {
            // Add project Dependencies to P01InitialSetup
            using SqlConnection connection =
                new SqlConnection(string.Format(Configuration.ConnectionString, Configuration.databaseName));
            connection.Open();

            Console.Write("Please enter target villain Id: ");
            int villainId = int.Parse(Console.ReadLine());

            using (connection)
            {
                SqlTransaction sqlTransaction = connection.BeginTransaction();
                using SqlCommand sqlCommand = connection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                try
                {
                    sqlCommand.CommandText = Queries.TakeVillainId;
                    sqlCommand.Parameters.AddWithValue("@villainId", villainId);
                    string villainName = (string)sqlCommand.ExecuteScalar();

                    if (villainName == null)
                    {
                        Console.WriteLine("No such villain was found.");
                        return;
                    }

                    sqlCommand.CommandText = Queries.DeleteVillainFromMinionsVillains;
                    int releasedMinions = sqlCommand.ExecuteNonQuery();

                    sqlCommand.CommandText = Queries.DeleteVillainFromVillains;
                    sqlCommand.ExecuteNonQuery();

                    string releasedMinionsMessage = string.Empty;
                    if (releasedMinions >= 0)
                    {
                        releasedMinionsMessage = $"{releasedMinions} minions were released.";
                    }
                    else if (releasedMinions == 1)
                    {
                        releasedMinionsMessage = $"{releasedMinions} minion was released.";
                    }

                    Console.WriteLine($"{villainName} was deleted.");
                    Console.WriteLine(releasedMinionsMessage);

                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                    try
                    {
                        sqlTransaction.Rollback();
                    }
                    catch (Exception exRollback)
                    {
                        Console.WriteLine(exRollback.Message);
                    }
                }
            }
        }
    }
}