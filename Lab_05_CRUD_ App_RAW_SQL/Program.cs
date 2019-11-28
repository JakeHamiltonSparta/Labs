using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Lab_05_CRUD__App_RAW_SQL
{
    class Program
    {
        static List<Customer> customers = new List<Customer>();
        static Customer customer;

        static void Main(string[] args)
        {
            var randomCustomerID = generateRandomCustomerID();

            generateRandomCustomerID();
            generateRandomCustomerID();
            generateRandomCustomerID();
            generateRandomCustomerID();

            string connectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Northwind";
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                Console.WriteLine(sqlConnection.State);

                customer = addCustomer(sqlConnection);

                updateCustomer(sqlConnection, customer);

                deleteCustomer(sqlConnection, customer);

                //for (int i = 0; i < 10; i++)
                //{
                //    addCustomer(sqlConnection);
                //}
                
                listCustomers(sqlConnection);
            }
        }
        static void listCustomers(SqlConnection sqlConnection)
        {
            // Get customers
            using (var sqlCommand = new SqlCommand("SELECT * FROM Customers", sqlConnection))
            {
                SqlDataReader sqlReader = sqlCommand.ExecuteReader();
                while (sqlReader.Read())
                {
                    var customer = new Customer()
                    {
                        CustomerID = sqlReader["CustomerID"].ToString(),
                        ContactName = sqlReader["ContactName"].ToString(),
                        CompanyName = sqlReader["CompanyName"].ToString(),
                        City = sqlReader["City"].ToString(),
                        Country = sqlReader["Country"].ToString(),
                    };
                    // Put into a list
                    customers.Add(customer);
                }
            }
            // Print List a) for each

            //foreach (var c in customers)
            //{
            //    Console.WriteLine($"{c.CustomerID, -10} {c.ContactName, -30}{c.CompanyName, -40} " + 
            //        $"{c.City, -15}{c.Country, -15}");
            //}

            // Lambda
            Console.WriteLine($"{"CustomerID", -15}{"ContactName", -30}{"CompanyName", -40}{"City", -15}{"Country", -15}");

            customers.ForEach(c =>
                Console.WriteLine($"{c.CustomerID,-10} {c.ContactName,-30}{c.CompanyName,-40} " +
                    $"{c.City,-15}{c.Country,-15}"));
        }
        static Customer addCustomer(SqlConnection sqlConnection)
        {
            var randomCustomerID = generateRandomCustomerID();

            var newCustomer = new Customer()
            {
                CustomerID = randomCustomerID,
                CompanyName = "RoyalRavens",
                ContactName = "Jake",
                City = "London",
                Country = "UK"
            };
            var sqlString = "INSERT INTO Customers (CustomerID,ContactName,CompanyName,City,Country)" +
                "VALUES ('Jake2','Jake','RoyalRavens','London','UK')";
            //using (var sqlCommand = new SqlCommand(sqlString, sqlConnection))
            //{
            //    ExecuteNonQuery ie NOT QUERYING(READING) BUT UPDATING
            //     Returns an integer for the number of rows updated / inserted
            //     Expect 1
            //    int affected = sqlCommand.ExecuteNonQuery();
            //    Console.WriteLine($"{affected} new records added to datebase");
            //}
            var sqlString2 = "INSERT INTO Customers (CustomerID,ContactName,CompanyName,City,Country)" +
               "VALUES (@CustomerID,@ContactName,@CompanyName,@City,@Country)";
            using (var sqlCommand2 = new SqlCommand(sqlString2, sqlConnection))
            {
                sqlCommand2.Parameters.AddWithValue("@CustomerID", randomCustomerID);
                sqlCommand2.Parameters.AddWithValue("@ContactName", newCustomer.ContactName );
                sqlCommand2.Parameters.AddWithValue("@CompanyName", newCustomer.CompanyName);
                sqlCommand2.Parameters.AddWithValue("@City", newCustomer.City);
                sqlCommand2.Parameters.AddWithValue("@Country", newCustomer.Country);



                int affected = sqlCommand2.ExecuteNonQuery();
                Console.WriteLine($"{affected} new records added to datebase");

                if (affected == 1)
                {
                    return newCustomer;

                }
            }
            return null;

        }
        static string generateRandomCustomerID()
        {
            var random = new Random();
            char[] customerID = new char[5];
            for (int i = 0; i < customerID.Length; i++)
            {
                customerID[i] = Convert.ToChar(random.Next(65, 90));
                customerID[i] = (char)random.Next('A', 'Z');
            }
            string s = new string(customerID);
            Console.WriteLine($"Random CustomerID generated {s}");
            return s;
        }


        static void updateCustomer(SqlConnection sqlConnection, Customer c)
        {
            var randomCustomerID = generateRandomCustomerID();
            c.ContactName = "New name";

            var updateSqlString = $"UPDATE Customers SET ContactName = '{c.ContactName}'" +
                $"WHERE CustomerID = '{c.CustomerID}'";
            using (var sqlCommand = new SqlCommand(updateSqlString, sqlConnection))
            {
                int affected = sqlCommand.ExecuteNonQuery();
                Console.WriteLine($"{affected} records updated in datebase");
            }
        }
        static void deleteCustomer(SqlConnection sqlConnection, Customer c)
        {
            var deleteSqlString = $"DELETE FROM Customers WHERE ContactName = '{c.ContactName}'";
            using (var sqlCommand = new SqlCommand(deleteSqlString, sqlConnection))
            {
                int affected = sqlCommand.ExecuteNonQuery();
                Console.WriteLine($"{affected} records deleted in datebase");
            }
        }
    }
    class Customer
    {
        public string CustomerID { get; set; }
        public string ContactName { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
