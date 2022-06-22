using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using System;
using System.Linq;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var softUniContext = new SoftUniContext();
            var result = GetEmployee147(softUniContext);
            Console.WriteLine(result);
        }
        public static string GetEmployee147(SoftUniContext context)
        {
            var emp147 = context.Employees
                .Where(x => x.EmployeeId == 147)
                .Select(x => new
                {
                    x.FirstName
                    , x.LastName
                    , x.JobTitle
                    , Projects = x.EmployeesProjects.Select(ep=>ep.Project.Name).OrderBy(ep=>ep).ToList()
                })
                .First();


            var sb = new StringBuilder();
            sb.Append($"{emp147.FirstName} {emp147.LastName} - {emp147.JobTitle}{Environment.NewLine}{String.Join(Environment.NewLine, emp147.Projects)}");


            return sb.ToString().TrimEnd();
        }
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var selectedAddresses = context.Addresses
                     .OrderByDescending(a => a.Employees.Count)
                     .ThenBy(a => a.Town.Name)
                     .ThenBy(a => a.AddressText)
                     .Take(10)
                     .Select(a => new
                     {
                         Text = a.AddressText,
                         Town = a.Town.Name,
                         EmployeesCount = a.Employees.Count
                     })
                     .ToList();

            var sb = new StringBuilder();
            foreach (var address in selectedAddresses)
            {
                sb.AppendLine($"{address.Text}, {address.Town} - {address.EmployeesCount} employees");
            }
            return sb.ToString().TrimEnd();
        }
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees.Select(x => new
            {
                x.EmployeeId,
                x.FirstName,
                x.LastName,
                x.MiddleName,
                x.JobTitle,
                x.Salary
            })
            .OrderBy(x => x.EmployeeId)
            .ToList();

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
            }
            return sb.ToString().TrimEnd();
        }
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees.Select(x => new
            {
                x.FirstName,
                x.Salary
            })
            .Where(x => x.Salary > 50000)
            .OrderBy(x => x.FirstName)
            .ToList();

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
            }
            return sb.ToString().TrimEnd();

        }
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {

            var employees = context.Employees
                .Where(x => x.Department.Name == "Research and Development")
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.Department.Name,
                    x.Salary,

                })
                .OrderBy(x => x.Salary).ThenByDescending(x => x.FirstName)
                                                .ToList();

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.Name} - ${employee.Salary:f2}");
            }
            return sb.ToString().TrimEnd();
        }
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var nakov = context.Employees.Where(x => x.LastName == "Nakov").FirstOrDefault();

            nakov.Address = new Models.Address()
            {
                TownId = 4,
                AddressText = "Vitoshka 15"
            };


            context.SaveChanges();


            var emp = context.Employees
                  .OrderByDescending(e => e.Address.AddressId)
                  .Take(10)
                  .Select(e => e.Address.AddressText)
                  .ToList();

            var sb = new StringBuilder();
            foreach (var e in emp)
            {
                sb.AppendLine(e.ToString());
            }
            return sb.ToString().TrimEnd().TrimEnd();


        }
    }
}
