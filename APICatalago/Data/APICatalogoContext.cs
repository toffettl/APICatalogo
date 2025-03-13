using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APICatalago.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using APICatalogo.Models;

namespace APICatalago.Data
{ 
    public class APICatalogoContext : IdentityDbContext<ApplicationUser>
    {
        public APICatalogoContext (DbContextOptions<APICatalogoContext> options)
            : base(options)
        {
        }

        public DbSet<APICatalago.Models.Produto>? Produto { get; set; } = default!;
        public DbSet<APICatalago.Models.Categoria>? Categoria { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
