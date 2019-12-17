using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MoneyManager.Models
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        protected MoneyContext context;
        protected DbSet<T> dbSet;

        public GenericRepository(MoneyContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public virtual void Create(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(int id)
        {
            T entity = dbSet.Find(id);
            dbSet.Remove(entity);
        }

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return query.ToList();
        }

        public virtual T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual void Save()
        {
            context.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            dbSet.Update(entity);
        }
    }
}
