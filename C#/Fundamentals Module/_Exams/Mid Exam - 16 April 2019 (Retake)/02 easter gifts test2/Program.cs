using System;
using System.Linq;

namespace _02_easter_gifts_test2
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine().Split().ToArray();
            string input = Console.ReadLine();

            
            while (input != "No Money")
            {
                var inputArray = input.Split().ToArray();

                if (inputArray[0] == "OutOfStock")
                {
                    while (array.Contains(inputArray[1]))
                    {
                        int index = Array.FindIndex(array, x => x.Contains(inputArray[1]));
                        array[index] = "None";
                    }

                }
                else if (inputArray[0] == "Required")
                {
                    int index = int.Parse(inputArray[2]);
                    if (index < array.Length && index > 0)
                    {
                        array[index] = inputArray[1];
                    }

                }
                else if (inputArray[0] == "JustInCase")
                {
                    int index = array.Length - 1;
                    array[index] = inputArray[1];

                }
                input = Console.ReadLine();

            }
            foreach (var item in array.Where(x => x!="None"))
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

        }
    }
}
