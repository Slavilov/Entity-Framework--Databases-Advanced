//namespace BookShop
//{
//    using BookShop.Models.Enums;
//    using Data;
//    using Initializer;
//    using System;
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
//            string inputCategories = Console.ReadLine();
//            var result = GetBooksByCategory(context, inputCategories);
//            Console.WriteLine(result);
//
//        }
//
//        public static string GetBooksByCategory(BookShopContext context, string inputCategories)
//        {
//            string[] Categories = inputCategories
//                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
//                .ToArray();
//
//            var titleOfBooks = context.Books
//                .Where(book => book.BookCategories
//                   .Any(category => Categories.Contains
//                   (category.Category.Name)))
//                .Select(x=> new
//                {
//                    Title = x.Title
//                })
//                .OrderBy(x => x.Title)
//                .ToList();
//
//            var sb = new StringBuilder();
//
//            foreach (var book in titleOfBooks)
//            {
//                sb.AppendLine($"A {book.Title}");
//            }
//
//            return sb.ToString();
//        }
//    }
//}