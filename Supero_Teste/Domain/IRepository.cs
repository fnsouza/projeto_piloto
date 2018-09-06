using System;
using System.Linq;

namespace Domain
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IQueryable<T> GetAll();

        T GetById(object id);

        T Add(T entity);

        void Delete(T entity);

        void Delete(object id);

        void DeleteRange(T[] entities);

        T Update(T entity);

        void SaveChanges();
    }
}
