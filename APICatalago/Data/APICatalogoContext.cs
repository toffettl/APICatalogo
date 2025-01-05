using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APICatalago.Models;

namespace APICatalago.Data
{ 
    public class APICatalogoContext : DbContext
    {
        public APICatalogoContext (DbContextOptions<APICatalogoContext> options)
            : base(options)
        {
        }

        public DbSet<APICatalago.Models.Produto> Produtos { get; set; } = default!;
        public DbSet<APICatalago.Models.Categoria> Categorias { get; set; } = default!;
    }
}
