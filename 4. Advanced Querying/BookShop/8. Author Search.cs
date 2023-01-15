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
            var result = GetAuthorNamesEndingIn(context, input);
            Console.WriteLine(result);

        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(x => x.FirstName.EndsWith(input))
                .Select(x => new
                {
                    FullName = x.FirstName + " " + x.LastName
                })
                .OrderBy(x => x.FullName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in authors)
            {
                sb.AppendLine($"{book.FullName}");
            }

            return sb.ToString();
        }
    }
}
