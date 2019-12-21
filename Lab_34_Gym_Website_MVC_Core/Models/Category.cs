namespace Lab_34_Gym_Website_MVC_Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Category")]
    public partial class Category
    {
        public Category()
        {
            Exercises = new HashSet<Exercise>();
        }

        public int CategoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string CategoryName { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
