using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._ExcelFunctions
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string[][] table = new string[n][];

            for (int i = 0; i < n; i++)
            {
                string[] rowValues = Console.ReadLine()
                    .Split(", ");

                table[i] = rowValues;
            }
            string[] commandArgs = Console.ReadLine()
                .Split();

            string command = commandArgs[0];
            string header = commandArgs[1];


            int headerIndex = Array.IndexOf(table[0], header);

            if (command == "hide")
            {

                for (int row = 0; row < table.Length; row++)
                {
                    List<string> lineToPrint = new List<string>(table[row]);

                    lineToPrint.RemoveAt(headerIndex);
                    Console.WriteLine(string.Join(" | ", lineToPrint));

                    table[row] = lineToPrint.ToArray();
                }
            }
            else if (command == "sort")
            {
                string[] headerRow = table[0];

                Console.WriteLine(string.Join(" | ", headerRow));

                table = table.OrderBy(x => x[headerIndex]).ToArray();

                foreach (var row in table)
                {
                    if (row != headerRow)
                    {
                        Console.WriteLine(string.Join(" | ", row));
                    }
                }
            }
            else if (command == "filter")
            {
                string parameter = commandArgs[2];
                string[] headerRow = table[0];

                Console.WriteLine(string.Join(" | ", headerRow));

                for (int i = 0; i < table.Length; i++)
                {
                    if (table[i][headerIndex] == parameter)
                    {
                        Console.WriteLine(string.Join(" | ", table[i]));
                    }
                }
            }
        }
    }
}