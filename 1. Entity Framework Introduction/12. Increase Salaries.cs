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
//            var db = new SoftUniContext();
//            var result = IncreaseSalaries(db);
//            Console.WriteLine(result);
//
//        }
//        public static string IncreaseSalaries(SoftUniContext context)
//        {
//            var employeesToIncrease = context
//                .Employees
//                .Where(x => x.DepartmentId == 1 ||
//                x.DepartmentId == 2 ||
//                x.DepartmentId == 4 ||
//                x.DepartmentId == 11)
//                .ToList();
//
//            foreach (var employee in employeesToIncrease)
//            {
//                employee.Salary += (employee.Salary * 0.12m);
//            }
//            context.SaveChanges();
//
//            var sb = new StringBuilder();
//
//            foreach (var employee in employeesToIncrease)
//            {
//                sb.AppendLine($"{employee.FirstName} {employee.LastName} ({employee.Salary:f2})");
//            }
//
//            var result = sb.ToString().TrimEnd();
//            return result;
//        }
//    }
//}