namespace P01ValidUsernames
{
    using System;
    using System.Linq;
    public class Program
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            for (int i = 0; i < input.Length; i++)
            {
                string currentUserName = input[i];

                if (CheckLength(currentUserName) && CheckIfOnlyLettersNumbersHyphens(currentUserName))
                {
                    Console.WriteLine(currentUserName);
                }
            }
        }

        private static bool CheckIfOnlyLettersNumbersHyphens(string currentUserName)
        {
            for (int i = 0; i < currentUserName.Length; i++)
            {
                if (!(char.IsLetterOrDigit(currentUserName[i]) || currentUserName[i].Equals('-') || currentUserName[i].Equals('_')))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool CheckLength(string currentUserName)
        {
            if (currentUserName.Length < 3 || currentUserName.Length > 16)
            {
                return false;
            }
            return true;
        }
    }
}
