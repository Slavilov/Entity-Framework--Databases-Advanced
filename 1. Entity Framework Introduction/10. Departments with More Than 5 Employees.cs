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
            var result = GetDepartmentsWithMoreThan5Employees(context);
            Console.WriteLine(result);
        }
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Where(x => x.Employees.Count > 5)
                .OrderBy(x => x.Employees.Count)
                .ThenBy(x => x.Name)
                .Select(x => new
                {
                    DepartmentName = x.Name,
                    ManagerFirstName = x.Manager.FirstName,
                    ManagerLastName = x.Manager.LastName,
                    EmployeesInDepartement = x.Employees.Select(x => new
                    {
                        FirstNameOfEmployee = x.FirstName,
                        LastNameOfEmployee = x.LastName,
                        JobTitleOfEmployee = x.JobTitle
                    })
                    .OrderBy(x => x.FirstNameOfEmployee)
                    .ThenBy(x => x.LastNameOfEmployee)
                    .ToList()
                })
                .ToList();

            var sb = new StringBuilder();

            foreach (var department in departments)
            {
                sb.AppendLine($"{department.DepartmentName} - {department.ManagerFirstName} {department.ManagerLastName}");

                foreach (var employees in department.EmployeesInDepartement)
                {
                    sb.AppendLine($"{employees.FirstNameOfEmployee} {employees.LastNameOfEmployee} - {employees.JobTitleOfEmployee}");
                }
            }

            var result = sb.ToString().TrimEnd();
            return result;
        }
    }
}