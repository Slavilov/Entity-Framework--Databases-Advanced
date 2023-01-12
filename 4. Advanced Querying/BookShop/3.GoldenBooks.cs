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

            var result = GetGoldenBooks(context);
            Console.WriteLine(result);

        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldenBooksTitles = context.Books
                .Where(x => x.EditionType == EditionType.Gold && x.Copies < 5000)
                .Select(x => new
                {
                    BookId = x.BookId,
                    BookTitle = x.Title
                })
                .OrderBy(x => x.BookId)
                .ToList();

            var sb = new StringBuilder();
            
            foreach (var title in goldenBooksTitles)
            {
                sb.AppendLine(title.BookTitle);
            }
            
            return sb.ToString();
        }
    }
}
