namespace P04EvenTimes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class EvenTimesProgram
    {
        public static void Main()
        {
            int integerCount = int.Parse(Console.ReadLine());
            Dictionary<int, int> countOfEvenTimes = new Dictionary<int, int>();
            for (int i = 0; i < integerCount; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                if (!countOfEvenTimes.ContainsKey(currentNumber))
                {
                    countOfEvenTimes.Add(currentNumber, 0);
                }

                countOfEvenTimes[currentNumber]++;
            }

            int evenTimesNumber = countOfEvenTimes
                .SingleOrDefault(number => number.Value % 2 == 0)
                .Key;

            Console.WriteLine(evenTimesNumber);
        }
    }
}
