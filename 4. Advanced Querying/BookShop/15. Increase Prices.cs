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
        
        public static void IncreasePrices(BookShopContext dbContext)
        {
            Book[] books = dbContext
                .Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToArray();

            foreach (Book book in books)
            {
                book.Price += 5;
            }

            dbContext.SaveChanges();
        }
    }
}
