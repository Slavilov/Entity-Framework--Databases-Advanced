using System;
using System.Text;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUpExercise2
    {
        static void Main(string[] args)
        {
            var dbContext = new SoftUniContext();
            var result = GetEmployeesFullInformation(dbContext);
            Console.WriteLine(result);
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees
                .OrderBy(x => x.EmployeeId)
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.MiddleName,
                    x.JobTitle,
                    x.Salary
                })
                .ToList();
            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
            }
            var result = sb.ToString().TrimEnd();
            return result;
        }
    }
}
