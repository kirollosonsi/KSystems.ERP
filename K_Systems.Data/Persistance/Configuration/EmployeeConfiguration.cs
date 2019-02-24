using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using K_Systems.Data.Core.Domain;

namespace K_Systems.Data.Persistance.Configuration
{
    class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            Property(e => e.email)
                .IsUnicode(false);

            Property(e => e.phone)
                .IsUnicode(false);

            HasMany(e => e.EmployeeJobAssignments)
                .WithRequired(e => e.Employee)
                .HasForeignKey(e => e.employeeID)
                .WillCascadeOnDelete(false);

            HasMany(e => e.EmployeeSkills)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            HasMany(e => e.EmployeeVacations)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            HasMany(e => e.PerformanceReviews)
                .WithRequired(e => e.Employee)
                .HasForeignKey(e => e.employeeID)
                .WillCascadeOnDelete(false);

            HasMany(e => e.TrainingHistories)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

        }
    }
}
