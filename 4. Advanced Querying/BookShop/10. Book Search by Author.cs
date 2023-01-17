namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var context = new BookShopContext();

            //DbInitializer.ResetDatabase(context);
            //DbInitializer.Seed(context);

            string input = Console.ReadLine();
            var result = GetBooksByAuthor(context, input);
            Console.WriteLine(result);

        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var titlesOfBooks = context.Books
                .Where(x => x.Author.LastName.ToLower().StartsWith(input))
                .Select(x => new
                {
                    TitleName = x.Title,
                    AuthorName = x.Author.FirstName + " " + x.Author.LastName,
                    BookId = x.BookId
                })
                .OrderBy(x => x.BookId)
                .ToList();


            var sb = new StringBuilder();

            foreach (var book in titlesOfBooks)
            {
                sb.AppendLine($"{book.TitleName} ({book.AuthorName})");
            }

            return sb.ToString();
        }
    }
}