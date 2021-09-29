namespace P06ZipAndExtract
{
    using System.IO.Compression;
    public class ZipAndExtractProgram
    {
        public static void Main()
        {
            string sourceDirectory = @"files"; // copyMe.png file has always copy
            string zipPath = @"result.zip";
            string extractPath = @"extract";

            ZipFile.CreateFromDirectory(sourceDirectory, zipPath, CompressionLevel.Fastest, true);
            ZipFile.ExtractToDirectory(zipPath, extractPath);
        }
    }
}