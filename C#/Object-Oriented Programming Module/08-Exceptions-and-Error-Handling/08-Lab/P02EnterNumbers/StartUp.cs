using System;

namespace P02EnterNumbers
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int startRange = 1;
            int endRange = 100;
            int[] array = new int[10];


            for (int i = 0; i < array.Length; i++)
            {

                try
                {
                    array[i] = ReadNumber(startRange, endRange);


                    if (array[i] <= startRange || array[i] > endRange)
                    {
                        throw new ArgumentOutOfRangeException(
                            $"Number must be bigger than {startRange} and smaller than {endRange}!");
                    }
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                    i--;
                    continue;
                }
                catch (ArgumentOutOfRangeException aoore)
                {
                    Console.WriteLine(aoore.Message);
                    i--;
                    continue;
                }


                startRange = array[i];
            }

            Console.Write($"Your numbers are: {String.Join(", ", array)}");

        }
        public static int ReadNumber(int start, int end)
        {
            string input = Console.ReadLine();
            int num;
            while (!int.TryParse(input, out num))
            {
                throw new FormatException("Please enter a valid number");
            }


            return num;
        }

    }
}