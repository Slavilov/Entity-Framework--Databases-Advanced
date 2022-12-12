//using System;
//using System.Globalization;
//using System.Text;
//using SoftUni_Second_Attempt_DB.Models;
//
//namespace SoftUni
//{
//    public class StartUp
//    {
//        static void Main(string[] args)
//        {
//            var context = new SoftUniContext();
//            var result = GetAddressesByTown(context);
//            Console.WriteLine(result);
//        }
//        public static string GetAddressesByTown(SoftUniContext context)
//        {
//            var addresses = context.Addresses
//                .OrderByDescending(x => x.Employees.Count())
//                .ThenBy(x => x.Town.Name)
//                .ThenBy(x => x.AddressText)
//                .Select(x => new
//                {
//                    AddressText = x.AddressText,
//                    TownName = x.Town.Name,
//                    EmployeeCount = x.Employees.Count()
//                })
//                .Take(10)
//                .ToList();
//
//            var sb = new StringBuilder();
//
//            foreach (var address in addresses)
//            {
//                sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.EmployeeCount} employees");
//            }
//            var result = sb.ToString().TrimEnd();
//            return result;
//
//        }
//    }
//}