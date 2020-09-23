using System;
using System.Linq;
using VariantTypesGenerics.Starter.DbAccess;
using VariantTypesGenerics.Starter.Models;

namespace VariantTypesGenerics.Starter
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1st step
            // To install EF Core, you install the package for the EF Core database provider(s) you want to target. 
            // Here we will use SQLite because it runs on all platforms that .NET Core supports.
            // Open a Powershell Window to the console app root directory and run the following
            // - dotnet add package Microsoft.EntityFrameworkCore.Sqlite
            // Alternatively, you can do the same through Visual Studio Nuget Package Manager
            // To see the sqlite db and run queries download and install: https://marketplace.visualstudio.com/items?itemName=ErikEJ.SQLServerCompactSQLiteToolbox

            // 2nd step
            // Define a DbContext class and entity classes that make up the model by creating a new class called EmployeeDb.cs and put it inside DbAccess folder.
            // The models we are going to use for this lab are defined inside the Models folder.
            // The EmployeeDb class must derive from DbContext.
            // Define a property inside the EmployeeDb class as follows:
            // - public DbSet<Employee> Employees { get; set; }
            // This will model the Employees table in our Sql-Lite db.
            // Also put inside the EmployeeDb class the following code:
            //protected override void OnConfiguring(DbContextOptionsBuilder options)
            //{
            //    // Gets the current path (executing assembly)
            //    string currentPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //    // Your DB filename    
            //    string dbFileName = "employee.db";
            //    // Creates a full path that contains your DB file
            //    string absolutePath = Path.Combine(currentPath, dbFileName);

            //    options.UseSqlite($"Data Source={absolutePath}");
            //}

            // 3rd step
            // Create a SqlLiteRepository.cs class and put it inside DbAccess folder.
            // Make this class implement IRepository<T> interface.
            // Implement the necessary methods as follows:
            //public class SqlLiteRepository<T> : IRepository<T>
            //    where T : class, IEntity
            //{
            //    DbContext _ctx;
            //    DbSet<T> _set;

            //    public SqlLiteRepository(DbContext ctx)
            //    {
            //        _ctx = ctx;
            //        _set = _ctx.Set<T>();
            //    }

            //    public void Add(T newEntity)
            //    {
            //        if (newEntity.IsValid())
            //        {
            //            _set.Add(newEntity);
            //        }
            //    }

            //    public void Delete(T entity)
            //    {
            //        _set.Remove(entity);
            //    }

            //    public T FindById(int id)
            //    {
            //        return _set.Find(id);
            //    }

            //    public IQueryable<T> FindAll()
            //    {
            //        return _set;
            //    }

            //    public int Commit()
            //    {
            //        return _ctx.SaveChanges();
            //    }

            //    public void Dispose()
            //    {
            //        _ctx.Dispose();
            //    }
            //}

            // 4th step
            // Create the database by following steps that use migrations to create it:
            // - dotnet tool install --global dotnet-ef
            // - dotnet add package Microsoft.EntityFrameworkCore.Design
            // - dotnet ef migrations add InitialCreate
            // - dotnet ef database update
            // This installs dotnet ef and the design package which is required to run the command on a project. 
            // The migrations command scaffolds a migration to create the initial set of tables for the model. 
            // The database update command creates the database and applies the new migration to it.

            // 5th step
            // Uncomment the following code - Make the code compile by adding the necessary references.
            //using (IRepository<Employee> employeeRepository
            //    = new SqlLiteRepository<Employee>(new EmployeeDb()))
            //{
            //    AddEmployees(employeeRepository);
            //    AddManagers(employeeRepository);
            //    CountEmployees(employeeRepository);
            //    DumpPeople(employeeRepository);
            //    ClearDb(employeeRepository);
            //}

            // 6th step
            // Run the app 
            // - dotnet run
            // Or from VS run the console app.

            // 1st exe
            // Change DumpPeople so as to take <Person> instead of <Employee>.
            // The way this method is in its current form it says that IRepository is invariant.
            // So If I have an IRepository<Employee>, I always have to treat it as an IRepository<Employee>.
            // Consider which of Covariance or Contravariance should be applied to the IRepository generic interface 
            // in order to be able to reuse the DumpPeople logic between
            // both Employee and Person objects.
            // Consider adding a new interface and make its generic type T covariant / contravariant based on the requirements.
            // Consider which methods of IRepository you should move to the new interface.

            // 2nd exe
            // Change AddManagers so as to take <Manager> instead of <Employee>.
            // We want this method only view this repository as something that can handle Manager objects.
            // The way this method is in its current form it says that IRepository is invariant.
            // So If I have an IRepository<Employee>, I always have to treat it as an IRepository<Employee>.
            // Consider which of Covariance or Contravariance should be applied to the IRepository generic interface 
            // in order to be able to reuse the AddManagers logic between both Employee and Manager objects.
            // Consider adding a new interface and make its generic type T covariant / contravariant based on the requirements.
            // Consider which methods of IRepository you should move to the new interface.
        }

        static void AddEmployees(IRepository<Employee> employeeRepository)
        {
            employeeRepository.Add(new Employee { Name = "Scott" });
            employeeRepository.Add(new Employee { Name = "Chris" });
            employeeRepository.Commit();
        }

        static void AddManagers(IRepository<Employee> employeeRepository)
        {
            employeeRepository.Add(new Manager { Name = "Alex" });
            employeeRepository.Commit();
        }

        static void CountEmployees(IRepository<Employee> employeeRepository)
        {
            Console.WriteLine(employeeRepository.FindAll().Count());
        }

        static void DumpPeople(IRepository<Employee> employeeRepository)
        {
            var employees = employeeRepository.FindAll();

            foreach (var employee in employees)
            {
                Console.WriteLine(employee.Name);
            }
        }
    }
}