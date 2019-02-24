using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using K_Systems.Data.Core.Domain;

namespace K_Systems.Data.Persistance.Configuration
{
    class SkillConfiguartion : EntityTypeConfiguration<Skill>
    {
        public SkillConfiguartion()
        {
            HasMany(e => e.EmployeeSkills)
                 .WithRequired(e => e.Skill)
                 .WillCascadeOnDelete(false);
        }
    }
}
