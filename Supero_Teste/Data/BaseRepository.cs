using System.Linq;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> collection;
        private readonly Context context;

        public BaseRepository(Context context)
        {
            this.context = context;
            collection = context.Set<T>();
        }

        public T Add(T entity)
        {
            return collection.Add(entity).Entity;
        }

        public IQueryable<T> GetAll()
        {
            return collection;
        }

        public T GetById(object id)
        {
            return collection.Find(id);
        }

        public void Delete(T entity)
        {
            collection.Remove(entity);
        }

        public void Delete(object id)
        {
            Delete(GetById(id));
        }

        public void DeleteRange(T[] entities)
        {
            collection.RemoveRange(entities);
        }

        public T Update(T entity)
        {
            return collection.Update(entity).Entity;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
