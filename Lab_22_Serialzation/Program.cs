using System;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;
using System.Collections.Generic;

namespace Lab_22_Serialzation
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer(1, "Jake", "NR1234B56");
            var customer2 = new Customer(2, "Toby", "NR5678B90");
            var customers = new List<Customer> { customer, customer2 };

            // Serialize Customer to an XML format
            // SOAP = Simple Object Access Protocol = XML Transmission mechanism
            var formatter = new SoapFormatter();

            // Stream to a File
            // Stream data to an XML file : Create file each time
            using (var stream = new FileStream("data.xml", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                // Serialize data to XML as a STREAM OF DATA
                formatter.Serialize(stream, customers);
            }

            Console.WriteLine(File.ReadAllText("data.xml"));

            // Reverse
            var customersFromXMLFile = new List<Customer>();

            // Stream Read
            using (var reader = File.OpenRead("data.xml"))
            {
                // Deserialize XML => Customer 

                customersFromXMLFile = formatter.Deserialize(reader) as List<Customer>;
            }

            //and print
            customersFromXMLFile.ForEach(c => Console.WriteLine($"{c.CustomerID}{c.CustomerName}"));


        }
    }

    [Serializable]

    class Customer
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
