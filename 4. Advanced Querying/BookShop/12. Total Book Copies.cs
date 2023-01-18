//namespace BookShop
//{
//    using BookShop.Models.Enums;
//    using Data;
//    using Initializer;
//    using System;
//    using System.Globalization;
//    using System.Linq;
//    using System.Text;
//
//    public class StartUp
//    {
//        public static void Main()
//        {
//            using var context = new BookShopContext();
//
//            //DbInitializer.ResetDatabase(context);
//            //DbInitializer.Seed(context);
//
//            var result = CountCopiesByAuthor(context);
//            Console.WriteLine(result);
//
//        }
//
//        public static string CountCopiesByAuthor(BookShopContext context)
//        {
//            var authorQuantityOfBooks = context.Authors
//                .Select(x => new
//                {
//                    AuthorName = x.FirstName + " " + x.LastName,
//                    CountOfBooks = x.Books.Sum(x=>x.Copies)
//                })
//                .OrderByDescending(x => x.CountOfBooks)
//                .ToList();
//
//            var sb = new StringBuilder();
//
//            foreach (var author in authorQuantityOfBooks)
//            {
//                sb.AppendLine($"{author.AuthorName} - {author.CountOfBooks}");
//            }
//
//            return sb.ToString();
//        }
//    }
//}