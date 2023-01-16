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
//            string input = Console.ReadLine();
//            var result = GetBookTitlesContaining(context, input);
//            Console.WriteLine(result);
//
//        }
//
//        public static string GetBookTitlesContaining(BookShopContext context, string input)
//        {
//            var titlesOfBooks = context.Books
//                .Where(x => x.Title.ToLower().Contains(input.ToLower()))
//                .Select(x => new
//                {
//                    TitleName = x.Title
//                })
//                .OrderBy(x => x.TitleName)
//                .ToList();
//
//
//            var sb = new StringBuilder();
//
//            foreach (var book in titlesOfBooks)
//            {
//                sb.AppendLine($"{book.TitleName}");
//            }
//
//            return sb.ToString();
//        }
//    }
//}