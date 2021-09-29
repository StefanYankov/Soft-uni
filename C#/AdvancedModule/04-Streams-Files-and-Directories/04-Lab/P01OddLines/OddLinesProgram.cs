namespace P01OddLines
{
    using System.IO;
    public class OddLinesProgram
    {
        public static void Main()
        {
            using StreamReader sr = new StreamReader(@"..\..\..\Input.txt");
            using StreamWriter sw = new StreamWriter(@"..\..\..\Output.txt");
            int rowNumber = 0;

            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                if (rowNumber % 2 == 1)
                {
                    sw.WriteLine(line);
                }

                rowNumber++;
            }
        }
    }
}
