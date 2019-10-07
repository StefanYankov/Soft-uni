using System;

namespace _01.ActionPrint
{
    class ActionPrintProgram
    {
        static void Main()
        {
            Action<string[]> printNames = names => Console.WriteLine(string.Join(Environment.NewLine, names));
            string[] inputNames = Console.ReadLine().Split(' ');

            printNames(inputNames);
        }
    }
}
