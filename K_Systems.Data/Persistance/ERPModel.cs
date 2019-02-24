using K_Systems.Data.Core.Domain;

namespace K_Systems.Data.Persistance
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using K_Systems.Data.Persistance.Configuration;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;

    public partial class ERPModel : IdentityDbContext
    {
        public ERPModel()
            : base("name=ModelERP")
        {
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeJobAssignment> EmployeeJobAssignments { get; set; }
        public virtual DbSet<EmployeeSkill> EmployeeSkills { get; set; }
        public virtual DbSet<EmployeeVacation> EmployeeVacations { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<PerformanceReview> PerformanceReviews { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<SkillLevel> SkillLevels { get; set; }
        public virtual DbSet<TrainingHistory> TrainingHistories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        //public virtual DbSet<UserERP> UsersERP { get; set; }
        //public virtual DbSet<RoleERP> RolesERP { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EmployeeConfiguration());
            modelBuilder.Configurations.Add(new DepartmentConfiguration());
            modelBuilder.Configurations.Add(new CourseConfiguration());
            modelBuilder.Configurations.Add(new SkillConfiguartion());
            modelBuilder.Configurations.Add(new SkillLevelConfiguration());

            modelBuilder.Entity<Product>().Property(p => p.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Category>().Property(p => p.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Supplier>().Property(p => p.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Customer>().Property(p => p.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Order>().Property(p => p.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


            //modelBuilder.Entity<IdentityUserRole>()
            //    .ToTable("UserInRole")
            //    .Property(p => p.RoleId).HasColumnName("RoleId");

            //modelBuilder.Entity<IdentityUserRole>()
            //    .Property(p => p.UserId).HasColumnName("UserId");

            //modelBuilder.Entity<IdentityUserRole>()
            //    .HasKey(k => new { k.RoleId, k.UserId });

            //modelBuilder.Entity<IdentityUserRole>().Map(
            //    m =>
            //    {
            //        m.ToTable("UserInRole");
            //        m.Property(p => p.RoleId).HasColumnName("RoleId");
            //        m.Property(p => p.UserId).HasColumnName("UserId");
            //    }).HasKey(k => new { k.RoleId, k.UserId })
            //     .HasRequired(e => e.RoleId)
            //     .WithRequiredDependent(c => c.)
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<IdentityUserRole>()
                .ToTable("UserInRole");
            //.HasKey(k => new { k.RoleId, k.UserId })
            //.HasRequired(r => r.RoleId)
            //.WithRequiredDependent();


            modelBuilder.Entity<IdentityUserLogin>()
                .ToTable("UserInLogin");
            //.HasKey(k => new { k.UserId, k.LoginProvider, k.ProviderKey });

            modelBuilder.Entity<IdentityUser>()
                .ToTable("UserERP");
            //.HasKey(k => k.Id);

            modelBuilder.Entity<IdentityRole>()
                .ToTable("Role");
            //.HasKey(k => k.Id);

            modelBuilder.Entity<IdentityUserClaim>()
                .ToTable("UserClaim");
            //.HasKey(k => k.Id);


        }


    }
}
