using System.Collections.Generic;

namespace Money_Manager.Models
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Get();
        T GetById(int id);
        void Create(T entity);
        void Delete(int id);
        void Update(T entity);
        void Save();
    }
}
