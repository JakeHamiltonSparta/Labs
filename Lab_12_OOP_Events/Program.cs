using System;

namespace Lab_12_OOP_Events
{
    class Program
    {
        static void Main(string[] args)
        {
            var James = new Child("James");

            James.Grow();
            James.Grow();
            James.Grow();
            James.Grow();
            James.Grow();
        }
    }
    class Child
    {
        // Trivial event Annual Birthday
        delegate void BirthdayDelegate();
        event BirthdayDelegate HaveABirthday;
        public string Name { get; set; }
        public int Age { get; set; }

        public void HaveAParty()
        {
            // This key word refers to the instance
            // this.Age++;
            Age++;
            Console.WriteLine("Celebrating another year! " + $"Age is now {this.Age}");
        }
        public Child(string name)
        {
            this.Name = name;
            this.Age = 0;
            HaveABirthday += HaveAParty;
        }
        public void Grow()
        {
            HaveABirthday(); // Call the event
        }
    }
}
