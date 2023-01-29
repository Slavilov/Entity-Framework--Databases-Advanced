using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;
using AutoMapper;


namespace ProductShop
{
    public class StartUp
    {
        static IMapper mapper;

        public static void Main(string[] args)
        {
            var db = new ProductShopContext();
            db.Database.EnsureCreated();

            var result = GetUsersWithProducts(db);
            Console.WriteLine(result);

        }
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var products = context.Users
                .Where(x => x.ProductsSold.Count >= 0)
                .Select(x => new
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    Products = x.ProductsSold.Select(x => new
                    {
                        NameOfProduct = x.Name,
                        PriceOfProduct = x.Price
                    })
                })
                .OrderByDescending(x => x.Products.Count())
                .ToList();

            string json = JsonConvert.SerializeObject(products, Formatting.Indented);

            return json;
        }
    }
}
