using System;

namespace _1._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfWagons = int.Parse(Console.ReadLine());
            var wagonsArr = new int[countOfWagons];
            int sum = 0;

            for (int i = 0; i < wagonsArr.Length; i++)
            {
                wagonsArr[i] = int.Parse(Console.ReadLine());
                sum += wagonsArr[i];
            }

            string result = string.Join(" ", wagonsArr);
            Console.WriteLine(result);
            Console.WriteLine(sum);

        }
    }
}
