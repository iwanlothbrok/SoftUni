using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using System;
using System.Linq;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Environment;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var softUniContext = new SoftUniContext();
            var result = IncreaseSalaries(softUniContext);
            Console.WriteLine(result);
        }
        public static string IncreaseSalaries(SoftUniContext context)
        {
            //Engineering, Tool Design, Marketing or Information Services department by 12%. 

            var employees = context.Employees.Where(jt => jt.Department.Name == "Engineering"
            || jt.Department.Name == "Tool Design"
            || jt.Department.Name == "Marketing"
            || jt.Department.Name == "Information Services")
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.Salary
            })
            .OrderBy(e => e.FirstName).ThenBy(e => e.LastName)
            .ToList();

            var sb= new StringBuilder();

            foreach (var e in employees)
            {
                var neededSum = e.Salary;

                sb.AppendLine($"{e.FirstName} {e.LastName} (${neededSum * 1.12m:f2})");
            }
            return sb.ToString().TrimEnd();

        }
        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects.OrderByDescending(pr => pr.StartDate)
                .Select(pr => new
                {
                    ProjectName = pr.Name,
                    Description = pr.Description,
                    StartDate = pr.StartDate
                })
             .OrderBy(pr => pr.ProjectName)
             .Take(10)
             .ToList();


            var sb = new StringBuilder();

            foreach (var p in projects)
            {
                var startD = p.StartDate.ToString("M/d/yyyy h:mm:ss tt");
                sb.AppendLine(p.ProjectName);
                sb.AppendLine(p.Description);
                sb.AppendLine(startD);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departs = context.Departments
                .Select(x => new
                {
                    DepartName = x.Name,
                    ManagerFirstN = x.Manager.FirstName,
                    ManagerLastN = x.Manager.LastName,
                    ManagerJobT = x.Manager.JobTitle
                    ,
                    Employees = x.Employees.Select(e => new
                    {
                        EmployeeFirstName = e.FirstName,
                        EmployeeLastName = e.LastName,
                        JobTitle = e.JobTitle
                    })
                })
                .Where(z => z.Employees.Count() > 5)
                .OrderBy(e => e.Employees.Count())
                .ThenBy(d => d.DepartName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var d in departs)
            {
                sb.AppendLine($"{d.DepartName} - {d.ManagerFirstN} {d.ManagerLastN}");
                foreach (var e in d.Employees.OrderBy(em => em.EmployeeFirstName).ThenBy(em => em.EmployeeLastName))
                {
                    sb.AppendLine($"{e.EmployeeFirstName} {e.EmployeeLastName} - {e.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();

        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var emp147 = context.Employees
                .Where(x => x.EmployeeId == 147)
                .Select(x => new
                {
                    x.FirstName
                    ,
                    x.LastName
                    ,
                    x.JobTitle
                    ,
                    Projects = x.EmployeesProjects.Select(ep => ep.Project.Name).OrderBy(ep => ep).ToList()
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
