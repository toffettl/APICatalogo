using APICatalago.Data;
using APICatalago.Models;

namespace APICatalogo.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly APICatalogoContext _context;

        public ProdutoRepository(APICatalogoContext context)
        {
            _context = context;
        }

        public IQueryable<Produto> GetProdutos()
        {
            return _context.Produto;
        }

        public Produto GetProduto(int id)
        {
            var produto = _context.Produto.FirstOrDefault(p => p.ProdutoId == id);
            if(produto == null)
            {
                throw new InvalidOperationException("O produto é null!");
            }

            return produto;
        }
        public Produto Create(Produto produto)
        {
            if (produto == null)
            {
                throw new InvalidOperationException("O produto é null!");
            }

            _context.Produto.Add(produto);
            _context.SaveChanges();

            return produto;
        }
        public bool Update(Produto produto)
        {
            if (produto == null)
            {
                throw new InvalidOperationException("O produto é null!");
            }

            if(_context.Produto.Any(p => p.ProdutoId == produto.ProdutoId))
            {
                _context.Produto.Update(produto);
                _context.SaveChanges();

                return true;
            }

            return false;
        }
        public bool Delete(int id)
        {
            var produto = _context.Produto.Find(id);

            if(produto != null)
            {
                _context.Produto.Remove(produto);
                _context.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
