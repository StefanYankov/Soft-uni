namespace P01Problem
{
    using System;
    using System.Linq;
    public class Program
    {
        public static void Main()
        {
            string userName = Console.ReadLine();
            string input = string.Empty;

            while (!(input = Console.ReadLine()).Equals("Registration"))
            {
                var commandsArr = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var command = commandsArr[0];
                switch (command)
                {
                    case "Letters":
                        var modifyCommand = commandsArr[1];
                        if (modifyCommand.Equals("Lower"))
                        {
                            var converted = userName.Select(
                                x => char.IsUpper(x) ? char.ToLower(x) : x);
                            userName = new string(converted.ToArray());
                        }
                        else if (modifyCommand.Equals("Upper"))
                        {
                            var converted = userName.Select(x => char.IsLower(x) ? char.ToUpper(x) : x);
                            userName = new string(converted.ToArray());
                        }
                        Console.WriteLine(userName);
                        break;
                    case "Reverse":
                        int startIndex = int.Parse(commandsArr[1]);
                        int endIndex = int.Parse(commandsArr[2]);
                        bool isValidIndexes = true;

                        if (startIndex >= endIndex)
                        {
                            isValidIndexes = false;
                            break;
                        } 
                        else if (startIndex < 0 || endIndex < 0)
                        {
                            isValidIndexes = false;
                            break;
                        } 
                        else if (startIndex > userName.Length || endIndex > userName.Length)
                        {
                            isValidIndexes = false;
                            break;
                        }

                        if (isValidIndexes)
                        {
                            string tempUserName = userName.Substring(startIndex, endIndex - startIndex + 1); // to check length

                            tempUserName = Reverse(tempUserName);
                            Console.WriteLine(tempUserName);
                        }
                        break;
                    case "Substring":
                        var subString = commandsArr[1];
                        if (userName.Contains(subString))
                        {
                            userName = userName.Replace(subString, "");
                            Console.WriteLine(userName);
                        }
                        else
                        {
                            Console.WriteLine($"The username {userName} doesn't contain {subString}.");
                        }
                        break;
                    case "Replace":
                        var ch = commandsArr[1];
                        if (!userName.Contains(ch))
                        {
                            continue;
                        }
                        while (userName.Contains(ch))
                        {
                            userName = userName.Replace(ch, "-");
                        }
                        Console.WriteLine(userName);

                        break;
                    case "IsValid":
                        var validChar = commandsArr[1];
                        if (userName.Contains(validChar))
                        {
                            Console.WriteLine("Valid username.");
                        }
                        else
                        {
                            Console.WriteLine($"{validChar} must be contained in your username.");
                        }
                        break;
                }
            }
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
