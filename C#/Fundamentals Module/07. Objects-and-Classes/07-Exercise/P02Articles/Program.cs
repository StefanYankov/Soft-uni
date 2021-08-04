namespace P02Articles
{
    using System;

    public class Program
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split(", ");
            Article myArticle = new Article(input[0], input[1], input[2]);
            int numberOfCommands = int.Parse(Console.ReadLine());

            string commands = string.Empty;

            for (int i = 1; i <= numberOfCommands; i++)
            {
                commands = Console.ReadLine();
                string command = commands.Split(": ")[0];
                string content = commands.Split(": ")[1].Trim();



                switch (command)
                {
                    case "Edit":
                        myArticle.Edit(content);
                        break;
                    case "ChangeAuthor":
                        myArticle.ChangeAuthor(content);
                        break;
                    case "Rename":
                        myArticle.Rename(content);
                        break;
                }
            }
            Console.WriteLine(myArticle.ToString());
        }
    }

    public class Article
    {
        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }

        public string Title { get; private set; }
        public string Content { get; private set; }
        public string Author { get; private set; }

        public void Edit (string content)
        {
            this.Content = content;
        }

        public void ChangeAuthor (string author)
        {
            this.Author = author;
        }

        public void Rename (string title)
        {
            this.Title = title;
        }

        public override string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }
    }
}
