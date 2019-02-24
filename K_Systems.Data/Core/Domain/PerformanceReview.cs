namespace K_Systems.Data.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PerformanceReview")]
    public partial class PerformanceReview
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int employeeID { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "date")]
        public DateTime reviewDate { get; set; }

        //public int? reviewerID { get; set; }

        [StringLength(300)]
        public string reviewerComment { get; set; }

        [StringLength(300)]
        public string employeeComment { get; set; }

        public virtual Employee Employee { get; set; }

        //public virtual Employee Employee1 { get; set; }
    }
}
