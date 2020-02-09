using System;

namespace _05Generic_CountMethodStrings
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

            string targetItem = Console.ReadLine();

           int result = box.GreaterValuesThan(targetItem);

           Console.WriteLine(result);
        }
    }
}
