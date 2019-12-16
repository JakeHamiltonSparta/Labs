using System;
using Lab_23__Serialize_JSON;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Lab_24_Serialize_Binary
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer(1, "Jake", "NR1234B56");
            var customer2 = new Customer(2, "Toby", "NR5678B90");
            var customer3 = new Customer(3, "Joe", "NR2468B13");
            var customers = new List<Customer> { customer, customer2, customer3 };

            // Formatter : Which will allow serialization to Binary
            var formatter = new BinaryFormatter();

            // Stream to File
            using (var stream = new FileStream("data.bin", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                // Write to file
                formatter.Serialize(stream, customers);
            }

            // Read back
            var customersFromBinFile = new List<Customer>();

            // Stream Read
            using (var reader = File.OpenRead("data.bin"))
            {
                // Deserialize Binary => Customer 
                customersFromBinFile = formatter.Deserialize(reader) as List<Customer>;
            }

            // And print
            customersFromBinFile.ForEach(c => Console.WriteLine($"{c.CustomerID}{c.CustomerName}"));



        }
    }


}
