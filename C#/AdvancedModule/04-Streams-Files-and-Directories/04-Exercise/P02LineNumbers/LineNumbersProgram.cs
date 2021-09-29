namespace P02LineNumbers
{
    using System.IO;
    using System.Linq;
    public class LineNumbersProgram
    {
        public static void Main()
        {
            string[] linesArray = File.ReadAllLines(@"files\text.txt"); // text.txt has "always copy"
            string[] outputArray = new string[linesArray.Length];
            for (int i = 0; i < linesArray.Length; i++)
            {
                int letterCount = linesArray[i].Count(char.IsLetter);
                int punctuationCount = linesArray[i].Count(char.IsPunctuation);
                outputArray[i] = $"Line {i + 1}: {linesArray[i]} ({letterCount})({punctuationCount})";
            }

            File.WriteAllLines("output.txt",outputArray); // output in bin - debug
        }
    }
}