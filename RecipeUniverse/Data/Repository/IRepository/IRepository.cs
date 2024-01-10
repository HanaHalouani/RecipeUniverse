using System.Linq.Expressions;

namespace RecipeUniverse.Data.Repository.IRepository;

public interface IRepository<T> where T : class
{
    void Add(T entity);
    Task<IEnumerable<T>> GetAllByUserAsync(Expression<Func<T, bool>> filter);

    Task<T> GetAsync(Expression<Func<T, bool>> filter);
    void Delete(T entity);
    void DeleteAll(IEnumerable<T> entity);
    Task<IEnumerable<T>> GetAllAsync();
}