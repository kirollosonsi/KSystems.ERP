namespace K_Systems.Data.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmployeeVacation")]
    public partial class EmployeeVacation
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int employeeID { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "date")]
        public DateTime startDate { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "date")]
        public DateTime endDate { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
