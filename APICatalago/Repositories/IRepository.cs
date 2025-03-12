using System.Linq.Expressions;

namespace APICatalogo.Repositories
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate); //get por id expecifico
        T Create(T entity);
        T Update(T entity);
        T Delete(T entity);
    }
}
