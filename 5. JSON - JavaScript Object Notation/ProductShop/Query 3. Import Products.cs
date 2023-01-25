//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using Newtonsoft.Json;
//using ProductShop.Data;
//using ProductShop.Models;
//using AutoMapper;
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
//            string jsonString = File.ReadAllText(@"../../../Datasets/products.json");
//
//            var config = new MapperConfiguration(cfg =>
//            {
//                cfg.AddProfile<ProductShopProfile>();
//            });
//            mapper = config.CreateMapper();
//
//
//            var result = ImportProducts(db, jsonString);
//            Console.WriteLine(result);
//
//        }
//        public static string ImportProducts(ProductShopContext context, string inputJson)
//        {
//            var DTOproductsFromJson = JsonConvert.DeserializeObject<List<ProductsInputModel>>(inputJson);
//            var products = mapper.Map<List<Product>>(DTOproductsFromJson);
//
//            foreach (var product in products)
//            {
//                context.Products.Add(product);
//            }
//            context.SaveChanges();
//
//            string result = $"Successfully imported {context.Products.Count()}";
//
//            return result;
//        }
//    }
//}