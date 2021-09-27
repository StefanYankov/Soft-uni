namespace P02SetsOfElements
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class SetsOfElementsProgram
    {
        public static void Main()
        {
           int[] setsLength = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            HashSet<int> primarySet = new HashSet<int>();
            HashSet<int> secondarySet = new HashSet<int>();
            HashSet<int> outputSet = new HashSet<int>();
            for (int i = 0; i < setsLength[0]; i++)
            {
                int number = int.Parse(Console.ReadLine());
                primarySet.Add(number);
            }
            for (int i = 0; i < setsLength[1]; i++)
            {
                int number = int.Parse(Console.ReadLine());
                secondarySet.Add(number);
            }

            foreach (var number in primarySet)
            {
                if (secondarySet.Contains(number))
                {
                    outputSet.Add(number);
                }

            }
            Console.WriteLine(string.Join(' ', outputSet));
        }
    }
}
