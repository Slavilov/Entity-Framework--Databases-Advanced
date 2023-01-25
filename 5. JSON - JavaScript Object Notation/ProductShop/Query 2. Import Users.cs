using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new ProductShopContext();
            db.Database.EnsureCreated();

            string jsonString = File.ReadAllText(@"../../../Datasets/users.json");

            var result = ImportUsers(db, jsonString);
            Console.WriteLine(result);

        }
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var usersFromJson = JsonConvert.DeserializeObject<List<User>>(inputJson);

            foreach (var user in usersFromJson)
            {
                context.Users.Add(user);
            }
            context.SaveChanges();

            string result = $"Successfully imported {usersFromJson.Count}";

            return result;
        }
    }
}
