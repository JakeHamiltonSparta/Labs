using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace Lab_14_LINQ
{
    public class Program
    {
        static void Main(string[] args)
        {

            #region Explanation
            /*
             * 1) Read NORTHWIND using Entity Core 2.1.1
             * 2) Basic LINQ
             * 3) More advanced LINQ with LAMBDA
             * 
             */



            // Nuget: Downloaded MicrosoftEntityFrameworkCore / .sqlserver / .design

            #endregion

            List<Customer> customers = new List<Customer>();
            List<ModifiedCustomer> modifiedCustomers = new List<ModifiedCustomer>();
            List<Product> products = new List<Product>();
            List<Category> categories = new List<Category>();

            using (var db = new Northwind())
            {
                customers = db.Customers.ToList();


                // SIMPLE LINQ
                // WHOLE DATASET IS RETURNED (MORE DATA)
                //IENUMERABLE ARRAY
                var selectedCustomers =
                    from customer in customers
                    select customer;

                // SAME QUERY OVER THE DB DIRECTLY
                // ONLY RETURN DATA WE NEED 
                // LAZY LOADING: QUERY ISNT EXECUTED
                // DATA HAS NOT ACTUALLY ARRIVED YET
                var selectedCustomers2 =
                    (from customer in db.Customers
                     where customer.City == "London" || customer.City == "Berlin"
                     orderby customer.CompanyName
                     select customer).ToList();

                // FORCED DATA BY PUSHING THE LIST IE .ToList() or by taking aggregate eg sum, count
                printCustomers(selectedCustomers2);
                var selectedCustomers3 =
                    (from customer in db.Customers
                     select new
                     {
                         Name = customer.ContactName,
                         Location = customer.City + " " + customer.Country
                     }).Take(10).Skip(10).ToList();

                foreach (var c in selectedCustomers3)
                {
                    Console.WriteLine($"{c.Name,-30}{c.Location,-30}");
                }
                // OR

                var selectedCustomers4 =
                        (from c in db.Customers
                         select new ModifiedCustomer(c.ContactName, c.City + " " + c.Country)).ToList();

                // Grouping
                // group and list all customers by CITY
                // CITY ... Count(CUSTOMER)
                var selectedCustomers5 =
                    from cust in db.Customers
                    group cust by cust.City into Cities
                    orderby Cities.Count() descending
                    select new
                    {
                        City = Cities.Key,
                        Count = Cities.Count()
                    };
                foreach (var c in selectedCustomers5)
                {
                    Console.WriteLine($"{c.City,-15}{c.Count}");
                }

                // JOIN
                // products with CategoryID => category


                Console.WriteLine("\n\nList of Products Inner Join Category showing name0");

                var listofproducts =
                        (from p in db.Products
                         join c in db.Categories
                     on p.CategoryID equals c.CategoryID
                         select new
                         {
                             ID = p.ProductID,
                             Name = p.ProductName,
                             Category = c.CategoryName
                         }).ToList();

                listofproducts.ForEach(p => Console.WriteLine($"{p.ID,-15}{p.Name,-15}{p.Category,15}"));

                Console.WriteLine("\n\nNow print off the same list but using smarter 'Dot' notationto join tables");
                // Read in products and categories
                products = db.Products.ToList();
                categories = db.Categories.ToList();
                products.ForEach(p => Console.WriteLine($"{p.ProductID,-15}{p.ProductName,-15}{p.Category.CategoryName,-15}"));

                Console.WriteLine("\n\nList Categories with count of products and sub list of product names\n");
                categories.ForEach(c =>
                {
                    Console.WriteLine($"{c.CategoryID} {c.CategoryName} has {c.Products.Count} products");


                    foreach (var p in c.Products)
                    {
                        Console.WriteLine($"\t\t\t\t{p.ProductID,-5}{p.ProductName}");
                    }

                }
            );

                Console.WriteLine("\n\nLINQ Lambda notation");
                customers = db.Customers.ToList();
                Console.WriteLine($"Count is {customers.Count}");
                Console.WriteLine($"Count is {db.Customers.Count()}");

                // Select Distinct
                Console.WriteLine("\n\nList of Distinct Cities\n");
                Console.WriteLine("Using select to select one column \n");
                var cityList = db.Customers.Select(c => c.City).Distinct().OrderBy(c=>c).ToList();
                cityList.ForEach(city => Console.WriteLine(city));

                Console.WriteLine("\n\nContains (same as SQL LIKE)\n");

                var cityListFiltered =
                    db.Customers.Select(c => c.City)
                    .Where(city => city.Contains("o"))
                    .Distinct()
                    .OrderBy(c => c)
                    .ToList();
                cityListFiltered.ForEach(city => Console.WriteLine(city));

                
            }
            static void printCustomers(List<Customer> customers)
            {
                customers.ForEach(c => Console.WriteLine($"{c.CustomerID,-10}"
                    + $"{c.ContactName,-30}{c.CompanyName,-30}{c.City,-10}"));
            }
        }

        public static int GetCustomers(string city)
        {
            using (var db = new Northwind())
            {
                if (string.IsNullOrEmpty(city))
                {
                    return db.Customers.Count();
                }
                else
                    return db.Customers.Where(c => c.City == city).Count();
            }
        }

        #region DatabaseContextAndClasses
        // connect to database

        public partial class Customer
        {
            public string CustomerID { get; set; }
            public string CompanyName { get; set; }
            public string ContactName { get; set; }
            public string ContactTitle { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string Region { get; set; }
            public string PostalCode { get; set; }
            public string Country { get; set; }
            public string Phone { get; set; }
            public string Fax { get; set; }
        }
        public class Category
        {
            public int CategoryID { get; set; }
            public string CategoryName { get; set; }
            public string Description { get; set; }
            public virtual ICollection<Product> Products { get; set; }

            public Category()
            {
                this.Products = new List<Product>();
            }
        }

        public class Product
        {
            public int ProductID { get; set; }
            public string ProductName { get; set; }
            public int? CategoryID { get; set; }
            public virtual Category Category { get; set; }
            public string QuantityPerUnit { get; set; }
            public decimal? UnitPrice { get; set; } = 0;
            public short? UnitsInStock { get; set; } = 0;
            public short? UnitsOnOrder { get; set; } = 0;
            public short? ReorderLevel { get; set; } = 0;
            public bool Discontinued { get; set; } = false;
        }

        public class Northwind : DbContext
        {
            public DbSet<Category> Categories { get; set; }

            public DbSet<Product> Products { get; set; }

            public DbSet<Customer> Customers { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;" + "Initial Catalog=Northwind;" + "Integrated Security = true;" + "MultipleActiveResultSets=true;");
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<Category>()
                    .Property(c => c.CategoryName)
                    .IsRequired()
                    .HasMaxLength(15);

                // define a one-to-many relationship
                modelBuilder.Entity<Category>()
                    .HasMany(c => c.Products)
                    .WithOne(p => p.Category);

                modelBuilder.Entity<Product>()
                    .Property(c => c.ProductName)
                    .IsRequired()
                    .HasMaxLength(40);

                modelBuilder.Entity<Product>()
                    .HasOne(p => p.Category)
                    .WithMany(c => c.Products);
            }

            public int NumberOfNothwindCustomers(string city)
            {
                int total = 0;
                using (var db = new Northwind())
                {
                    total =
                        (from Customer in db.Customers
                         where Customer.City == city
                         select Customer).Count();


                }
                return total;


            }
        }

        public class ModifiedCustomer
        {
            public string Name { get; set; }
            public string Location { get; set; }
            public ModifiedCustomer(string name, string location)
            {
                this.Name = Name;
                this.Location = Location;
            }
        }
        #endregion
    }
}
