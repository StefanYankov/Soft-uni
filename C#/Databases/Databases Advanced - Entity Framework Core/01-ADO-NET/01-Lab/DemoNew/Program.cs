using Microsoft.Data.SqlClient;
using System;

namespace DemoNew
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Server=BG-5CG00410VW;Integrated Security=SSPI;Database=SoftUni;TrustServerCertificate=True;";
            // string connectionStringWithUserID = @"Server=BG-5CG00410VW;User Id=SerafimGerasimoff;Password=123456;Database=SoftUni;TrustServerCertificate=True;"; ;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                /*
                string query = "SELECT COUNT(*) FROM Employees";
                var sqlCommand = new SqlCommand(query, connection);
                var test = sqlCommand.ExecuteScalar();
                Console.WriteLine(test.ToString());
                */

                string query2 = @"UPDATE Employees SET Salary = Salary + 0.12 WHERE FirstName LIKE 'N%'";
                var sqlCommand2 = new SqlCommand(query2, connection);       
                var rowsAffected = sqlCommand2.ExecuteNonQuery();
                Console.WriteLine(rowsAffected);
            };

        }
    }
}
