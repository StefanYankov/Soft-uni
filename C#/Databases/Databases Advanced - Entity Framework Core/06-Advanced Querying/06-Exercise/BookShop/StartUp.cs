using System;
using System.Globalization;
using System.Linq;
using System.Text;
using BookShop.Models.Enums;

namespace BookShop
{
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            // DbInitializer.ResetDatabase(db);

            // Problem #02
            // Console.WriteLine(GetBooksByAgeRestriction(db, "miNor"));
            // Problem #03
            // Console.WriteLine(GetGoldenBooks(db));
            // Problem #04
            // Console.WriteLine(GetBooksByPrice(db));
            // Problem #05
            // Console.WriteLine(GetBooksNotReleasedIn(db,2000));
            // Console.WriteLine(GetBooksNotReleasedIn(db, 1998));
            // Problem #06
            // Console.WriteLine(GetBooksByCategory(db,"horror mystery drama"));
            // Problem #07
            // Console.WriteLine(GetBooksReleasedBefore(db, "12-04-1992"));
            // Console.WriteLine(GetBooksReleasedBefore(db, "30-12-1989"));
            // Problem #08 Author Search
            // Console.WriteLine(GetAuthorNamesEndingIn(db, "e"));
            // Console.WriteLine(GetAuthorNamesEndingIn(db,"dy"));
            // Console.WriteLine(GetAuthorNamesEndingIn(db));
            // Problem #09. Book Search
            // Console.WriteLine(GetBookTitlesContaining(db,"sK"));
            // Problem #10. Book Search by Author
            // Console.WriteLine(GetBooksByAuthor(db));
            // Problem #11. Count Books
            // Console.WriteLine(CountBooks(db, 40));
            // Problem #12. Total Book Copies
            // Console.WriteLine(CountCopiesByAuthor(db));
            // Problem #13. Profit by Category
            Console.WriteLine(GetTotalProfitByCategory(db));
        }



        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {

            var ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            var books = context
                .Books
                .Where(x => x.AgeRestriction == ageRestriction)
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToArray();

            var output = string.Join(Environment.NewLine, books);

            return output;
        }
        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldEditionsParsed = Enum.Parse<EditionType>("Gold");

            var books = context
                .Books
                .Where(x => x.EditionType == goldEditionsParsed)
                .Where(x => x.Copies < 5000)
                .OrderBy(x => x.BookId)
                .Select(x => x.Title)
                .ToArray();

            var output = string.Join(Environment.NewLine, books);

            return output;
        }
        public static string GetBooksByPrice(BookShopContext context)
        {
            decimal targetPrice = 40M;
            StringBuilder sb = new StringBuilder();

            var books = context
                .Books
                .Where(x => x.Price > targetPrice)
                .OrderByDescending(x => x.Price)
                .Select(x => new
                {
                    Name = x.Title,
                    Price = x.Price,
                })
                .ToArray();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Name} - ${book.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {

            var books = context
                .Books
                .Where(x => x.ReleaseDate.Value.Year != year)
                .OrderBy(x => x.BookId)
                .Select(x => x.Title)
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }
        public static string GetBooksByCategory(BookShopContext context, string input = null)
        {
            if (input == null)
            {
                input = Console.ReadLine();
            }
            var categories= input.Split(new [] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var books = context
                .Books
                .Where(b => b.BookCategories.Any(c => categories.Contains(c.Category.Name.ToLower())))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime parsedDate = DateTime.Parse(date, new CultureInfo("bg-BG"));
            //      DateTime parsedDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            StringBuilder sb = new StringBuilder();
            var books = context
                .Books
                .Where(x => x.ReleaseDate.Value < parsedDate)
                .OrderByDescending(x => x.ReleaseDate)
                .Select(x => new
                {
                    Name = x.Title,
                    Edition = x.EditionType,
                    Price = x.Price,
                })
                .ToArray();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Name} - {book.Edition} - ${book.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input = null)
        {
            if (input == null)
            {
                input = Console.ReadLine();
            }

            var authorNames = context
                .Authors
                .ToArray()
                .Where(a => a.FirstName.ToLower().EndsWith(input.ToLower()))
                .Select(a => $"{a.FirstName} {a.LastName}")
                .OrderBy(x => x)
                .ToArray();

            return string.Join(Environment.NewLine, authorNames);

        }

        public static string GetBookTitlesContaining(BookShopContext context, string input = null)
        {
            if (input == null)
            {
                input = Console.ReadLine();
            }

            var books = context
                .Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(x => x.Title)
                .OrderBy( x => x)
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksByAuthor(BookShopContext context, string input = null)
        {
            if (input == null)
            {
                input = Console.ReadLine();
            }

            StringBuilder sb = new StringBuilder();

            var books = context
                .Books
                .Where(x => x.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(x => x.BookId)
                .Select(x => new
                {
                    Name = $"{x.Author.FirstName} {x.Author.LastName}",
                    x.Title,
                })
                .ToArray();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} ({book.Name})");
            }

            return sb.ToString().TrimEnd();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context
                .Books
                .Count(x => x.Title.Length > lengthCheck);
            return books;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            var authors = context
                .Authors
                .Select(a => new
                {
                    Name = $"{a.FirstName} {a.LastName}",
                    Count = a.Books.Select( x => x.Copies).Sum(),
                })
                .OrderByDescending(x => x.Count)

                .ToArray();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.Name} - {author.Count}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            /*StringBuilder sb = new StringBuilder();
            var profitByCategory = context
                .Books
                .Select(x => new
                {
                    Price = x.Price * x.Copies,
                    Profit = 
                })

            foreach (var author in profitByCategory)
            {
                sb.AppendLine($"{author.Name} - {author.Count}");
            }

            return sb.ToString().TrimEnd();*/
            var profitByCategory = context
                .Books
                .Where(n => n.Price % 2 == 0).OrderBy(n => n);
            return null;
        }

    }
}
