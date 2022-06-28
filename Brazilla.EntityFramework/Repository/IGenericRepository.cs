using Microsoft.EntityFrameworkCore;

namespace Brazilla.EntityFramework.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        public DbSet<T> Table { get; set; }

        void Create(T item);
        T FindById(long id);
        List<T> GetAll();
        List<T> Get(Func<T, bool> predicate);
        void Remove(T item);
        void Update(T item);
    }
}