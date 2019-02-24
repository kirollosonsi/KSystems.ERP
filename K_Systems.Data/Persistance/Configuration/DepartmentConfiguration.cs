using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using K_Systems.Data.Core.Domain;

namespace K_Systems.Data.Persistance.Configuration
{
    class DepartmentConfiguration:EntityTypeConfiguration<Department>
    {
        public DepartmentConfiguration()
        {

            HasMany(e => e.EmployeeJobAssignments)
                .WithRequired(e => e.Department)
                .WillCascadeOnDelete(false);

            HasMany(e => e.Jobs)
                .WithRequired(e => e.Department)
                .WillCascadeOnDelete(false);

        }
    }
}
