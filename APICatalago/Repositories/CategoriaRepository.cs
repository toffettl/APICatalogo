using APICatalago.Data;
using APICatalago.Models;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Repositories
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        private readonly APICatalogoContext _context;

        public CategoriaRepository(APICatalogoContext context) : base(context)
        {
        }
    }
}
