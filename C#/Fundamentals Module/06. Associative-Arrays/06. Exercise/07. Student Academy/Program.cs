using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var dict = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                string studentName = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!dict.ContainsKey(studentName))
                {
                    dict[studentName] = new List<double>();
                }

                dict[studentName].Add(grade);


            }

            foreach (var kvp in dict.OrderByDescending(x => x.Value.Average()).Where(x => x.Value.Average() >= 4.50))
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value.Average():f2}");
            }
        }
    }
}
