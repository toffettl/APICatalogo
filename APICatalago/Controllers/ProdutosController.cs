using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APICatalago.Data;
using APICatalago.Models;

namespace APICatalago.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly APICatalogoContext _context;

        public ProdutosController(APICatalogoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get() //IEnumerable pode ser substituido por uma lista
        {
            var produtos = _context.Produto.ToList();
            if (produtos == null)
            {
                return NotFound("Produtos não encontrados"); //erro 404
            }
            return produtos;
        }

        [HttpGet("{id}", Name = "ObterProduto")]
        public ActionResult<Produto> Get(int id) //ActionResult serve para poder retornar uma ação como NotFound()
        {
            var produto = _context.Produto.FirstOrDefault(p => p.ProdutoId == id);
            if (produto == null)
            {
                return NotFound("Produto não encontrado!");
            }
            return produto;
        }

        [HttpPost]
        public ActionResult Post(Produto produto) //uso só ActionResult pois quero retornar apenas mensagens https
        {
            if (produto == null)
            {
                return BadRequest();
            }

            _context.Produto.Add(produto);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterProduto", new { id = produto.ProdutoId }, produto); //retorna o metodo get com a rota ObterProduto
        }

        [HttpPut("{id}")] //put atualiza o produto inteiro, se quisesse atualizar apenas o nome por exemplo usaria o patch
        public ActionResult Put(int id, Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                return BadRequest("Produto não encontrado!");
            }

            _context.Entry(produto).State = EntityState.Modified; //indicando que produto sera modificado
            _context.SaveChanges();

            return Ok(produto);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var produto = _context.Produto
                .FirstOrDefault(p => p.ProdutoId == id);

            if(produto == null)
            {
                return NotFound("Produto não localizado!");
            }
            
            _context.Produto.Remove(produto);
            _context.SaveChanges();

            return Ok(produto);
        }
    }
}
