using System;
using System.Globalization;
using System.Text;
using SoftUni_Second_Attempt_DB.Models;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var context = new SoftUniContext();
            var result = GetEmployee147(context);
            Console.WriteLine(result);
        }
        public static string GetEmployee147(SoftUniContext context)
        {
            var employee147 = context.Employees
                .Where(x => x.EmployeeId == 147)
                .Select(x => new
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    JobTitle = x.JobTitle,
                    Projects = x.Projects
                })
                .First();

            var sb = new StringBuilder();

            sb.AppendLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");

            foreach (var projectName in employee147.Projects.OrderBy(x => x.Name))
            {
                sb.AppendLine(projectName.Name);
            }

            var result = sb.ToString().TrimEnd();
            return result;
        }
    }
}
