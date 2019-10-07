using System;

namespace _3._Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            int startIndexOfFile = path.LastIndexOf('\\') + 1;
            string file = path.Substring(startIndexOfFile);

            int startIndexOfExtension = file.LastIndexOf('.') + 1;
            string onlyFileName = file.Substring(0, startIndexOfExtension - 1);
            string extensionName = file.Substring(startIndexOfExtension);

            Console.WriteLine($"File name: {onlyFileName}");
            Console.WriteLine($"File extension: {extensionName}");

        }
    }
}
