using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using K_Systems.Data.Core.Domain;
using K_Systems.Data.Core.Repositories;
using System.Data.Entity;
using System.Reflection;
using System.Linq.Expressions;
using System.ComponentModel;
using System.Data.SqlClient;
using System.IO;

namespace K_Systems.Data.Persistance.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ERPModel ctx) : base(ctx)
        { }

        public int Count()
        {
            var context = Ctx as ERPModel;
            return context.Employees.Count();
        }

        public Employee GetByIdInclude(int id)
        {
            var context = Ctx as ERPModel;
            return context.Employees.Include(e => e.EmployeeJobAssignments).Include(e => e.EmployeeSkills).FirstOrDefault(e => e.ID == id);
        }

        public IEnumerable<Employee> GetByName(TablePageInfo pageInfo, out int totalPages)
        {
            var x = 10;
            var context = Ctx as ERPModel;
            string search = !string.IsNullOrEmpty(pageInfo.search) ?
                pageInfo.search.ToLower() : string.Empty;

            IQueryable<Employee> employees = context
                .Employees
                .Where(e => (e.fName + " " + e.lName)
                .ToLower()
                .Contains(search));

            PropertyDescriptor prop = TypeDescriptor
                .GetProperties(typeof(Employee))
                .Find(pageInfo.sortBy, true);
            //Type proptype1 = typeof(prop.GetType());

            switch (pageInfo.order)
            {
                case "dsc":
                    //employees = employees.OrderByDescending(e => e.ID);
                    employees = employees.MyOrderBy("fName");
                    break;
                default:
                    //employees = employees.OrderBy(e => e.ID);
                    employees = employees.MyOrderByDescending("fName");
                    //employees = employees.OrderBy(e => prop.GetValue(e));
                    break;
            }

            totalPages = (int)Math.Ceiling((double)employees.Count() / pageInfo.items.Value);

            employees = employees
                .Skip((pageInfo.page.Value - 1) * pageInfo.items.Value)
                            .Take(pageInfo.items.Value);

            return employees.ToList();
        }

        private static Expression<Func<T, object>> ToLambda<T>(string propertyName)
        {
            Type propt = typeof(T)
                    .GetProperties()
                    .FirstOrDefault(p => p.Name == propertyName)
                    .GetType();

            var parameter = Expression.Parameter(typeof(T));
            var property = Expression.Property(parameter, propertyName);
            var propAsObject = Expression.Convert(property, propt);

            return Expression.Lambda<Func<T, object>>(propAsObject, parameter);
        }


        //private Expression<Func<T, object>> GetSortingKey<T>(string sortByProperty)
        //{

        //    Func<T, object> func1 = t =>
        //  {
        //      PropertyInfo propIn = t.GetType().GetProperty(sortByProperty);

        //      if (propIn == null)
        //          return t.GetType().GetProperties()
        //          .FirstOrDefault(p => p.Name.ToLower().Contains("id")).GetValue(t);

        //      return propIn.GetValue(t);
        //  };
        //    return Expression<func1>;

        //    //return Expression.Lambda<Func<T, object>>(Expression.Call(func.Method));
        //}

        //private static object NewMethod(TablePageInfo pageInfo, Employee e)
        //{
        //    PropertyInfo t = e.GetType().GetProperty(pageInfo.sortBy);
        //    if (t == null)
        //        return e.ID;
        //    return t.GetValue(e);
        //}

        public object GetNames(string term)
        {
            var context = Ctx as ERPModel;
            return context
                 .Employees
                 .Where(e => (e.fName + " " + e.lName).ToLower().Contains(term.ToLower()))
                 .Take(5)
                 .OrderBy(o => o.fName)
                 .Select(e => new { label = e.fName + " " + e.lName, value = e.ID });
        }

        public bool LogicalDelete(int id)
        {
            var context = Ctx as ERPModel;
            Employee emp = context.Employees.FirstOrDefault(e => e.ID == id);

            if (emp == null)
                return false;

            emp.isDeleted = true;
            context.SaveChanges();

            return true;
        }

        public int Salaries()
        {
            var context = Ctx as ERPModel;
            return context.Employees.Sum(e => e.salary) ?? 0;
        }

        //public IEnumerable<Employee> FullSearch(TablePageInfo pageInfo, out int totalPages)
        //{
        //    var context = Ctx as ERPModel;
        //    context.Database.ExecuteSqlCommand()
        //}

        public IEnumerable<Employee> FullSearch(TablePageInfo pageInfo, out int totalPages)
        {
            var context = Ctx as ERPModel;
            SqlParameter outParam = new SqlParameter
            {
                ParameterName = "totalPages",
                Value = 0,
                Direction = System.Data.ParameterDirection.Output
            };
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@name",pageInfo.search ?? string.Empty),
                new SqlParameter("@address",""),
                new SqlParameter("@phone",""),
                new SqlParameter("@orderBy",pageInfo.sortBy),
                new SqlParameter("@order",pageInfo.order),
                new SqlParameter("@items",pageInfo.items),
                new SqlParameter("@page",pageInfo.page),
                outParam
            };
            List<Employee> employees = context.Database.SqlQuery<Employee>("Exec FullSearch @name , @address , @phone , @orderBy , @order , @items , @page , @totalPages OUTPUT", sqlParameters).ToList();
            totalPages = (int)outParam.Value;
            return employees;
        }
    }

    public static class IQueryableExtensions
    {
        public static IOrderedQueryable<T> MyOrderBy<T>(this IQueryable<T> source, string propertyName)
        {
            Type tt = typeof(T).GetProperties().FirstOrDefault(p => p.Name.ToLower().Contains("id")).PropertyType;

            return source.OrderBy(ToLambda<T>(propertyName, tt));
        }

        public static IOrderedQueryable<T> MyOrderByDescending<T>(this IQueryable<T> source, string propertyName)
        {
            Type tt = typeof(T).GetProperties().FirstOrDefault(p => p.Name.ToLower().Contains("id")).PropertyType;
            return source.OrderByDescending(ToLambda<T>(propertyName, tt));
        }

        private static Expression<Func<T, object>> ToLambda<T>(string propertyName, Type propType)
        {

            if (string.IsNullOrEmpty(propertyName))
            {
                //Type tt =  typeof(T).GetProperties().FirstOrDefault(p => p.Name.ToLower().Contains("id")).PropertyType;

                propertyName = typeof(T).GetProperties().FirstOrDefault(p => p.Name.ToLower().Contains("id")).Name;
            }
            var parameter = Expression.Parameter(typeof(T));
            var property = Expression.Property(parameter, propertyName);
            var propAsObject = Expression.Convert(property, typeof(object));

            return Expression.Lambda<Func<T, object>>(property, parameter);
        }
    }
}
