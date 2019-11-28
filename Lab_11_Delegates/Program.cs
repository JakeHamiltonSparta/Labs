using System;

namespace Lab_11_Delegates
{
    class Program
    {
        // Mathing Delegate
        public delegate void Delegate01();

        // Non-trivial Delegate
        delegate int Delegate02(int x);
        static void Main(string[] args)
        {
            // Delegate can be referenced as a class
            var delegateInstance = new Delegate01(MyMethod01);
            delegateInstance(); // Call

            // Trivial cases can simplify (Same result)
            // 1. Omit 'new'
            Delegate01 delegateInstance2 = MyMethod01;
            delegateInstance2(); // Call

            // Final Trivial case
            // Action delegate void and takes no parameters
            Action delegateInstance3 = MyMethod01; // Same as above
            delegateInstance3();

            Delegate02 delegateInstance4 = (x) => { return (x * x * x); }; // Lambda
                                                                           // Input parameters // Code body

            Delegate02 delegateInstance5 = x => x * x * x; // Lambda
                                                                           // Input parameters // Code body
        }

        static void MyMethod01()
        {
            Console.WriteLine("Running Method01");
        }
    }
}
