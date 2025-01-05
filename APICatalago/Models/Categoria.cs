using System.Collections.ObjectModel;
using Microsoft.VisualBasic;

namespace APICatalago.Models
{
    public class Categoria
    {
        public Categoria()
        {
            Produtos = new Collection<Produto>();
        }
        public int CategoriaId { get; set; }
        public string? Nome { get; set; }
        public string? ImagemUrl { get; set; }

        public ICollection<Produto>? Produtos { get; set; } //1 categoria pode ter varios produtos
    }
}
