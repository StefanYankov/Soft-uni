namespace P06Supermarket
{
    using System;
    using System.Collections.Generic;
    public class SupermarketProgram
    {
        public static void Main()
        {
            Queue<string> queue = new Queue<string>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input.Equals("End"))
                {
                    break;
                }

                if (input.Equals("Paid"))
                {
                    Console.WriteLine(String.Join(Environment.NewLine,queue));
                    queue.Clear();
                    continue;
                }

                queue.Enqueue(input);
            }

            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}
