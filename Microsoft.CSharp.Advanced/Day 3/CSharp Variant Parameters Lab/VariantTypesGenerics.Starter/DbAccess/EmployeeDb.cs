using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using VariantTypesGenerics.Starter.Models;

namespace VariantTypesGenerics.Starter.DbAccess
{
    public class EmployeeDb : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // Gets the current path (executing assembly)
            string currentPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            // Your DB filename    
            string dbFileName = "employee.db";
            // Creates a full path that contains your DB file
            string absolutePath = Path.Combine(currentPath, dbFileName);

            options.UseSqlite($"Data Source={absolutePath}");
        }

    }
}
