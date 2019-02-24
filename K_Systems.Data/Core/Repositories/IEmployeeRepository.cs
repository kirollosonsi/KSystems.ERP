using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using K_Systems.Data.Core.Domain;

namespace K_Systems.Data.Core.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        IEnumerable<Employee> GetByName(TablePageInfo tablePage, out int totalPages);
        IEnumerable<Employee> FullSearch(TablePageInfo tablePage, out int totalPages);
        Employee GetByIdInclude(int id);
        bool LogicalDelete(int id);
        object GetNames(string term);
        int Count();
        int Salaries();
    }
}
