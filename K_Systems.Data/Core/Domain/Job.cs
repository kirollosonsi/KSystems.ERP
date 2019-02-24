namespace K_Systems.Data.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Job")]
    public partial class Job
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Job()
        {
            EmployeeJobAssignments = new HashSet<EmployeeJobAssignment>();
        }

        [Key]
        public int code { get; set; }

        [StringLength(50)]
        public string title { get; set; }

        [StringLength(300)]
        public string description { get; set; }

        public int? maxSalary { get; set; }

        public int? minSalary { get; set; }

        public int departmentId { get; set; }

        public virtual Department Department { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeJobAssignment> EmployeeJobAssignments { get; set; }
    }
}
