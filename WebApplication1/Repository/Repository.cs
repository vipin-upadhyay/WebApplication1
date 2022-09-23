using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApplication1.Data;
using WebApplication1.Repository.IRepository;

namespace WebApplication1.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public readonly AppDbContext _appDbContext;
        internal DbSet<T> dbSet;
        public Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            this.dbSet = _appDbContext.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query= dbSet;
            query= query.Where(filter);
            return query.FirstOrDefault();
        }
     
        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}
