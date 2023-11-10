namespace SoftUni
{
    using Data;
    using Models;

    using System.Text;
    using System.Globalization;

    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();

            //Problem 03.
            //Console.WriteLine(GetEmployeesFullInformation(context));

            //Problem 04.
            //Console.WriteLine(GetEmployeesWithSalaryOver50000(context));

            //Problem 05.
            //Console.WriteLine(GetEmployeesFromResearchAndDevelopment(context));

            //Problem 06.
            //Console.WriteLine(AddNewAddressToEmployee(context));

            //Problem 07.
            //Console.WriteLine(GetEmployeesInPeriod(context));
        }

        //Problem 03.
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees
                .OrderBy(x => x.EmployeeId)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary
                })
                .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine(
                    $"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();

        }

        //Problem 04.
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees
                .OrderBy(x => x.FirstName)
                .Where(x => x.Salary > 50000)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();

        }

        //Problem 05.
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees
                .OrderBy(x => x.Salary)
                .ThenByDescending(x => x.FirstName)
                .Where(x => x.Department.Name == "Research and Development")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Department.Name,
                    e.Salary
                });

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.Name} - ${employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 06.
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address newAddress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            //context.Addresses.Add(newAddress); // This is the way for adding into the db

            Employee? employee = context.Employees
                .FirstOrDefault(e => e.LastName == "Nakov");
            employee.Address = newAddress;

            context.SaveChanges();

            string[] employeeAddresses = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => e.Address!.AddressText)
                .ToArray();

            return String.Join(Environment.NewLine, employeeAddresses);
        }

        //Problem 07.
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employeesWithProjects = context.Employees
                .Take(10)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    Projects = e.EmployeesProjects
                        .Where(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003)
                        .Select(ep => new
                        {
                            ProjectName = ep.Project.Name,
                            StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                            EndDate = ep.Project.EndDate.HasValue
                                ? ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                                : "not finished"
                        })
                        .ToList()
                })
                .ToList();

            foreach (var e in employeesWithProjects)
            {
                sb
                    .AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");

                foreach (var p in e.Projects)
                {
                    sb
                        .AppendLine($"--{p.ProjectName} - {p.StartDate} - {p.EndDate}");
                }
            }

            return sb.ToString().TrimEnd();

        }

    }
}