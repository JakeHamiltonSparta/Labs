using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Linq;

namespace Lab_16_Tasks
{
    class Program
    {
        static Stopwatch s = new Stopwatch();
        static void Main(string[] args)
        {

           
            s.Start();
            var task01 = Task.Run(() => {
                Console.WriteLine("Task01 is running");
                Console.WriteLine($"Task 01 complete at time {s.ElapsedMilliseconds}");
                }
            );

            // Old fashioned way of putting a DELEGATE as a parameter into a task
            var actionDelegate = new Action(SpecialActionMethod); // Pass in method as an argument
            var task02 = new Task(actionDelegate);
            task02.Start();

            // Array of Tasks

            // Array of Anonymous tasks
            Task[] taskArray = new Task[]
            {
                new Task(() => { // Overnight Process Task
                } ),
                new Task(() => { } ),
                new Task(() => { } ),
                new Task(() => { } ),
                new Task(() => { } ),
                new Task(() => { } )

            };

            foreach (var task in taskArray)
            {
                task.Start();
            }

            // Second way
            var taskArray2 = new Task[3];
            taskArray2[0] = Task.Run(() => {
                Thread.Sleep(500);
                Console.WriteLine($"Array Task 0 completing at {s.ElapsedMilliseconds}"); 
            });

            taskArray2[1] = Task.Run(() => {
                Thread.Sleep(200);
                Console.WriteLine($"Array Task 1 completing at {s.ElapsedMilliseconds}");
            });

            taskArray2[2] = Task.Run(() => {
                Thread.Sleep(100);
                Console.WriteLine($"Array Task 2 completing at {s.ElapsedMilliseconds}");
            });

            // Wait for one task to complete
            Task.WaitAny(taskArray2);
            Console.WriteLine($"Waiting for first array task to complete at time {s.ElapsedMilliseconds}");

            // Wait for all tasks to complete
            Task.WaitAll(taskArray2);
            Console.WriteLine($"Waiting for ALL array tasks to complete at time {s.ElapsedMilliseconds}");

            // Parallel Foreach Loop
            int[] myCollection = new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };

            // Regular foreach loop goes in order but parallel kcicks off x jobs at the same time
            long Async = 0;
            Parallel.ForEach(myCollection, (item) => {
                //Thread.Sleep(item * 100);
                Console.WriteLine($"Foreach loop item {item} finishing at time {s.ElapsedMilliseconds}");
                Async += s.ElapsedMilliseconds;
            });
            Console.WriteLine($"Async took {Async}");

            // Sync loop
            Console.WriteLine("\n\nNow run as a sync loop\n");

            long Sync = 0;
            foreach (var item in myCollection)
            {
                //Thread.Sleep(item * 100);
                Console.WriteLine($"Sync Foreach loop item {item} finishing at time {s.ElapsedMilliseconds}");
                Sync += s.ElapsedMilliseconds;
            }
            Console.WriteLine($"Sync took {Sync}");

            // Also powerful is LINQ : Database queries in parallel
            // Fake it here : use local collection
            var databaseOutput =
                (from item in myCollection
                 select item * item
                 ).AsParallel().ToList();
            // Could use this on real database query if many quieries and each one possibly takes a long time

            // Getting data back from tasks
            var TaskWithoutReturningData = new Task(() => { });
            var TaskWithReturningData = new Task<int>(() => 
            {
                int total = 0;
                for (int i = 0; i < 100; i++)
                {
                    total += 1;
                }
                return total;
            });

            TaskWithReturningData.Start();

            Console.WriteLine($"I have counted to 100 using a background task so i don't have to hang the main thread." + 
                $" The answer is {TaskWithReturningData.Result}");




            Console.WriteLine($"Main method all tasks complete at this time {s.ElapsedMilliseconds}");
            // One tick is 10 to the power of -7 seconds ie 0.1 micro second
            // Console.WriteLine($"Application finished at time {s.ElapsedTicks}");
            Console.ReadLine();
        }
        static void SpecialActionMethod()
        {
            Console.WriteLine("This action method takes no parameters, " +
                "returns nothing and is generally useless. Performs the action printing it out.");

            var total = 0;

            for (int i = 0; i < 1_000_000_000; i++)
            {
                total += 1;
            }
            Console.WriteLine(total);
            Thread.Sleep(2000);
            Console.WriteLine($"Special action method completing at {s.ElapsedMilliseconds}");
        }

    }
}
