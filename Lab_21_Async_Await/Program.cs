using System;
using System.IO;
using System.Threading;
using System.Net;
using System.Diagnostics;

namespace Lab_21_Async_Await
{
    class Program
    {

        static Uri uri = new Uri("https://www.bbc.co.uk/weather");

        static Stopwatch s = new Stopwatch();


        static void Main(string[] args)
        {
            // Main Method
            // Setup data file



            File.WriteAllText("data.csv", "id, name, age");
            File.AppendAllText("data.csv", "\n1, Joe, 19");
            File.AppendAllText("data.csv", "\n2, Jake, 21");
            File.AppendAllText("data.csv", "\n3, Toby, 22");

            // Sync WAIT FOR
            //ReadDataSync();

            // Async DONT WAIT FOR
            // ReadDataAsync();

            // GetWebPageSync
            s.Start();

            GetWebPageSync();

            s.Restart();

            GetWebPageAsync();

            Console.WriteLine("Code has finished");
            Console.ReadLine();



        }
        static void ReadDataSync()
        {
            var output = File.ReadAllText("data.csv");
            Thread.Sleep(5000);
            Console.WriteLine("\nSync\n");
            Console.WriteLine(output);
        }

        async static void ReadDataAsync()
        {
            var output = await File.ReadAllTextAsync("data.csv");
            Thread.Sleep(5000);
            Console.WriteLine("\nAsync\n");
            Console.WriteLine(output);
        }

          
        static void GetWebPageSync()
        {

            var webClient = new WebClient { Proxy = null };
            webClient.DownloadFile(uri, "localpagesync.html");

            Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", "localpagesync.html");
            Console.WriteLine($"Web page downloaded at {s.ElapsedMilliseconds} Sync");
        }

        async static void GetWebPageAsync()
        {


            var webClient = new WebClient { Proxy = null };
            webClient.DownloadFile(uri, "localpageasync.html");


            Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", "localpageasync.html");
            Console.WriteLine($"Web page downloaded at {s.ElapsedMilliseconds} Async");
        }
    }
}