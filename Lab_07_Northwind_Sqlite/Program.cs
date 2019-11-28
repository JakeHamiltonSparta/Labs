using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Sqlite;
using System.Collections.Generic;
using System.Linq;

namespace Lab_07_Northwind_SQLite
{
    class Program
    {
        public static List<Customer> customers = new List<Customer>();
        static void Main(string[] args)
        {            
            PrintCustomer();            
        }
        public static void PrintCustomer()
        {
            using (var db = new CustomersDbContext())
            {
                customers = db.Customers.ToList();
            }

            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.CustomerID, -10}{customer.ContactName, -30}{customer.CompanyName, -50}{customer.City,-20}{customer.Country,-20}");
            }
        }
    }

    #region Customer.cs
    class Customer
    {
        public Customer() { }
        public Customer(string ContactName, string CompanyName)
        {
            this.ContactName = ContactName;
            this.CompanyName = CompanyName;
        }
        public string CustomerID { get; set; }
        public string ContactName { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
    #endregion

    #region CustomersDbContext
    // Connects to the database
    class CustomersDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlite(@"Data Source=C:\Users\Jake Hamilton\Engineering45\SQLite\Northwind.db");       
        }
    }
}
#endregion