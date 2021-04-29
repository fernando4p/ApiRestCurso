using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRestCurso.Context;
using ApiRestCurso.Modelo;
using ApiRestCurso.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiRestCurso.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {

        private readonly AppDbContext _context;
        public CategoriaController(AppDbContext context)
        {
            _context = context;
        }


        // GET: api/Categoria
        [HttpGet]
        public ActionResult<IEnumerable<Categoria>>Get()
        {
            try
            {
                return _context.categorias.ToList<Categoria>();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,"Erro ao tentar obter os dados de categoria do banco de dados");
            }
           
        }

        [HttpGet("saldacao/{nome}")]
        public ActionResult<string> getServico([FromServices] IMeuServico meuservico, string nome)
        {
            return meuservico.saldacao(nome);
        }

        // GET: api/Categoria
        [HttpGet("produtos")]
        [HttpGet("/produtos")]
        public ActionResult<IEnumerable<Categoria>> GetCategoriaProdutos()
        {
            return _context.categorias.Include(x => x.produtos).ToList<Categoria>();
        }

        [HttpGet("{v1}/{v2}/{v3=100}/{v4?}")]
        public ActionResult<List<Double>> getsoma(int v1, int v2, int v3, int v4)
        {
            List<Double> lista = new List<double>()
            {
                v1, v2, v3, v4
            };

            return lista.ToList();
        }

        // GET: api/Categoria/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Categoria> Get(int id)
        {
            try
            {
                //var categoria = _context.categorias.Find(id);

                var categoria = _context.categorias.AsNoTracking().FirstOrDefault(p => p.CategoriaId == id);

                if (categoria == null)
                {
                    return NotFound($"a categoria {id} não foi localizada");
                }

                return categoria;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar obter os dados de categoria do banco de dados");
            }
            
        }

        // POST: api/Categoria
        [HttpPost("incluir")]
        public ActionResult<Categoria> Post([FromBody] Categoria categoria)
        {
            try
            {
                _context.categorias.Add(categoria);
                _context.SaveChanges();
                return Ok($"Categoria criada com sucesso!");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Não foi possivel inserir a categoria, verifique a documentação");
            }
        }

        // PUT: api/Categoria/5
        [HttpPut("{id}")]
        public ActionResult<Categoria> Put(int id, [FromBody] Categoria categoria)
        {
            try
            {
                

                if (id != categoria.CategoriaId)
                {
                    return NotFound($"Categoria {categoria.CategoriaId} não encontrada");
                }

                _context.Entry(categoria).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao acessar a base de dados");
            }

           
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Categoria> Delete(int id)
        {
            var categoria = _context.categorias.Find(id);
            if(categoria == null)
            {
                return BadRequest();
            }

            _context.categorias.Remove(categoria);
            _context.SaveChanges();
            return Ok();

        }
    }
}
