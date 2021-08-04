namespace P06TriplesOfLatinLetters
{
    using System;
    public class Program
    {
        public static void Main()
        {
            int input = int.Parse(Console.ReadLine());

            for (int i = 0; i < input; i++)
            {
                for (int j = 0; j < input; j++)
                {
                    for (int k = 0; k < input; k++)
                    {
                        Console.WriteLine($"{(char)(i + 'a')}{(char)(j + 'a')}{(char)(k + 'a')}");
                    }
                }
            }
        }
    }
}
