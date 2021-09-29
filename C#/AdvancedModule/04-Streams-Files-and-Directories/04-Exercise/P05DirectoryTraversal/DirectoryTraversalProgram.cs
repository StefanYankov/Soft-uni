namespace P05DirectoryTraversal
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System;
    public class DirectoryTraversalProgram
    {
        public static void Main()
        {
            string directoryToGenerateReportFor = "./";
            string[] files = Directory.GetFiles(directoryToGenerateReportFor);

            Dictionary<string, Dictionary<string, double>> directoryReport = new Dictionary<string, Dictionary<string, double>>();

            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);

                string fileExtension = fileInfo.Extension;
                string fileName = fileInfo.Name;
                long fileSize = fileInfo.Length;

                if (!directoryReport.ContainsKey(fileExtension))
                {
                    directoryReport.Add(fileExtension, new Dictionary<string, double>());
                }

                directoryReport[fileExtension].Add(fileName, fileSize);
            }

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            using StreamWriter writer = new StreamWriter($"{desktopPath}/report.txt");

            foreach (var file in directoryReport.OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key))
            {
                writer.WriteLine(file.Key);

                foreach (var kvp in file.Value.OrderBy(x => x.Value))
                {
                    writer.WriteLine($"--{kvp.Key} - {(kvp.Value / 1024):F3}kb");
                }
            }
        }
    }
}