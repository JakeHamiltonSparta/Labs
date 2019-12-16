#define JAKESTESTCODE 
using System;
using System.Diagnostics;
using System.IO;

namespace Lab_30_Debugging
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 20; i++)
            {
                var j = $"Your number doubled is {i * 2}";
                DoThis();
                Console.WriteLine($"{i}\n{j} ");
            }
#if DEBUG
            Console.WriteLine("Your program is in Debug mode");
        
#endif

#if JAKESTESTCODE
            Console.WriteLine("\n\nJakes Test Code is running");
#endif

            Debug.WriteLine("We are in Debug mode");

            int z = 100;
            Debug.WriteLine(z == 100, "z is 100");

            Trace.WriteLine("Tracing some output");
            Trace.WriteLineIf(z == 100, "z is 100 in Trace");

            File.AppendAllText("Events.log", $"z has value {z} at {DateTime.Now}");


        }


            static void DoThis()
            {
                Console.WriteLine("Doing a thing");
            }
        }
    }

