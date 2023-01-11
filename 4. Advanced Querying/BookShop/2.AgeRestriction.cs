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
//            using var db = new BookShopContext();
//            db.Database.EnsureCreated();
//            string command = Console.ReadLine();
//
//            var result = GetBooksByAgeRestriction(db, command);
//            Console.WriteLine(result);
//
//            //DbInitializer.ResetDatabase(db);
//        }
//
//        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
//        {
//            command.ToLower();
//            var ageRestriction = Enum.Parse<AgeRestriction>(command, true);
//
//            var bookTitles = context.Books
//                .Where(x => x.AgeRestriction == ageRestriction)
//                .Select(x => new
//                {
//                    BookTitle = x.Title
//                })
//                .OrderBy(x => x.BookTitle)
//                .ToList();
//
//            var sb = new StringBuilder();
//
//            foreach (var title in bookTitles)
//            {
//                sb.AppendLine(title.BookTitle);
//            }
//
//            return sb.ToString();
//        }
//    }
//}