using System;

namespace Lab_28_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    public class Fibonacci
    {

        // Create a test with 3 test values to ensure this works
        public static int ReturnFibonacciNthItemInSequence(int n)
        {

            // Return value of Nth item
            if (n < 3)
            {
                return 1;
            }
            else
            {
                return ReturnFibonacciNthItemInSequence(n - 1) + ReturnFibonacciNthItemInSequence(n - 2);
            }
          
        }
    }
}
