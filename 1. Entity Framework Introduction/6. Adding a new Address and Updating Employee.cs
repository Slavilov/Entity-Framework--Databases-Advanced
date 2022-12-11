using System;
using System.Text;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUpExercise5
    {
        static void Main(string[] args)
        {
            var db = new SoftUniContext();
            var result = AddNewAddressToEmployee(db);
            Console.WriteLine(result);

        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var adress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };
            context.Addresses.Add(adress);
            context.SaveChanges();
        
            var nakov = context.Employees
                .FirstOrDefault(x => x.LastName == "Nakov");
        
            nakov.AddressId = adress.AddressId;
            context.SaveChanges();
        
            var employees = context.Employees
                .OrderByDescending(x => x.AddressId)
                .Take(10);
        
            var sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.Address.AddressText}");
            }
            var result = sb.ToString().TrimEnd();
            return result;
        }
    }
}