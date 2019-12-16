namespace Lab_26_MVC_Again_Again
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SpartansTable")]
    public partial class SpartansTable
    {
        [Key]
        public int PersonID { get; set; }

        [StringLength(255)]
        public string Title { get; set; }

        [StringLength(255)]
        public string LastName { get; set; }

        [StringLength(255)]
        public string FirstName { get; set; }

        [StringLength(255)]
        public string University { get; set; }

        [StringLength(255)]
        public string Course { get; set; }

        [StringLength(255)]
        public string GradeAchieved { get; set; }

        [StringLength(255)]
        public string SpartanTutor { get; set; }
    }
}
