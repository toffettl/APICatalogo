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
    public class CategoriasController : ControllerBase
    {
        private readonly APICatalogoContext _context;

        public CategoriasController(APICatalogoContext context)
        {
            _context = context;
        }
    }
}
