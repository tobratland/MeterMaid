using MeterMaid3.Contracts;
using MeterMaid3.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MeterMaid3.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected AppDbContext appDbContext { get; set; }
        public RepositoryBase(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.appDbContext.Set<T>().Where(expression).AsNoTracking();
        }

        public IQueryable<T> FindAll()
        {
            return this.appDbContext.Set<T>();
        }
        public void Create(T entity)
        {
            this.appDbContext.Set<T>().Add(entity);
        }
        public void Delete(T entity)
        {
            this.appDbContext.Set<T>().Remove(entity);
        }
    }
}
