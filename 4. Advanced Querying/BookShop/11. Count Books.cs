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

            int lengthCheck = int.Parse(Console.ReadLine());
            var count = CountBooks(context, lengthCheck);

            Console.WriteLine($"There are {count} books with longer title than {lengthCheck} symbols");
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var count = context.Books
                .Where(x=>x.Title.Length > lengthCheck)
                .Count();

            return count;
        }
    }
}
