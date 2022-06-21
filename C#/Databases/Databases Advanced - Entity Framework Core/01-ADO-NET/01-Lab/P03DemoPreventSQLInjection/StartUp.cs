using System;
using Microsoft.Data.SqlClient;

namespace P03DemoPreventSQLInjection
{
    public class StartUp
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
                            WHERE Username = '@Username'
                            AND Password = '@Password';";
                var sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.Add(new SqlParameter("@Username", username));
                sqlCommand.Parameters.Add(new SqlParameter("@Password", password));
                var usersCount = (int)sqlCommand.ExecuteScalar();
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