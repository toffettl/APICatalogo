using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APICatalago.Models;

namespace APICatalago.Data
{ 
    public class APICatalagoContext : DbContext
    {
        public APICatalagoContext (DbContextOptions<APICatalagoContext> options)
            : base(options)
        {
        }

        public DbSet<APICatalago.Models.Produto> Produto { get; set; } = default!;
        public DbSet<APICatalago.Models.Categoria> Categoria { get; set; } = default!;
    }
}
