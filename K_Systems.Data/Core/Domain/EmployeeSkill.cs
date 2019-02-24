namespace K_Systems.Data.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EmployeeSkill
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int employeeID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int skillID { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "date")]
        public DateTime skillDate { get; set; }

        public int? skillLevelCode { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Skill Skill { get; set; }

        public virtual SkillLevel SkillLevel { get; set; }
    }
}
