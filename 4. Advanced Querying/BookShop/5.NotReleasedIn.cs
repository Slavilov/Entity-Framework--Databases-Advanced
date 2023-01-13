namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var context = new BookShopContext();

            //DbInitializer.ResetDatabase(context);
            //DbInitializer.Seed(context);

            int year = int.Parse(Console.ReadLine());
            var result = GetBooksNotReleasedIn(context, year);
            Console.WriteLine(result);

        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var notReleasedBooks = context.Books
                .Where(x => x.ReleaseDate.HasValue && x.ReleaseDate.Value.Year != year)
                .Select(x => new
                {
                    Title = x.Title,
                    BookId = x.BookId
                })
                .OrderBy(x => x.BookId)
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in notReleasedBooks)
            {
                sb.AppendLine($"{book.Title}");
            }

            return sb.ToString();
        }
    }
}
