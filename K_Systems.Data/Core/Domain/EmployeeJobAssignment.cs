namespace K_Systems.Data.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmployeeJobAssignment")]
    public partial class EmployeeJobAssignment
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int employeeID { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "date")]
        public DateTime assignDate { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int departmentID { get; set; }

        public int? jobCode { get; set; }

        //public int? supervisorID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateFinish { get; set; }

        [StringLength(300)]
        public string detail { get; set; }

        public virtual Department Department { get; set; }

        public virtual Employee Employee { get; set; }

        //public virtual Employee Employee1 { get; set; }

        public virtual Job Job { get; set; }
    }
}
