namespace P02AverageStudentGrades
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class AverageStudentGradesProgram
    {
       public static void Main()
        {
          int numberOfStudents = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> studentGrades = new Dictionary<string, List<decimal>>();
            for (int i = 0; i < numberOfStudents; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                string name = input[0];
                decimal grade = decimal.Parse(input[1]);

                if (!studentGrades.ContainsKey(name))
                {
                    studentGrades[name] = new List<decimal>();
                }
                studentGrades[name].Add(grade);
            }

            foreach (var student in studentGrades)
            {
                Console.WriteLine($"{student.Key} -> {String.Join(" ",student.Value.Select(v => $"{v:F2}"))} (avg: {student.Value.Average():F2})");
            }
        }
    }
}
