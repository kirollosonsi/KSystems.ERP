using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using K_Systems.Data.Core.Domain;
using K_Systems.Data.Core.Repositories;

namespace K_Systems.Data.Persistance.Repositories
{
    class CustomerRepository:Repository<Customer>,ICustomerRepository
    {
        public CustomerRepository(ERPModel ctx):base(ctx)
        {

        }

        public object GetNames(string term)
        {
            var context = Ctx as ERPModel;
            return context
                 .Customers
                 .Where(e => e.name.ToLower().Contains(term.ToLower()))
                 .Take(5)
                 .OrderBy(o => o.name)
                 .Select(e => new { label = e.name, value = e.ID });
        }
    }
}
