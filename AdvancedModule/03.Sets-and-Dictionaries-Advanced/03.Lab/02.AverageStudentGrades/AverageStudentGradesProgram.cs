using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.AverageStudentGrades
{
    class AverageStudentGradesProgram
    {
        static void Main()
        {
            int studentsCount = int.Parse(Console.ReadLine());

            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();

            for (int i = 0; i < studentsCount; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string studentName = input[0];
                double grade = double.Parse(input[1]);

                if (students.ContainsKey(studentName))
                {
                    students[studentName].Add(grade);
                }
                else
                {
                    students[studentName] = new List<double>() { grade };
                }

            }


            foreach (var pair in students)
            {
                var name = pair.Key;
                var studentGrades = pair.Value;
                var average = studentGrades.Average();
                Console.Write($"{name} -> ");
                foreach (var grade in studentGrades)
                    Console.Write($"{grade:f2} ");
                Console.WriteLine($"(avg: {average:f2})");
            }

        }
    }
}
