using System;

namespace _04._Password_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputPassowrd = Console.ReadLine();

            bool isBetweenSixAndTenChars = StringLenghtChecker(inputPassowrd);
            bool isOnlyLettersAndDigits = StringCharsChecker(inputPassowrd);
            bool haveAtLeastTwoDigits = DigitCountChecker(inputPassowrd);

            if (!isBetweenSixAndTenChars)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            if (!isOnlyLettersAndDigits)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
            if (!haveAtLeastTwoDigits)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }

            if (isBetweenSixAndTenChars && 
                isOnlyLettersAndDigits && 
                haveAtLeastTwoDigits)
            {
                Console.WriteLine("Password is valid");
            }


        }

        private static bool DigitCountChecker(string inputPassowrd)
        {
            int counter = 0;
            for (int i = 0; i < inputPassowrd.Length; i++)
            {
                if (char.IsDigit(inputPassowrd[i]))
                {
                    counter++;
                }
            }
            if (counter >= 2)
            {
                return true;
            }
            return false;
        }

        private static bool StringCharsChecker(string inputPassowrd)
        {
            for (int i = 0; i < inputPassowrd.Length; i++)
            {
                if (!char.IsLetterOrDigit(inputPassowrd[i]))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool StringLenghtChecker(string inputPassowrd)
        {
            if (inputPassowrd.Length  >= 6 &&  inputPassowrd.Length <= 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}
