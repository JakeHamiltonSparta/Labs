using System;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Text;

namespace Lab_18_Streaming
{
    class Program
    {
        static void Main(string[] args)
        {
            // System.IO WRITING FILES
            File.WriteAllText("data.txt", "Hello this is some text"); // Overwrites doesnt create new

            var myArray = new string[] {"Hello", "This", "is", "some", "data" };
            File.WriteAllLines("ArrayData.txt", myArray);


            for (int i = 0; i < 10; i++)
            {
                File.AppendAllText("data.txt", Environment.NewLine + $"Adding line i at {DateTime.Now}"); // Professional way
            }

            Console.WriteLine(File.ReadAllText("data.txt"));

            var output = File.ReadAllLines("ArrayData.txt").ToList();
            output.ForEach(line => Console.WriteLine(line));

            Directory.CreateDirectory("Here is a folder");
            File.Create("Here is a folder\\myfile.txt");
            File.Create(@"Here is a folder\myfile2.txt");

            Directory.CreateDirectory(@"C:\RootFolder");
            Console.WriteLine(Directory.Exists(@"C:\RootFolder"));

            // Stream some data into a file
            // System can cope with large files : breaks them down into blocks and sends them
            var numberOfLines = 10_000;
            var s = new Stopwatch();
            s.Start();

            using (var writer = new StreamWriter("output.dat"))
            {
                for (int i = 0; i < numberOfLines; i++)
                {
                    writer.WriteLine($"Logging some data at {DateTime.Now}");
                }
            }

            var writeTime = s.ElapsedMilliseconds;
            Console.WriteLine($"It took {s.ElapsedMilliseconds} to write {numberOfLines} lines");

            // Read Data
            string nextline;



            using (var reader = new StreamReader("output.dat"))
            {
                // READER DOESNT KNOW HOW BIG THE FILE IS
                // READ UNTIL READER.READLINE IS NULL
                while ((nextline = reader.ReadLine()) != null)
                {
                    //Console.WriteLine(nextline);
                }
                reader.Close();
            }
            Console.WriteLine($"It took {s.ElapsedMilliseconds - writeTime} to read {numberOfLines} lines");

            // Building a string
            // Regular string building with + Generate a new instance everytime
            // Strings are immutable (Cannot be changed)
            // t => th ==> thi
            s.Restart();
            var longString = "";
            using (var reader = new StreamReader("output.dat"))
            {
                while ((nextline = reader.ReadLine()) != null)
                {
                    longString += nextline;
                }
                reader.Close();
            }
            Console.WriteLine($"It took {s.ElapsedMilliseconds} to add {numberOfLines} strings together");
            //Console.WriteLine(longString);



            s.Restart();
            longString = "";
            var stringBuilder = new StringBuilder();

            using (var reader = new StreamReader("output.dat"))
            {
                while ((nextline = reader.ReadLine()) != null)
                {
                    stringBuilder.Append(nextline);
                }
                reader.Close();
            }
            Console.WriteLine($"It took {s.ElapsedMilliseconds} to add {numberOfLines} strings together using string builder");
            //Console.WriteLine(longString);


        }
    }
}
