namespace P05BombNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<int> bombNumbersList = Console.ReadLine().Split().Select(int.Parse).ToList();
            int[] bombArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int bombNumber = bombArray[0];
            int bombPower = bombArray[1];

            while (bombNumbersList.Contains(bombNumber))
            {
                int bombIndex = bombNumbersList.IndexOf(bombNumber);
                int leftIndex = Math.Max(bombIndex - bombPower, 0);
                int rightIndex = Math.Min(bombIndex + bombPower, bombNumbersList.Count - 1);
                int count = 1 + rightIndex - leftIndex;

                bombNumbersList.RemoveRange(leftIndex, count);
            }
            Console.WriteLine(bombNumbersList.Sum());
        }
    }
}
