namespace Lab_34_Gymdatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Exercise")]
    public partial class Exercise
    {
        public int ExerciseId { get; set; }

        [Required]
        [StringLength(50)]
        public string ExerciseName { get; set; }

        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
