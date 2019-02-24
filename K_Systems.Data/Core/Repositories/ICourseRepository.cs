using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using K_Systems.Data.Core.Domain;

namespace K_Systems.Data.Core.Repositories
{
    public interface ICourseRepository : IRepository<Course>
    {
        IEnumerable<Course> GetByName(string search, int items, string sortBy, string order, int page, out int totalPages);
        object GetNames(string term);
    }
}
