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
//            string jsonString = File.ReadAllText(@"../../../Datasets/categories.json");
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
//        static string ImportProducts(ProductShopContext context, string inputJson)
//        {
//            var DTOcategoriesFromJson = JsonConvert.DeserializeObject<List<CategoryInputModel>>(inputJson);
//            var categories = mapper.Map<List<Category>>(DTOcategoriesFromJson);
//
//            foreach (var category in categories)
//            {
//                if (category.Name == null)
//                {
//                    continue;
//                }
//                context.Categories.Add(category);
//            }
//            context.SaveChanges();
//
//            string result = $"Successfully imported {context.Categories.Count()}";
//
//            return result;
//        }
//    }
//}