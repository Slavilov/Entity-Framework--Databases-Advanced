using System;
using System.Text;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUpExercise4
    {
        static void Main(string[] args)
        {
            var dbContext = new SoftUniContext();
            var result = GetEmployeesFromResearchAndDevelopment(dbContext);
            Console.WriteLine(result);
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employeesFromRnD = context.Employees
                .OrderBy(x => x.Salary).ThenByDescending(x => x.FirstName)
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.Department,
                    x.Salary
                })
                .Where(x => x.Department.DepartmentId == 6)
                .ToList();

            var sb = new StringBuilder();

            foreach (var employee in employeesFromRnD)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.Department.Name} - ${employee.Salary:F2}");
            }
            var result = sb.ToString().TrimEnd();
            return result;
        }
    }
}
