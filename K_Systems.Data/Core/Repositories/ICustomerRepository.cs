using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using K_Systems.Data.Core.Domain;

namespace K_Systems.Data.Core.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        object GetNames(string term);
    }
}
