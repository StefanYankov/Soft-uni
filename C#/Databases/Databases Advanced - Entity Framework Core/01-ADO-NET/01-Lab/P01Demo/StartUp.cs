using System;
using Microsoft.Data.SqlClient;

namespace P01Demo
{
    public class StartUp
    {
        public static void Main()
        {
            using (SqlConnection connection = new SqlConnection(
                       @"Server=.,1433;Database=SoftUni;User Id=sa;Password=SoftUn!2021;TrustServerCertificate=True;"))
            {
                connection.Open();
                string nonQuery = "UPDATE Employees SET Salary = Salary + 0.15 WHERE FirstName LIKE 'N%'";
                string scalarQuery = "SELECT COUNT(*) FROM Employees";
                string dataReaderQuery = "SELECT * FROM Employees ORDER BY [FirstName]";
                string dataReaderQueryJoin =
                    "SELECT d.Name, COUNT(*) AS Count " +
                    "FROM Employees e " +
                    "JOIN Departments d ON e.DepartmentId = d.DepartmentId " +
                    "GROUP BY d.Name";
                SqlCommand sqlCommand = new SqlCommand(dataReaderQueryJoin, connection);

                //var rowsAffected = sqlCommand.ExecuteNonQuery();
                //var rowsAffected = (int) sqlCommand.ExecuteScalar();
                //Console.WriteLine(rowsAffected);

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["Name"]} => {reader["Count"]}");
                    }
                    // connection.Close();

                }

                // connection.Close();
            }
        }
    }
}