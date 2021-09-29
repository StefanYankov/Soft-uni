namespace P02LineNumbers
{
    using System.IO;
    public class LineNumbersProgram
    {
        public static void Main()
        {
            using StreamReader sr = new StreamReader(@"..\..\..\Input.txt");
            using StreamWriter sw = new StreamWriter(@"..\..\..\Output.txt");
            int counter = 0;
            while (!sr.EndOfStream)
            {
                counter++;
                var line = sr.ReadLine();
                sw.WriteLine($"{counter}. {line}");
            }
        }
    }
}
