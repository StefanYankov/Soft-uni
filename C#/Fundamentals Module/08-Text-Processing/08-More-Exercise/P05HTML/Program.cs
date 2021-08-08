using System.Text;

namespace P05HTML
{
    using System;
    public class Program
    {
        public static void Main()
        {
            string articleTitle = Console.ReadLine();
            string contentOfArticle = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<h1>");
            sb.AppendLine($"\t{articleTitle}");
            sb.AppendLine("</h1>");
            sb.AppendLine("<article>");
            sb.AppendLine($"\t{contentOfArticle}");
            sb.AppendLine("</article>");

            string input = string.Empty;

            while (!(input = Console.ReadLine()).Equals("end of comments"))
            {
                sb.AppendLine("<div>");
                sb.AppendLine($"\t{input}");
                sb.AppendLine("</div>");

            }

            Console.WriteLine(sb.ToString());
        }
    }
}
