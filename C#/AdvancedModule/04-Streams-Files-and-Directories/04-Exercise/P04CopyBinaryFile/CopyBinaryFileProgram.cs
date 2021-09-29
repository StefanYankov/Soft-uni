namespace P04CopyBinaryFile
{
    using System.IO;
    public class CopyBinaryFileProgram
    {
        public static void Main()
        {
            using FileStream fileReader = new FileStream(@"files\copyMe.png", FileMode.Open);
            using FileStream fileWriter = new FileStream(@"copyMeCopy.png", FileMode.Create);

            byte[] buffer = new byte[256];
            while (true)
            {
                int currentBytes = fileReader.Read(buffer, 0, buffer.Length);

                if (currentBytes == 0)
                {
                    break;
                }

                fileWriter.Write(buffer,0,buffer.Length);
            }
        }
    }
}