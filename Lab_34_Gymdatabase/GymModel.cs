namespace Lab_34_Gymdatabase
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class GymModel : DbContext
    {
        public GymModel()
            : base("name=GymModel")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Exercise> Exercises { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.CategoryName)
                .IsUnicode(false);

            modelBuilder.Entity<Exercise>()
                .Property(e => e.ExerciseName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);
        }
    }
}
