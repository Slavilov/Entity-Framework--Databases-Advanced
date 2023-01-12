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

            DbInitializer.ResetDatabase(context);
            DbInitializer.Seed(context);

            var result = GetBooksByPrice(context);
            Console.WriteLine(result);

        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var titlesAndPricesOfBooks = context.Books
                .Where(x => x.Price > 40)
                .Select(x => new
                {
                    Title = x.Title,
                    Price = x.Price
                })
                .OrderByDescending(x => x.Price)
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in titlesAndPricesOfBooks)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:F2}");
            }

            return sb.ToString();
        }
    }
}
