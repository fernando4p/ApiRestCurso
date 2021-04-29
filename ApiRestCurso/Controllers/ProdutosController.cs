using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiRestCurso.Context;
using ApiRestCurso.Modelo;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;
using ApiRestCurso.Filter;

namespace ApiRestCurso.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {

        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public ProdutosController(AppDbContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;
        }

        // GET api/values
        [HttpGet]
        [ServiceFilter(typeof(ApiLogginFilter))]
        public ActionResult<IEnumerable<Produtos>> Get()
        {
            return _context.produtos;
            //return _context.produtos.Where<Produtos>(p => p.ProdId <= 4).ToList();
        }

        //Modelo de metodos assincronos
        [HttpGet("CDBL/{valor:double:range(1,10)?}")]
        public async Task<ActionResult<IEnumerable<Produtos>>> GetAsync(double valor)
        {
            var teste = valor;
            return await _context.produtos.Where<Produtos>(p => p.ProdId <= teste).ToListAsync();
        }

        //[HttpGet("{valor:alpha:length(5)}")]
        //public ActionResult<IEnumerable<Produtos>> Get(string valor)
        //{

        //    var teste = valor;

        //    return _context.produtos.Where<Produtos>(p => p.ProdId <= 4).ToList();
        //}

        // GET api/values/5
        [HttpGet("{id:int:min(1)}")]
        public async Task<ActionResult<Produtos>> Get([FromQuery]int id, [BindRequired] string nome)
        {

            throw new Exception("Exceptio ao retornar produto pelo ID");

            var nomeprod = nome;

            var produto = await _context.produtos.FirstOrDefaultAsync(p => p.ProdId == id);
            
            if(produto == null)
            {
                return NotFound();
            }

            return produto;
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] Produtos produtos)
        {
            //if (ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            _context.Add(produtos);
            _context.SaveChanges();

            return Ok("Produto incluido com sucesso");
            //return new CreatedAtRouteResult("ObterProduto", new { id = produtos.ProdId }, produtos);

        }

        [HttpGet("Fernando")]
        public ActionResult<string> getFer()
        {
            var msg = _configuration["Fernando:Gosta"];
            return msg;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
