using System;
using System.Linq;

namespace _02._Easter_Gifts
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().ToList();
            string commands = Console.ReadLine();

            while (commands != "No Money")
            {
                var array = commands.Split().ToArray();
                string command = array[0];

                if (command == "OutOfStock")
                {
                    if (input.Contains(array[1]))
                    {
                        input.Remove(array[1]);
                    }

                }
                else if (command == "Required")
                {
                    int current = int.Parse(array[2]);
                    input.RemoveAt(current);
                    input[current] = array[1];

                }
                else if (command == "JustInCase")
                {
                    int lastIndex = input.Count()-1;
                    input[lastIndex] = array[1];

                }
                commands = Console.ReadLine();

            }

            for (int i = 0; i < input.Count; i++)
            {
                Console.WriteLine(input[i]);
            }
        }
    }
}
