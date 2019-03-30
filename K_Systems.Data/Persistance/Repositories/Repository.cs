using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using K_Systems.Data.Core.Repositories;

namespace K_Systems.Data.Persistance.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext ctx;
        protected DbContext Ctx => (ERPModel)ctx;

        public Repository(DbContext dbContext)
        {
            ctx = dbContext;
        }


        public TEntity Add(TEntity entity)
        {

            Ctx.Set<TEntity>().Add(entity);
            return entity;
        }

        public bool Delete(params object[] id)
        {
            TEntity entity = Ctx.Set<TEntity>().Find(id);
            if (entity == null)
                return false;

            Ctx.Set<TEntity>().Remove(entity);
            return true;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Ctx.Set<TEntity>().ToList();
        }

        public TEntity GetById(params object[] id)
        {
            DbSet<TEntity> dd = Ctx.Set<TEntity>();
            return dd.Find(id);
        }

        public TEntity Update(TEntity entity)
        {
            Ctx.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
