using Microsoft.EntityFrameworkCore;

namespace Brazilla.EntityFramework.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        DbContext _context;
        public DbSet<T> Table { get; set; }

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            Table = context.Set<T>();
        }

        public List<T> GetAll()
        {
            return Table.AsNoTracking().ToList();
        }
        public List<T> Get(Func<T, bool> predicate)
        {
            return Table.AsNoTracking().Where(predicate).ToList();
        }
        public T FindById(long id)
        {
            return Table.Find(id);
        }

        public void Create(T item)
        {
            Table.Add(item);
            _context.SaveChanges();
        }
        public void Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Remove(T item)
        {
            Table.Remove(item);
            _context.SaveChanges();
        }
    }
}