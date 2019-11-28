using System;

namespace Lab_03_OOP_Every_Feature_Combined
{
    class Program
    {
        static void Main(string[] args)
        {
            Esport esport = new Esport();
            esport.EsportsArenaAttendence();

            CallOfDuty cod = new CallOfDuty();
            cod.EsportsArenaAttendence();

            LeagueOfLegends lol = new LeagueOfLegends();
            lol.EsportsArenaAttendence();
        }


    }
    class Esport
    {
        public string tournament { get; set; }
        private decimal prizeMoney;

        public virtual void EsportsArenaAttendence()
        {
            int attendence = 10000;
            Console.WriteLine("Attendence today is: {0}", attendence);
        }
    public decimal PrizeMoney
        {
            get{ return prizeMoney; }
            set{ prizeMoney = value; }
        }
    }
    sealed class CallOfDuty : Esport
    {
        private string classSetup;
        private string map;
        private string mode;

        public override void EsportsArenaAttendence()
        {
            int attendence = 2000;
            Console.WriteLine("Attendence for COD today is: {0}", attendence);
        }
    }
    sealed class LeagueOfLegends : Esport
    {
        private string itemLoadout;
        private string champion;
        private bool inting;

        public override void EsportsArenaAttendence()
        {
            int attendence = 20000;
            Console.WriteLine("Attendence for LoL today is: {0}", attendence);
        }
    }
    abstract class ApexLegends
    {
        public abstract string HighestEarner();
        public abstract string BestTeam();
        public abstract int TounmanetsHosted();

    }
}
