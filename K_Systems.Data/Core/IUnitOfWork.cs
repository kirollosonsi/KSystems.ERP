using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using K_Systems.Data.Core.Domain;
using K_Systems.Data.Core.Repositories;
using Microsoft.AspNet.Identity;

namespace K_Systems.Data.Core
{
    public interface IUnitOfWork
    {
        IEmployeeJobAssignmentRepository EmployeeJobAssignments { get; }
        IEmployeeRepository Employees { get; }
        IEmployeeSkillsRepository EmployeeSkills { get; }
        IEmployeeVacationRepository EmployeeVacations { get; }
        IJobRepository Jobs { get; }
        ITrainingHistoryRepository TrainingHistories { get; }
        ICountryRepository Countries { get; }
        ICityRepository Cities { get; }
        IDepartmentRepository Departments { get; }
        ICourseRepository Courses { get; }
        IperformanceReviewRepository PerformanceReviews { get; }
        ISkillLevelRepository SkillLevels { get; }
        ISkillRepository Skills { get; }
        IProductRepository Products { get; }
        ISupplierRepository Suppliers { get; }
        ICategoryRepository Categories { get; }
        ICustomerRepository Customers { get; }
        IOrderRepository Orders { get; }
        IOrderDetailRepository OrderDetails { get; }
        UserManager<UserERP> UserManager { get; }
        IUserStore<UserERP> UserStore { get; }
        int SaveChanges();
    }
}
