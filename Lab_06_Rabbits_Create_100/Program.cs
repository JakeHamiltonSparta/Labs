using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Collections.Generic;
using System.Linq;
using RandomNameGeneratorLibrary;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace Lab_06_Rabbits_Create_100
{
    class Program
    {
        public static List<Rabbit> rabbits = new List<Rabbit>();
        static void Main(string[] args)
        {
            using (var db = new RabbitDbContext())
            {
                //for (int i = 0; i < 99; i++)
                //{
                //    Rabbit r = NewRabbit();
                //    db.Add(r);
                //}
                //db.SaveChanges();
                //rabbits = db.RabbitsTable.ToList();
                while (true)
                {
                    rabbits = listRabbits(db);
                    updateRabbit(db);
                    addRabbit(db);

                    rabbits = listRabbits(db);
                    PrintRabbit(rabbits);
                }
                

            }

        }

        public static List<Rabbit> listRabbits(RabbitDbContext db)
        {
                return db.RabbitsTable.ToList();
        }

        static void updateRabbit(DbContext db)
        {
                //var rabbitToUpdate = db.RabbitsTable.Find(1);
                //rabbitToUpdate.RabbitName = "Rabbit has a new name";

                foreach (Rabbit i in rabbits)
                {
                    i.RabbitAge++;
                }
                db.SaveChanges();

        }

        static void addRabbit(DbContext db)
        {
            foreach (Rabbit i in rabbits)
            {
                if (i.RabbitAge > 2)
                {
                    Rabbit r = NewRabbit();
                    db.Add(r);
                }
            }
            db.SaveChanges();
        }
        
        static Rabbit NewRabbit()
        {
            var rn = new PersonNameGenerator();
            Rabbit r = new Rabbit()
            {
                RabbitName = rn.GenerateRandomFirstName(),
                RabbitAge = 0
            };
            return r;
        }

        public static void PrintRabbit(List<Rabbit> rabbits)
        {
            rabbits.ForEach(r =>
            Console.WriteLine($"{r.RabbitID,-15}{r.RabbitName,-15}{r.RabbitAge,-15}"));
                
        }
    }

    #region Rabbit.cs
    class Rabbit
    {
        public Rabbit() { }
        public Rabbit(string RabbitName, int RabbitAge)
        {
            this.RabbitName = RabbitName;
            this.RabbitAge = RabbitAge;
        }
        public int RabbitID { get; set; }
        public string RabbitName { get; set; }
        public int RabbitAge { get; set; }
    }
    #endregion

    #region RabbitDbContext
    // Connects to the database
    class RabbitDbContext : DbContext 
    {
        public DbSet<Rabbit> RabbitsTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Rabbits;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            builder.UseSqlServer(connectionString);
        }


    }

}
    #endregion

