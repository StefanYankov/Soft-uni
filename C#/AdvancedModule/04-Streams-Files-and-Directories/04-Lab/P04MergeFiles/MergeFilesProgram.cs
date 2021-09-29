namespace P04MergeFiles
{
    using System.IO;
    public class MergeFilesProgram
    {
        public static void Main()
        {
            using StreamReader firstReader = new StreamReader(@"..\..\..\FileOne.txt");
            using StreamReader secondReader = new StreamReader(@"..\..\..\FileTwo.txt");
            using StreamWriter writer = new StreamWriter(@"..\..\..\Output.txt");
            string lineFirstInput = firstReader.ReadLine();
            string lineSecondInput = secondReader.ReadLine();

            while (lineFirstInput != null || lineSecondInput != null)
            {
                writer.WriteLine(lineFirstInput);
                writer.WriteLine(lineSecondInput);

                lineFirstInput = firstReader.ReadLine();
                lineSecondInput = secondReader.ReadLine();
            }
        }
    }
}