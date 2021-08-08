using System.Linq;

namespace P03ExtractFile
{
    using System;
    public class Program
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split('\\').ToArray();
            string[] fullFile = input[input.Length - 1].Split('.');


            Console.WriteLine($"File name: {fullFile[0]}");
            Console.WriteLine($"File extension: {fullFile[1]}");
        }
    }
}
