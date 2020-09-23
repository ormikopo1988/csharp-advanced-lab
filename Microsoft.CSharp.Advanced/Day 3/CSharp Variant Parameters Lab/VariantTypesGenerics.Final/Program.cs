using System;
using System.Linq;
using VariantTypesGenerics.Final.DbAccess;
using VariantTypesGenerics.Final.Models;

namespace VariantTypesGenerics.Final
{
    class Program
    {
        static void Main(string[] args)
        {
            using (IRepository<Employee> employeeRepository
                = new SqlLiteRepository<Employee>(new EmployeeDb()))
            {
                AddEmployees(employeeRepository);
                AddManagers(employeeRepository);
                CountEmployees(employeeRepository);
                DumpPeople(employeeRepository);
                ClearDb(employeeRepository);
            }
        }

        static void AddEmployees(IRepository<Employee> employeeRepository)
        {
            employeeRepository.Add(new Employee { Name = "Scott" });
            employeeRepository.Add(new Employee { Name = "Chris" });
            employeeRepository.Commit();
        }

        static void AddManagers(IWriteOnlyRepository<Manager> managerRepository)
        {
            managerRepository.Add(new Manager { Name = "Alex" });
            managerRepository.Commit();
        }

        static void CountEmployees(IRepository<Employee> employeeRepository)
        {
            Console.WriteLine(employeeRepository.FindAll().Count());
        }

        // How can we share DumpPeople functionality between Person and Employee objects.
        // We need to make the IRepository generic interface covariant.
        // Put the out generic modifier inside the definition of the generic type parameter.
        // The common scenario for covariance here is that I want to reuse some logic
        // and work with base types as much as possible. What this gives us is that we can treat an 
        // IReadOnlyRepository<Employee> as an IReadOnlyRepository<Person> and thus allows us to 
        // share the logic both People and Employee object instances.
        static void DumpPeople(IReadOnlyRepository<Person> employeeRepository)
        {
            var employees = employeeRepository.FindAll();

            foreach (var employee in employees)
            {
                Console.WriteLine(employee.Name);
            }
        }

        static void ClearDb(IRepository<Employee> employeeRepository)
        {
            var allEmployees = employeeRepository.FindAll();

            foreach (var emp in allEmployees)
            {
                employeeRepository.Delete(emp);
            }

            employeeRepository.Commit();
        }
    }
}