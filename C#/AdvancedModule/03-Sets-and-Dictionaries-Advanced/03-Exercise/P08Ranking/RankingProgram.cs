namespace P08Ranking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class RankingProgram
    {
        public static void Main()
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
            Dictionary<string, string> passwordsRepository = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> submissionsRepository =
                new Dictionary<string, Dictionary<string, int>>();
            while (true)
            {
                string[] contestInfo = Console.ReadLine().Split(':', StringSplitOptions.RemoveEmptyEntries);

                if (contestInfo[0].Equals("end of contests"))
                {
                    break;
                }
                string contest = contestInfo[0];
                string password = contestInfo[1];
                if (!passwordsRepository.ContainsKey(contest))
                {
                    passwordsRepository.Add(contest, string.Empty);
                }

                passwordsRepository[contest] = password;
            }

            while (true)
            {
                string[] submissionsInfo = Console.ReadLine().Split("=>", StringSplitOptions.RemoveEmptyEntries);
                if (submissionsInfo[0].Equals("end of submissions"))
                {
                    break;
                }
                string contest = submissionsInfo[0];
                if (!passwordsRepository.ContainsKey(contest))
                {
                    continue;
                }
                string password = submissionsInfo[1];
                if (!passwordsRepository[contest].Equals(password))
                {
                    continue;
                }
                string username = submissionsInfo[2];
                if (!submissionsRepository.ContainsKey(username))
                {
                    submissionsRepository.Add(username, new Dictionary<string, int>());
                }
                int points = int.Parse(submissionsInfo[3]);
                if (!submissionsRepository[username].ContainsKey(contest))
                {
                    submissionsRepository[username].Add(contest, 0);
                }

                if (submissionsRepository[username][contest] < points)
                {
                    submissionsRepository[username][contest] = points;
                }
            }

            // with LINQ
            string user = submissionsRepository.OrderByDescending(s => s.Value.Values.Sum(v => v)).FirstOrDefault().Key;
            int totalPoints = submissionsRepository.OrderByDescending(s => s.Value.Values.Sum(v => v)).FirstOrDefault().Value.Values.Sum(x => x);

            // with foreach
            //string user = string.Empty;
            //int totalPoints = 0;
            //foreach (var submission in submissionsRepository.OrderBy(x => x.Key))
            //{
            //    int tempPoints = 0;
            //    string tempName = submission.Key;
            //    foreach (var KvP in submission.Value.OrderByDescending(x => x.Value))
            //    {
            //        tempPoints += KvP.Value;
            //    }

            //    if (tempPoints >= totalPoints)
            //    {
            //        totalPoints = tempPoints;
            //        user = tempName;
            //    }
            //}

            Console.WriteLine($"Best candidate is {user} with total {totalPoints} points.");
            Console.WriteLine("Ranking:");
            foreach (var submission in submissionsRepository.OrderBy(x => x.Key))
            {
                Console.WriteLine(submission.Key);
                foreach (var KvP in submission.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {KvP.Key} -> {KvP.Value}");
                }
            }
        }
    }
}
