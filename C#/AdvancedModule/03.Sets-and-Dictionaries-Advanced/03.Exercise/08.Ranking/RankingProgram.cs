using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Ranking
{
    class RankingProgram
    {
        static void Main()
        {
            var contestAndPasswords = new Dictionary<string, string>();
            var students = new SortedDictionary<string, Dictionary<string, int>>();
            var studentsAndPoints = new Dictionary<string, int>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "end of contests")
                {
                    break;
                }
                else if (input.Contains(':'))
                {
                    var contestAndPass = input.Split(':');
                    var contest = contestAndPass[0];
                    var password = contestAndPass[1];

                    if (!contestAndPasswords.ContainsKey(contest))
                    {
                        contestAndPasswords.Add(contest, password);
                    }
                }
            }
            while (true)
            {
                var line = Console.ReadLine();

                if (line == "end of submissions")
                {
                    break;
                }
                else
                {
                    var data = line.Split("=>");

                    var contest = data[0];
                    var password = data[1];
                    var name = data[2];
                    var points = int.Parse(data[3]);

                    if (contestAndPasswords.ContainsKey(contest) && contestAndPasswords[contest] == password)
                    {
                        if (!students.ContainsKey(name))
                        {
                            students.Add(name, new Dictionary<string, int>());
                            students[name].Add(contest, points);
                        }
                        else
                        {
                            if (!students[name].ContainsKey(contest))
                            {
                                students[name].Add(contest, points);
                            }
                            if (students[name][contest] < points)
                            {
                                students[name][contest] = points;
                            }
                        }
                    }
                }
            }
            foreach (var student in students)
            {
                studentsAndPoints.Add(student.Key, 0);
                studentsAndPoints[student.Key] = student.Value.Values.Sum();
            }

            foreach (var item in studentsAndPoints.OrderByDescending(x => x.Value))
            {
                var maxPoints = studentsAndPoints.Values.Max();
                if (item.Value == maxPoints)
                {
                    Console.WriteLine($"Best candidate is {item.Key} with total {item.Value} points.");
                }
            }

            Console.WriteLine("Ranking: ");

            foreach (var item in students)
            {
                Console.WriteLine($"{item.Key}");
                foreach (var contest in students[item.Key].OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}