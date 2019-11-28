using System;

namespace Lab_10_Events
{
    class Program
    {
        // Create Delegate type
        delegate void MyDelegate();
        delegate int MyDelegate02(int x);

        // Create event (Empty at the moment)
        static event MyDelegate MyEvent;
        static event MyDelegate02 MyEvent2;
        
        static void Main(string[] args)
        {
            // Add methods to event
            MyEvent += Method01;
            MyEvent += Method02;
            MyEvent2 += Method03;

            // Fire event
            MyEvent();
            Console.WriteLine("Event 2 prints out "+ MyEvent2(10));
        }
        static void Method01()
        {
            Console.WriteLine("Running Method01");
        }
        static void Method02()
        {
            Console.WriteLine("Running Method02");
        }

        static int Method03(int x)
        {
             return x * x;
        }
    }
}
