using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Lab_04_Connect_To_RAW_SQL
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Northwind";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine(connection.State);

                // READ FROM DATABASE
                using (var sqlcommand = new SqlCommand("SELECT * FROM CUSTOMERS", connection))
                {
                    // Create a loop to read and iterate and parse the data
                    SqlDataReader reader = sqlcommand.ExecuteReader();
                    // Loop while data is present
                    while (reader.Read())
                    {
                        string CustomerID = reader["CustomerID"].ToString();
                        string ContactName = reader["ContactName"].ToString();
                        Console.WriteLine($"{CustomerID,-15}{ContactName}");
                    }
                }
            }
        }
    }
}
