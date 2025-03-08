using System.Linq.Expressions;
using APICatalago.Data;


namespace APICatalogo.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly APICatalogoContext _context;

        public Repository(APICatalogoContext context)
        {
            _context = context;
        }
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList(); //set acessa uma tabela correspondente ao tipo T
        }
        public T? Get(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }
        public T Create(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();

            return entity;
        }
        public T Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges ();

            return entity;
        }
        public T Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();

            return entity;
        }
    }
}
