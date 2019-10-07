using System;
using System.Linq;

namespace _03._The_Final_Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().ToList();
            string commands = Console.ReadLine();

            while (commands != "Stop")
            {
                var commandsArr = commands.Split().ToArray();
                if (commandsArr[0] == "Swap")
                {
                    string word1 = commandsArr[1];
                    string word2 = commandsArr[2];

                }

                commands = Console.ReadLine();

            }

        }
    }
}
