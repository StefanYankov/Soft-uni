namespace P07AppendArrays
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main()
        {
            List<string> arrayList = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries).Reverse().ToList();
            string temp = String.Join(" ", arrayList);
            Console.WriteLine(string.Join(" ", temp.Split(" ", StringSplitOptions.RemoveEmptyEntries)));
        }
    }
}
