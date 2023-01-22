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

            var result = GetMostRecentBooks(context);
            Console.WriteLine(result);

        }

        static string GetMostRecentBooks(BookShopContext context)
        {

            var top3RecentBooksByCategory = context.Categories
                .Select(x => new
                {
                    CategoryName = x.Name,
                    Top3Books = x.CategoryBooks
                    .OrderByDescending(x => x.Book.ReleaseDate)
                    .Select(x => x.Book).Take(3)
                })
                .OrderBy(x => x.CategoryName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var category in top3RecentBooksByCategory)
            {
                sb.AppendLine($"--{category.CategoryName}");

                foreach (var book in category.Top3Books)
                {
                    sb.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
                sb.AppendLine($" ");
            }

            return sb.ToString();
        }
    }
}