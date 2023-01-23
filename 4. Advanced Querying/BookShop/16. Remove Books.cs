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

        public static int RemoveBooks(BookShopContext dbContext)
        {
            Book[] books = dbContext
                .Books
                .Where(b => b.Copies < 4200)
                .ToArray();

            dbContext.Books.RemoveRange(books);
            dbContext.SaveChanges();

            return books.Length;
        }
    }
}
