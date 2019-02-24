using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using K_Systems.Data.Core;
using K_Systems.Data.Core.Domain;
using K_Systems.Data.Core.Repositories;
using K_Systems.Data.Persistance;
using K_Systems.Data.Persistance.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace K_Systems.Data.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ERPModel _ctx;

        public UnitOfWork(IdentityDbContext dbContext)
        {
            _ctx = dbContext as ERPModel;
        }

        private IEmployeeJobAssignmentRepository employeeJobAssignments;
        public IEmployeeJobAssignmentRepository EmployeeJobAssignments
        {
            get
            {
                if (employeeJobAssignments == null)
                    employeeJobAssignments = new EmployeeJobAssignmaneRepository(_ctx);
                return employeeJobAssignments;
            }
        }

        private IEmployeeRepository employees;
        public IEmployeeRepository Employees
        {
            get
            {
                if (employees == null)
                    employees = new EmployeeRepository(_ctx);
                return employees;
            }
        }

        private IEmployeeSkillsRepository employeeSkills;
        public IEmployeeSkillsRepository EmployeeSkills
        {
            get
            {
                if (employeeSkills == null)
                    employeeSkills = new EmployeeSkillRepository(_ctx);
                return employeeSkills;
            }
        }

        public IEmployeeVacationRepository employeeVacations;
        public IEmployeeVacationRepository EmployeeVacations
        {
            get
            {
                if (employeeVacations == null)
                    employeeVacations = new  EmployeeVacationRepository(_ctx);
                return employeeVacations;
            }
        }

        public IJobRepository jobs;
        public IJobRepository Jobs
        {
            get
            {
                if (jobs == null)
                    jobs = new JobRepository(_ctx);
                return jobs;
            }
        }

        public ITrainingHistoryRepository trainingHistories ;
        public ITrainingHistoryRepository TrainingHistories
        {
            get
            {
                if (trainingHistories == null)
                    trainingHistories = new TrainingHistoryRepository(_ctx);
                return trainingHistories;
            }
        }

        public ICountryRepository countries ;
        public ICountryRepository Countries
        {
            get
            {
                if (countries == null)
                    countries = new CountryRepository(_ctx);
                return countries;
            }
        }

        public ICityRepository cities ;
        public ICityRepository Cities
        {
            get
            {
                if (cities == null)
                    cities = new CityRepository(_ctx);
                return cities;
            }
        }

        public IDepartmentRepository departments;
        public IDepartmentRepository Departments
        {
            get
            {
                if (departments == null)
                    departments = new DepartmentRepository(_ctx);
                return departments;
            }
        }

        public ICourseRepository courses;
        public ICourseRepository Courses
        {
            get
            {
                if (courses == null)
                    courses = new CourseRepository(_ctx);
                return courses;
            }
        }

        public IperformanceReviewRepository performanceReviews;
        public IperformanceReviewRepository PerformanceReviews
        {
            get
            {
                if (performanceReviews == null)
                    performanceReviews = new PerformanceReviewRepository(_ctx);
                return performanceReviews;
            }
        }

        public ISkillLevelRepository skillLevels ;
        public ISkillLevelRepository SkillLevels
        {
            get
            {
                if (skillLevels == null)
                    skillLevels = new SkillLevelRepository(_ctx);
                return skillLevels;
            }
        }

        public ISkillRepository skills;
        public ISkillRepository Skills
        {
            get
            {
                if (skills == null)
                    skills = new SkillRepository(_ctx);
                return skills;
            }
        }

        public IProductRepository products;
        public IProductRepository Products
        {
            get
            {
                if (products == null)
                    products = new ProductRepository(_ctx);
                return products;
            }
        }

        public ICategoryRepository categories;
        public ICategoryRepository Categories
        {
            get
            {
                if (categories == null)
                    categories = new CategoryRepository(_ctx);
                return categories;
            }
        }

        public ISupplierRepository suppliers;
        public ISupplierRepository Suppliers
        {
            get
            {
                if (suppliers == null)
                    suppliers = new SupplierRepository(_ctx);
                return suppliers;
            }
        }

        public IOrderRepository orders;
        public IOrderRepository Orders
        {
            get
            {
                if (orders == null)
                    orders = new OrderRepository(_ctx);
                return orders;
            }
        }

        public IOrderDetailRepository orderDetails;
        public IOrderDetailRepository OrderDetails
        {
            get
            {
                if (orderDetails == null)
                    orderDetails = new OrderDetailRepository(_ctx);
                return orderDetails;
            }
        }

        public ICustomerRepository customers;
        public ICustomerRepository Customers
        {
            get
            {
                if (customers == null)
                    customers = new CustomerRepository(_ctx);
                return customers;
            }
        }

        public UserManager<UserERP> userManager;
        public UserManager<UserERP> UserManager
        {
            get
            {
                if (userManager == null)
                    userManager = new UserManager<UserERP>(UserStore);
                return userManager;
            }
        }

        public IUserStore<UserERP> userStore;
        public IUserStore<UserERP> UserStore
        {
            get
            {
                if (userStore == null)
                    userStore = new UserStore<UserERP>(_ctx);
                return userStore;
            }
        }


        //UserManager<UserERP> IUnitOfWork.userManager => throw new NotImplementedException();

        //public IUserStore<UserERP> userStore ;

        public int SaveChanges()
        {
            return _ctx.SaveChanges();
        }
    }
}
