//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using Newtonsoft.Json;
//using ProductShop.Data;
//using ProductShop.Models;
//using AutoMapper;
//
//
//namespace ProductShop
//{
//    public class StartUp
//    {
//        static IMapper mapper;
//
//        public static void Main(string[] args)
//        {
//            var db = new ProductShopContext();
//            db.Database.EnsureCreated();
//
//            var result = GetProductsInRange(db);
//            Console.WriteLine(result);
//
//        }
//        public static string GetProductsInRange(ProductShopContext context)
//        {
//            var products = context.Products
//                .Where(x => x.Price >= 500 && x.Price <= 1000)
//                .Select(x => new
//                {
//                    ProductName = x.Name,
//                    Price = x.Price,
//                    SellerFullName = x.Seller.FirstName + " " + x.Seller.LastName
//                })
//                .OrderBy(x => x.Price)
//                .ToList();
//
//            string json = JsonConvert.SerializeObject(products, Formatting.Indented);
//
//            return json;
//        }
//    }
//}
