namespace P06CardsGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main()
        {
            List<int> firstPlayerHand = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondPlayerHand = Console.ReadLine().Split().Select(int.Parse).ToList();
            int initialCount = firstPlayerHand.Count;

            while (true)
            {
                if (firstPlayerHand[0] > secondPlayerHand[0])
                {
                    firstPlayerHand.Add(firstPlayerHand[0]);
                    firstPlayerHand.Add(secondPlayerHand[0]);
                }
                else if (firstPlayerHand[0] < secondPlayerHand[0])
                {
                    secondPlayerHand.Add(secondPlayerHand[0]);
                    secondPlayerHand.Add(firstPlayerHand[0]);
                }

                firstPlayerHand.RemoveAt(0);
                secondPlayerHand.RemoveAt(0);

                if (firstPlayerHand.Count == 0)
                {
                    int sum = secondPlayerHand.Sum();
                    Console.WriteLine($"Second player wins! Sum: {sum}");
                    break;
                }
                else if (secondPlayerHand.Count == 0)
                {
                    int sum = firstPlayerHand.Sum();
                    Console.WriteLine($"First player wins! Sum: {sum}");
                    break;
                }
            }
        }
    }
}
