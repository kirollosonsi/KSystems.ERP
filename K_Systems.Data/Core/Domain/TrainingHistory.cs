namespace K_Systems.Data.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TrainingHistory")]
    public partial class TrainingHistory
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int employeeID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int courseID { get; set; }

        [Column(Order = 2, TypeName = "date")]
        [Display(Name = "Course Date")]
        public DateTime trainingDate { get; set; }

        [StringLength(50)]
        [Display( Name ="Course Result")]
        public string result { get; set; }

        [Display(Name = "Course Name")]
        public virtual Course Course { get; set; }

        [Display( Name ="Employee Name")]
        public virtual Employee Employee { get; set; }
    }
}
