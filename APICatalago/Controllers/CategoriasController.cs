﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APICatalago.Data;
using APICatalago.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using APICatalogo.Services;

namespace APICatalago.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly APICatalogoContext _context;
        private readonly IMeuServico _meuServico;

        public CategoriasController(APICatalogoContext context, IMeuServico meuServico)
        {
            _context = context;
            _meuServico = meuServico;
        }

        [HttpGet("UsandoFromServices/{nome}")]
        public ActionResult<string> GetSaudacaoFromServices([FromServices] IMeuServico meuServico, string nome)
        {
            return meuServico.Saudacao(nome);
        }

        [HttpGet("SemUsarFromServices/{nome}")]
        public ActionResult<string> GetSaudacaoSemFromServices(IMeuServico meuServico, string nome)
        {
            return meuServico.Saudacao(nome);
        }

        [HttpGet("produtos")]
        public ActionResult<IEnumerable<Categoria>> GetCategoriasProdutos()
        {
            return _context.Categoria.Include(p => p.Produtos).Where(c => c.CategoriaId <= 5).ToList(); //Include para incluir os produtos das categorias
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            return _context.Categoria.AsNoTracking().ToList();
        }

        [HttpGet("{id:int:min(1)}", Name = "ObterCategoria")]
        public ActionResult<Categoria> Get(int id)
        {
            var categoria = _context.Categoria
                .FirstOrDefault(c => c.CategoriaId == id);

            if (categoria == null)
            {
                return NotFound("Categoria não encontrada!");
            }

            return categoria;
        }

        [HttpPost]
        public ActionResult Post(Categoria categoria)
        {
            if (categoria == null)
            {
                return BadRequest();
            }

            _context.Categoria.Add(categoria);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterCategoria", new { id = categoria.CategoriaId }, categoria);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, Categoria categoria)
        {
            if(id != categoria.CategoriaId)
            {
                return BadRequest("Categoria não encontrada!");
            }

            _context.Entry(categoria).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(categoria);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var categoria = _context.Categoria
                .FirstOrDefault(c => c.CategoriaId == id);

            if(categoria == null)
            {
                return NotFound("Categoria não encontrada!");
            }

            _context.Categoria.Remove(categoria);
            _context.SaveChanges();

            return Ok(categoria);
        }
    }
}
