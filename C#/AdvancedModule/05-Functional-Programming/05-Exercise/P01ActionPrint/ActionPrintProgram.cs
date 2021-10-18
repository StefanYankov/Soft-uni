namespace P01ActionPrint
{
    using System;
    public class ActionPrintProgram
    {
        public static void Main()
        {
            Action<string[]> printNames = names => Console.WriteLine(string.Join(Environment.NewLine, names));
            string[] inputNames = Console.ReadLine().Split(' ');

            printNames(inputNames);
        }
    }
}
