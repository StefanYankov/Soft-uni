using System;
using System.Linq;

namespace P01WorldTour
{
    public class P01WorldTour
    {
        public static void Main()
        {
            string repository = Console.ReadLine();
            string input = string.Empty;

            while ((input=Console.ReadLine()) != "Travel")
            {
                var commandArgs = input.Split(':').ToArray();
                string command = commandArgs[0];

                if (command == "Add Stop")
                {
                    int startingIndex = int.Parse(commandArgs[1]);

                    if (startingIndex >= 0 && startingIndex <= repository.Length)
                    {
                        string wordToInsert = commandArgs[2];
                        repository = repository.Insert(startingIndex, wordToInsert);
                    }
                }
                else if (command == "Remove Stop")
                {
                    int startIndex = int.Parse(commandArgs[1]);
                    int endIndex = int.Parse(commandArgs[2]);

                    if ((startIndex >= 0 && startIndex <= repository.Length - 1) &&
                        (endIndex >= 0 && endIndex <= repository.Length - 1) && startIndex <= endIndex)
                    {
                        int length = endIndex - startIndex + 1;
                        repository = repository.Remove(startIndex, length);
                    }
                }
                else if (command == "Switch")
                {
                    string oldString = commandArgs[1];
                    string newString = commandArgs[2];
                    if (oldString != newString && repository.Contains(oldString))
                    {
                        repository = repository.Replace(oldString, newString);
                    }
                }

                Console.WriteLine(repository);
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {repository}");
        }
    }
}
