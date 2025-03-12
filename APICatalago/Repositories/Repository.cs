    using System.Linq.Expressions;
using APICatalago.Data;
using Microsoft.EntityFrameworkCore;


namespace APICatalogo.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly APICatalogoContext _context;

        public Repository(APICatalogoContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync(); //set acessa uma tabela correspondente ao tipo T /AsNoTracking() deixa mais leve
        }
        public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }
        public T Create(T entity)
        {
            _context.Set<T>().Add(entity);

            return entity;
        }
        public T Update(T entity)
        {
            _context.Set<T>().Update(entity);

            return entity;
        }
        public T Delete(T entity)
        {
            _context.Set<T>().Remove(entity);

            return entity;
        }
    }
}
