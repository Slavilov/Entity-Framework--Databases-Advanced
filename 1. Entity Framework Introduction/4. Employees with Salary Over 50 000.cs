//using System;
//using System.Text;
//using SoftUni.Models;
//
//namespace SoftUni
//{
//    public class StartUpExercise3
//    {
//        static void Main(string[] args)
//        {
//            var db = new SoftUniContext();
//            var result = GetEmployeesWithSalaryOver50000(db);
//            Console.WriteLine(result);
//        }
//
//        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
//        {
//            var employeeSalaries = context.Employees
//                .OrderBy(x => x.FirstName)
//                .Select(x => new
//                {
//                    x.FirstName,
//                    x.Salary
//                })
//                .Where(x => x.Salary > 50000)
//                .ToList();
//
//            var sb = new StringBuilder();
//
//            foreach (var employee in employeeSalaries)
//            {
//                sb.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
//            }
//            var result = sb.ToString().TrimEnd();
//
//            return result;
//        }
//    }
//}