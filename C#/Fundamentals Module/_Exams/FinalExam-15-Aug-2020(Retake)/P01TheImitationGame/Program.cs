
namespace P01TheImitationGame
{
    using System;
    using System.Linq;
    public class Program
    {
        public static void Main()
        {
            string message = Console.ReadLine();
            string commands;
            while (!(commands = Console.ReadLine()).Equals("Decode"))
            {
                string[] commandsArray = commands.Split("|", StringSplitOptions.RemoveEmptyEntries).ToArray();

                int numberOfLetters;
                int index;
                string value;
                string substring;
                string replacement;
                switch (commandsArray[0])
                {
                    case "Move":
                        numberOfLetters = int.Parse(commandsArray[1]);
                        message = message.Substring(numberOfLetters, message.Length - numberOfLetters) +
                                  message.Substring(0, numberOfLetters);
                        break;
                    case "Insert":
                        index = int.Parse(commandsArray[1]);
                        value = commandsArray[2];
                        if (index < 0 || index > message.Length)
                        {
                            continue;
                        }

                        message = message.Insert(index, value);
                        break;
                    case "ChangeAll":
                        substring = commandsArray[1];
                        replacement = commandsArray[2];
                        message = message.Replace(substring, replacement);
                        break;
                }
            }

            Console.WriteLine($"The decrypted message is: {message}");
        }
    }
}
