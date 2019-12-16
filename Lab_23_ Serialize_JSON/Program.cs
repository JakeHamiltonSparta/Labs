using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace Lab_23__Serialize_JSON
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer(1, "Jake", "NR1234B56");
            var customer2 = new Customer(2, "Toby", "NR5678B90");
            var customer3 = new Customer(3, "Joe", "NR2468B13");
            var customers = new List<Customer> { customer, customer2, customer3 };

            // Serialize
            var JSONCustomerList = JsonConvert.SerializeObject(customers);

            // Peek at object
            Console.WriteLine(JSONCustomerList);

            // Stream to File (JSON)
            File.WriteAllText("data.json", JSONCustomerList);

            // Read
            var JSONstring = File.ReadAllText("data.json");

            // Deserialize
            var customersFromJSON = JsonConvert.DeserializeObject<List<Customer>>(JSONstring);

            // Print
            customersFromJSON.ForEach(c => Console.WriteLine($"{c.CustomerID}{c.CustomerName}"));
        }
    }
    
    [Serializable]

    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }

        [NonSerialized]
        private string NINO; // Opt out

        public Customer(int ID, string Name, string Nino)
        {
            this.CustomerID = ID;
            this.CustomerName = Name;
            this.NINO = Nino;
        }


    }
}
