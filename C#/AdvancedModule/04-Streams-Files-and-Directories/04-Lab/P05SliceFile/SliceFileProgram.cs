namespace P05SliceFile
{
    using System.IO;
    public class SliceFileProgram
    {
        public static void Main()
        {
            using FileStream fileStream = new FileStream(@"..\..\..\sliceMe.txt", FileMode.OpenOrCreate);
            var data = new byte[fileStream.Length];
            var bytesPerFile = fileStream.Length / 4;
            for (int i = 1; i <= 4; i++)
            {
                var buffer = new byte[bytesPerFile];
                fileStream.Read(buffer);
                using FileStream writer = new FileStream($"..\\..\\..\\Part-{i}.txt", FileMode.OpenOrCreate);
                writer.Write(buffer);
            }
        }
    }
}
