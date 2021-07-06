using System;
using System.Linq;

namespace P02ArrayModifier
{
    public class StartUp
    {
        static void Main()
        {
            int[] inputArray = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string input;
            while (!((input = Console.ReadLine()).Equals("end")))
            {
                string command = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0];
                int firstIndex = 0;
                int secondIndex = 0;
                switch (command)
                {
                    case "swap":
                        firstIndex = int.Parse(input.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1]);
                        secondIndex = int.Parse(input.Split(' ', StringSplitOptions.RemoveEmptyEntries)[2]);
                        Swap(firstIndex, secondIndex, ref inputArray);
                        break;
                    case "multiply":
                        firstIndex = int.Parse(input.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1]);
                        secondIndex = int.Parse(input.Split(' ', StringSplitOptions.RemoveEmptyEntries)[2]);
                        Multiply(firstIndex, secondIndex, ref inputArray);
                        break;
                    case "decrease":
                        Decrease(ref inputArray);
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine(String.Join(", ", inputArray));
        }

        private static void Decrease(ref int[] inputArray)
        {
            for (int i = 0; i < inputArray.Length; i++)
            {
                inputArray[i] -= 1;
            }
        }

        private static void Multiply(int firstIndex, int secondIndex, ref int[] inputArray)
        {
            var multipliedElement = inputArray[firstIndex] * inputArray[secondIndex];
            inputArray[firstIndex] = multipliedElement;
        }

        private static void Swap(int x, int y, ref int[] array)
        {
            var buffer = array[x];
            array[x] = array[y];
            array[y] = buffer;
        }
    }
}
