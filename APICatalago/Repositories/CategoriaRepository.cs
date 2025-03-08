using APICatalago.Data;
using APICatalago.Models;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly APICatalogoContext _context;

        public CategoriaRepository(APICatalogoContext context)
        {
            _context = context;
        }
        public IEnumerable<Categoria> GetCategorias()
        {
            return _context.Categoria.ToList();
        }
        public Categoria GetCategoria(int id)
        {
            return _context.Categoria.FirstOrDefault(c => c.CategoriaId == id);
        }
        public Categoria Create(Categoria categoria)
        {
            if(categoria == null)
            {
                throw new ArgumentNullException(nameof(categoria));
            }

            _context.Categoria.Add(categoria);
            _context.SaveChanges();

            return categoria;
        }
        public Categoria Update(Categoria categoria)
        {
            if (categoria == null)
            {
                throw new ArgumentNullException(nameof(categoria));
            }

            _context.Entry(categoria).State = EntityState.Modified;
            _context.SaveChanges();

            return categoria;
        }
        public Categoria Delete(int id)
        {
            var categoria = _context.Categoria.Find(id); //Find para chave primaria

            if(categoria == null)
            {
                throw new ArgumentException(nameof(categoria));
            }

            _context.Categoria.Remove(categoria);
            _context.SaveChanges();

            return categoria;
        }
    }
}
