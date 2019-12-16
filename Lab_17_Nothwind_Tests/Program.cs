using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.SqlServer;


namespace Lab_17_Nothwind_Tests
{
    public class Program
    {

        static void Main(string[] args)
        {
            var NorthCustomers = new NorthwindCustomers();
            Console.WriteLine(NorthCustomers.NumberOfNothwindCustomers("London"));
            Console.WriteLine(NorthCustomers.NumberOfNothwindCustomers(null));
            Console.ReadLine();

        }
    }

    public class NorthwindCustomers
    {
        public int NumberOfNothwindCustomers(string city)
        {
            int total = 0;
              using (var db = new NorthwindEntities())
            {
                total =
                    (from Customer in db.Customers
                     where Customer.City == city
                     select Customer).Count();
    
               
            }
            return total;

          
        }

    }
}
