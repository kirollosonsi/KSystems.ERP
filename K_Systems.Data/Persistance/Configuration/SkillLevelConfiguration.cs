using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using K_Systems.Data.Core.Domain;

namespace K_Systems.Data.Persistance.Configuration
{
    class SkillLevelConfiguration : EntityTypeConfiguration<SkillLevel>
    {
        public SkillLevelConfiguration()
        {
            HasMany(e => e.EmployeeSkills)
                .WithOptional(e => e.SkillLevel)
                .HasForeignKey(e => e.skillLevelCode);
        }
    }
}
