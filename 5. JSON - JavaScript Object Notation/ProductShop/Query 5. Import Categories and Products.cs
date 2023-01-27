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
//            string jsonString = File.ReadAllText(@"../../../Datasets/categories-products.json");
//
//            var config = new MapperConfiguration(cfg =>
//            {
//                cfg.AddProfile<ProductShopProfile>();
//            });
//            mapper = config.CreateMapper();
//
//
//            var result = ImportCategoryProducts(db, jsonString);
//            Console.WriteLine(result);
//
//        }
//        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
//        {
//            List<CategoryProductInputModel> DTOcategoriesProductsFromJson = JsonConvert.DeserializeObject<List<CategoryProductInputModel>>(inputJson);
//            List<CategoryProduct> categoriesProducts = mapper.Map<List<CategoryProduct>>(DTOcategoriesProductsFromJson);
//
//
//            foreach (var categoryproduct in categoriesProducts)
//            {
//                context.CategoryProducts.Add(categoryproduct);
//            }
//            context.SaveChanges();
//
//            string result = $"Successfully imported {context.CategoryProducts.Count()}";
//
//            return result;
//        }
//    }
//}