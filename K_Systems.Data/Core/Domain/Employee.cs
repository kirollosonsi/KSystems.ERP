namespace K_Systems.Data.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public enum Gender
    {
        Male,
        Female
    }

    public enum IsMarried
    {
        None,
        Married,
        Single
    }


    [Table("Employee")]
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            //Employee1 = new HashSet<Employee>();
            EmployeeJobAssignments = new HashSet<EmployeeJobAssignment>();
            //EmployeeJobAssignments1 = new HashSet<EmployeeJobAssignment>();
            EmployeeSkills = new HashSet<EmployeeSkill>();
            EmployeeVacations = new HashSet<EmployeeVacation>();
            PerformanceReviews = new HashSet<PerformanceReview>();
            //PerformanceReviews1 = new HashSet<PerformanceReview>();
            TrainingHistories = new HashSet<TrainingHistory>();
            Orders = new HashSet<Order>();
        }

        public int ID { get; set; }

        [Required(ErrorMessage ="You must enter the {0}")]
        [StringLength(50)]
        [Display(Name ="First Name")]
        public string fName { get; set; }

        [Required(ErrorMessage = "You must enter the {0}")]
        [Display(Name ="Last Name")]
        [StringLength(50)]
        public string lName { get; set; }

        [Display(Name ="Gender")]
        public Gender gender { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Birth Date")]
        public DateTime dateOdBirth { get; set; }

        [Display(Name = "Joined Date")]
        [Column(TypeName = "date")]
        public DateTime joinedDate { get; set; }

        [Display(Name = "Left Date")]
        [Column(TypeName = "date")]
        public DateTime? leftDate { get; set; }

        [Display(Name = "Address")]
        [StringLength(100)]
        public string address { get; set; }

        [Display(Name = "E-mail")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress,ErrorMessage ="Enter a valid email address")]
        public string email { get; set; }

        [Display(Name = "Phone")]
        [StringLength(20)]
        public string phone { get; set; }

        [Display(Name = "Details")]
        [StringLength(300,ErrorMessage ="Max char length is 300 for the {0} field")]
        [DataType(DataType.MultilineText)]
        public string detail { get; set; }

        [Display(Name = "Salary")]
        public int? salary { get; set; }

        [Display(Name = "Marital Status")]
        public IsMarried isMarried { get; set; }

        [Display(Name = "Photo")]
        [StringLength(300)]
        public string img { get; set; }

        [Display(Name = "Deleted")]
        public bool? isDeleted { get; set; }

        [Display(Name = "Total OFF Days")]
        public int? maxOffDays { get; set; }



        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeJobAssignment> EmployeeJobAssignments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeSkill> EmployeeSkills { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeVacation> EmployeeVacations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PerformanceReview> PerformanceReviews { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrainingHistory> TrainingHistories { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

    }
}
