using System;
using System.Linq;
using System.Text;

namespace P01ActivationKeys
{
    public class P01ActivationKeys
    {
        public static void Main()
        {
            string rawActivationKey = Console.ReadLine();
            //abcdefghijklmnopqrstuvwxyz

            string command = string.Empty;
            while ((command=Console.ReadLine()) != "Generate")
            {
                string[] commandArgs = command.Split(">>>", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string instruction = commandArgs[0];
                int startIndex = 0;
                int endIndex = 0;
                switch (instruction)
                {

                    case "Contains":
                        string subString = commandArgs[1];

                        if (rawActivationKey.Contains(subString))
                        {
                            Console.WriteLine($"{rawActivationKey} contains {subString}");
                        }
                        else
                        {
                            Console.WriteLine("Substring not found!");
                        }
                        break;
                    case "Flip":
                        string caseCommand = commandArgs[1];
                        startIndex = int.Parse(commandArgs[2]);
                        endIndex = int.Parse(commandArgs[3]);
                        string tempSubString = rawActivationKey.Substring(startIndex, endIndex - startIndex);
                        if (caseCommand == "Upper")
                        {
                            tempSubString = tempSubString.ToUpper();
                        }
                        else if (caseCommand == "Lower")
                        {
                            tempSubString = tempSubString.ToLower();

                        }

                        StringBuilder sb = new StringBuilder(rawActivationKey);
                        sb.Remove(startIndex, endIndex - startIndex);
                        sb.Insert(startIndex, tempSubString);
                        rawActivationKey = sb.ToString();
                        Console.WriteLine(rawActivationKey);
                        break;
                    case "Slice":
                        startIndex = int.Parse(commandArgs[1]);
                        endIndex = int.Parse(commandArgs[2]);
                        StringBuilder sbs = new StringBuilder(rawActivationKey);
                        sbs.Remove(startIndex, endIndex-startIndex);
                        rawActivationKey = sbs.ToString();
                        Console.WriteLine(rawActivationKey);
                        break;
                }
            }
            Console.WriteLine($"Your activation key is: {rawActivationKey}");
        }
    }
}
