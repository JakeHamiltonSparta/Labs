using System;

namespace Lab_02_OOP_Mammals_With_Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Cat cat = new Cat();
            cat.Roar();

            Tiger tiger = new Tiger();
            tiger.Roar();

            Lion lion = new Lion();
            lion.Roar();
        }
        
    }
    public class Mammals
    {
        bool IsWarmBlooded = true;
        double Weight { get; set; }
        double Height { get; set; }
        double Length { get; set; }
    }
    public class Cat : Mammals, IUseMyVision, IUseMySmell
    {
        public virtual string Roar()
        {
            string animalRoar = "Cat Roaring";
            return animalRoar;
        }
        public virtual void SeeMyPrey()
        {

        }
        public virtual void SmellMyPrey()
        {

        }
    }
    
    public class Lion : Cat, IUseMyVision, IUseMySmell
    {
        public override string Roar()
        {
            string animalRoar = "Lion Roaring";
            return animalRoar;
        }
        public override void SeeMyPrey()
        {

        }
        public override void SmellMyPrey()
        {

        }
    }

    public class Tiger : Cat, IUseMyVision, IUseMySmell
    {
        public override string Roar()
        {
            string animalRoar = "Tiger is ROARING";
            return animalRoar;

        }
        public override void SeeMyPrey()
        {

        }
        public override void SmellMyPrey()
        {

        }
    }
    interface IUseMyVision
    {
        void SeeMyPrey()
        {

        }

    }
    interface IUseMySmell
    {
        void SmellMyPrey()
        {

        }

    }
}


