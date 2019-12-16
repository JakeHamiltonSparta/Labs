using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lab_15_Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            // Inside here can go a Delegate or an Anonymous using our Lambda Syntax

            var task01 = new Task( 
                () => { }                                         // Lambda Anon Method
            );

            var task02 = new Task(
                () => { Console.WriteLine("In task 02"); }
            );
            task02.Start();
            // Console.ReadLine();

            // Slicker way
            var task03 = Task.Run(() => { Console.WriteLine("In Task 03"); });
            var task04 = Task.Run(() => { Console.WriteLine("In Task 04"); });
            var task05 = Task.Run(() => { Console.WriteLine("In Task 05"); });

            Console.ReadLine();

            // Stop watch
            // Array of tasks
            // Wait for one or all to complete
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
        }
    }
}
