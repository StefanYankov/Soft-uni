using System;
using System.Linq;

namespace P02TheLift
{
    public class StartUp
    {
        public const int WagonCapacity = 4;
        static void Main()
        {
            int waitingQueue = int.Parse(Console.ReadLine());
            int[] liftState = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            for (int i = 0; i < liftState.Length; i++)
            {
                while (liftState[i] < 4)
                {
                    liftState[i]++;
                    waitingQueue--;
                    if (waitingQueue == 0)
                    {
                        if (liftState.All(x => x == 4))
                        {
                            Console.WriteLine(String.Join(' ', liftState));
                            return;
                        }
                        Console.WriteLine("The lift has empty spots!");
                        Console.WriteLine(String.Join(' ', liftState));
                        return;
                    }
                }
            }

            if (waitingQueue > 0)
            {
                Console.WriteLine($"There isn't enough space! {waitingQueue} people in a queue!");
                Console.WriteLine(String.Join(' ', liftState));
            }

        }
    }
}
