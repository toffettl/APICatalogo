using APICatalago.Data;

namespace APICatalogo.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IProdutoRepository? _produtoRepo;

        private ICategoriaRepository? _categoriaRepo;

        public APICatalogoContext _context;

        public UnitOfWork(APICatalogoContext context)
        {
            _context = context;
        }

        public IProdutoRepository ProdutoRepository
        {
            get
            {
                if(_produtoRepo == null)
                {
                    _produtoRepo = new ProdutoRepository(_context);
                }

                return _produtoRepo;
            }
        }
        public ICategoriaRepository CategoriaRepository
        {
            get
            {
                if (_categoriaRepo == null)
                {
                    _categoriaRepo = new CategoriaRepository(_context);
                }

                return _categoriaRepo;
            }
        }
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
