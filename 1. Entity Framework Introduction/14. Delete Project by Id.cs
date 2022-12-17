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
            var db = new SoftUniContext();
            var result = DeleteProjectById(db);
            Console.WriteLine(result);

        }
        public static string DeleteProjectById(SoftUniContext context)
        {
            var projectToDelete = context
                .Projects
                .Where(x => x.ProjectId == 2)
                .FirstOrDefault();
            //var projectToDelete2 = context.Employees
            //    .Where(x=>x.Projects == projectToDelete);
            context.Projects.Remove(projectToDelete);
            context.SaveChanges();

            var top10projects = context.Projects.Take(10).ToList();
            var sb = new StringBuilder();

            foreach (var p in top10projects)
            {
                sb.AppendLine($"{p.Name})");
            }

            var result = sb.ToString().TrimEnd();
            return result;
        }
    }
}