using System;
using Microsoft.Data.SqlClient;

namespace P02DemoSQLInjection
{
    internal class StartUp
    {
        public static void Main()
        {
            Console.Write("Please enter username: ");
            var username = Console.ReadLine();
            Console.Write("Please enter password: ");
            var password = Console.ReadLine();
            using (SqlConnection connection = new SqlConnection(
                       @"Server=.,1433;Database=Minions;User Id=sa;Password=SoftUn!2021;TrustServerCertificate=True;"))
            {
                connection.Open();
                string query =
                    @$"SELECT COUNT(*)
                            FROM Users
                            WHERE Username = '{username}'
                            AND Password = '{password}'";
                var sqlCommand = new SqlCommand(query, connection);

                var usersCount = (int) sqlCommand.ExecuteScalar();
                if (usersCount > 0)
                {
                    Console.WriteLine($"Access granted! Welcome {username}!");
                }
                else
                {
                    Console.WriteLine($"Access denied!");
                }
                
            }
        }
    }
}