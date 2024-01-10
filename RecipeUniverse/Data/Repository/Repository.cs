using Microsoft.EntityFrameworkCore;
using RecipeUniverse.Areas.Identity.Data;
using RecipeUniverse.Data.Repository.IRepository;
using System.Linq.Expressions;

namespace RecipeUniverse.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly RecipeUniverseContext _db;
        internal DbSet<T> DbSet;

        public Repository(RecipeUniverseContext db)
        {
            _db = db;
            DbSet = _db.Set<T>();

        }
        public void Add(T entity)
        {
            DbSet.AddAsync(entity);
        }

        public async Task<IEnumerable<T>> GetAllByUserAsync(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
        {

            IQueryable<T> query = DbSet;
            query = query.Where(filter);
            return await query.FirstOrDefaultAsync();

        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public void DeleteAll(IEnumerable<T> entity)
        {
            DbSet.RemoveRange(entity);
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            IQueryable<T> query = DbSet;
            return await query.ToListAsync();
        }

    }
}