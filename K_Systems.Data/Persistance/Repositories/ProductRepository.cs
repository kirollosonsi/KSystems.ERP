using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using K_Systems.Data.Core.Domain;
using K_Systems.Data.Core.Repositories;
using System.Data.Entity;

namespace K_Systems.Data.Persistance.Repositories
{
    class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ERPModel ctx) : base(ctx)
        {

        }

        public IEnumerable<Product> GetAllWithCatSup()
        {
            var context = Ctx as ERPModel;
            return context.Products
                .Include(p => p.category)
                .Include(p => p.supplier).ToList();
        }

        public object GetNames(string term)
        {
            var context = Ctx as ERPModel;
            return context
                 .Products
                 .Where(e => e.name.ToLower().Contains(term.ToLower()))
                 .Take(5)
                 .OrderBy(o => o.name)
                 .Select(e => new { label = e.name, value = e.ID, price = e.price });
        }
    }
}
