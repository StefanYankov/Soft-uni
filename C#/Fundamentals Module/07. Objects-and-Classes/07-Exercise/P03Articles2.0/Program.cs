namespace P03Articles2._0
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int numberOfArticles = int.Parse(Console.ReadLine());
            List<Article> articleList = new List<Article>();

            string articleInfo = string.Empty;

            for (int i = 1; i <= numberOfArticles; i++)
            {
                articleInfo = Console.ReadLine();
                string title = articleInfo.Split(", ")[0];
                string content = articleInfo.Split(", ")[1].Trim();
                string author = articleInfo.Split(", ")[2].Trim();

                Article tempArticle = new Article(title, content, author);
                articleList.Add(tempArticle);
            }

            string criteria = Console.ReadLine();

            switch (criteria)
            {
                case "title":
                    foreach (var article in articleList.OrderBy(t => t.Title))
                    {
                        Console.WriteLine(article.ToString());
                    }
                    break;
                case "content":
                    foreach (var article in articleList.OrderBy(t => t.Content))
                    {
                        Console.WriteLine(article.ToString());
                    }
                    break;
                case "author":
                    foreach (var article in articleList.OrderBy(t => t.Author))
                    {
                        Console.WriteLine(article.ToString());
                    }
                    break;
            }



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

        public override string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }
    }
}
