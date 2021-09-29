namespace P06FolderSize
{
    using System.IO;
    public class FolderSizeProgram
    {
        public static void Main()
        {
            string directoryPath = @"..\..\..\TestFolder";
            string[] files = Directory.GetFiles(directoryPath);
            double size = 0;

            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                size += fileInfo.Length;
            }
            size = size / 1024 / 1024; // convert size to Megabytes

            File.WriteAllText(@"..\..\..\Output.txt", size.ToString());
        }
    }
}
