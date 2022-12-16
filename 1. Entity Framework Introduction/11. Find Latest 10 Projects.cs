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
            var result = GetLatestProjects(context);
            Console.WriteLine(result);
        }
        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects
                .OrderByDescending(x => x.StartDate)
                .ThenBy(x => x.Name)
                .Select(x => new
                {
                    NameOfProject = x.Name,
                    DescriptionOfProject = x.Description,
                    StartDateOfProject = x.StartDate
                })
                .ToList();

            var sb = new StringBuilder();

            foreach (var project in projects)
            {
                sb.AppendLine($"{project.NameOfProject}");
                sb.AppendLine($"{project.DescriptionOfProject}");
                sb.AppendLine($"{project.StartDateOfProject}");
            }

            var result = sb.ToString().TrimEnd();
            return result;
        }
    }
}