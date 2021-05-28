using LibraryManagement.Data;
using LibraryManagement.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LibraryManagement.Repository.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ApplicationDbContext DbContext { get; set; }

        public RepositoryBase(ApplicationDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public virtual IQueryable<T> FindAll()
        {
            return DbContext.Set<T>().AsNoTracking();
        }

        public virtual IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return DbContext.Set<T>().Where(expression).AsNoTracking();
        }

        public virtual void Create(T entity)
        {
            DbContext.Set<T>().Add(entity);
        }

        public virtual void Update(T entity)
        {
            DbContext.Set<T>().Update(entity);
        }

        public virtual void Delete(T entity)
        {
            DbContext.Set<T>().Remove(entity);
        }

        public virtual void Save()
        {
            DbContext.SaveChanges();
        }

        public virtual void Reload(T entity)
        {
            DbContext.Entry(entity).Reload();
        }
    }
}
