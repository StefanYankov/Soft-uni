using System;

namespace _01._Smallest
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int lastNumber = int.Parse(Console.ReadLine());

            Console.WriteLine(NumbersComparison(firstNumber, secondNumber, lastNumber));

          
        }

        static int NumbersComparison(int firstNumber, int secondNumber, int thirdNumber)
        {
            if (firstNumber < secondNumber && firstNumber < thirdNumber)
            {
                return firstNumber;
            }
            else if (secondNumber < firstNumber && secondNumber < thirdNumber)
            {
                return secondNumber;
            }
            else
            {
                return thirdNumber;
            }
        }

    
    }
}
