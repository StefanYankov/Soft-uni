using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] userNames = Console.ReadLine()
                .Split(", ")
                .ToArray();

            for (int i = 0; i < userNames.Length; i++)
            {
                string singleUsername = userNames[i];

                bool isValid = false;

                if (singleUsername.Length >= 3 && singleUsername.Length <= 16)
                {
                    for (int j = 0; j < singleUsername.Length; j++)
                    {
                        char currentCharacter = singleUsername[j];

                        if (char.IsLetterOrDigit(currentCharacter) || currentCharacter == '-' || currentCharacter == '_')
                        {
                            isValid = true;
                        }
                        else
                        {
                            isValid = false;
                            break;
                        }

                    }

                    if (isValid)
                    {
                        Console.WriteLine(singleUsername);
                    }
                }
            }

        }
    }
}
