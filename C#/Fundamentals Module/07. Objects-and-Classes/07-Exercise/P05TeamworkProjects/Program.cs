namespace P05TeamworkProjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main()
        {
            int numberOfTeams = int.Parse(Console.ReadLine());

            List<Team> listOfTeams = new List<Team>();
            for (int i = 1; i <= numberOfTeams; i++)
            {
                string[] tokens = Console.ReadLine().Split("-");
                string creatorOfTeam = tokens[0];
                string currentTeam = tokens[1];

                if (listOfTeams.Any(x => x.Creator == creatorOfTeam))
                {
                    Console.WriteLine($"{creatorOfTeam} cannot create another team!");
                }
                else if (listOfTeams.Any(x => x.Name == currentTeam))
                {
                    Console.WriteLine($"Team {currentTeam} was already created!");
                }
                else
                {
                    listOfTeams.Add(new Team(creatorOfTeam, currentTeam));
                    Console.WriteLine($"Team {currentTeam} has been created by {creatorOfTeam}!");
                }
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end of assignment")
            {
                string[] tokens = input.Split("->");
                string userToJoinTeam = tokens[0];
                string currentTeam = tokens[1];

                if (!listOfTeams.Any(t => t.Name == currentTeam))
                {
                    Console.WriteLine($"Team {currentTeam} does not exist!");
                }
                else if (listOfTeams.Any(x => x.members.Contains(userToJoinTeam)) ||
                    listOfTeams.Any(y => y.Creator == userToJoinTeam))
                {
                    Console.WriteLine($"Member {userToJoinTeam} cannot join team {currentTeam}!");
                }
                else
                {
                    int indexToAdd = listOfTeams.FindIndex(x => x.Name == currentTeam);
                    listOfTeams[indexToAdd].members.Add(userToJoinTeam);
                }
            }

            listOfTeams = listOfTeams.OrderByDescending(x => x.members.Count).ThenBy(y => y.Name).ToList();
            List<string> disbandedTeams = new List<string>();

            for (int currentTeam = 0; currentTeam < listOfTeams.Count; currentTeam++)
            {
                if (listOfTeams[currentTeam].members.Count == 0)
                {
                    disbandedTeams.Add(listOfTeams[currentTeam].Name);
                    continue;
                }

                PrintValidTeams(listOfTeams, currentTeam);
            }

            PrintDisbandedTeams(disbandedTeams);
        }

        private static void PrintValidTeams(List<Team> listOfTeams, int currentTeam)
        {
            Console.WriteLine(listOfTeams[currentTeam].Name);
            Console.WriteLine($"- {listOfTeams[currentTeam].Creator}");

            listOfTeams[currentTeam].members.Sort();

            foreach (var member in listOfTeams[currentTeam].members)
            {
                Console.WriteLine($"-- {member}");
            }
        }

        private static void PrintDisbandedTeams(List<string> disbandedTeams)
        {
            Console.WriteLine("Teams to disband:");

            disbandedTeams.Sort();
            disbandedTeams.ForEach(t => Console.WriteLine(t));
        }
    }

    public class Team
    {
        public string Creator { get; set; }
        public string Name { get; set; }
        public List<string> members = new List<string>();

        public Team(string creatorOfTeam, string team)
        {
            this.Creator = creatorOfTeam;
            this.Name = team;
        }
    }
}