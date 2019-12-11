using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Money_Manager.Models
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Get(Expression<Func<T, bool>> filter);

        T GetById(int id);

        void Create(T entity);

        void Delete(int id);

        void Update(T entity);

        void Save();
    }
}
