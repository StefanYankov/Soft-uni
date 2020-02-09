using System;
using System.Linq;

namespace _03Generic_SwapMethodStrings
{
    public class StartUp
    {
        public static void Main()
        {
            int counter = int.Parse(Console.ReadLine());

            Box<string> box = new Box<string>();

            for (int i = 0; i < counter; i++)
            {
                string input = Console.ReadLine();

                box.Values.Add(input);
            }

            int[] indexesArray = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int a = indexesArray[0];
            int b = indexesArray[1];

            box.Swap(a,b);

            Console.Write(box);
        }
    }
}
