using ApiCatalogoExercicios.Context;
using ApiCatalogoExercicios.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiCatalogoExercicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }


        // GET: api/<ProdutosController>
        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            var produto = _context.Produtos.AsNoTracking().ToList();
            if (produto is null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        // GET api/<ProdutosController>/5
        [HttpGet("{id}", Name = "GerarProdutoId")]
        public ActionResult<Produto> Get(int id)
        {
            var produto = _context.Produtos.AsNoTracking().FirstOrDefault(i => i.CategoriaId == id);
            if (produto is null)
            {
                return NotFound();
            }
            return produto;
        }

        // POST api/<ProdutosController>
        [HttpPost]
        public ActionResult<Produto> Post(Produto produto)
        {
            if (produto is null)
            {
                return NotFound();
            }
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return new CreatedAtRouteResult("GerarProdutoId",
                new { id = produto.ProdutoId }, produto);
        }

        // PUT api/<ProdutosController>/5
        [HttpPut("{id}")]
        public ActionResult<Produto> Put(int id, Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                return BadRequest();
            }

            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(produto);

        }

        // DELETE api/<ProdutosController>/5
        [HttpDelete("{id}")]
        public ActionResult<Produto> Delete(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(_context => _context.ProdutoId == id);
            if (produto is null)
            {
                return NotFound();
            }

            _context.Produtos.Remove(produto);
            _context.SaveChanges();
            return Ok(produto);
        }
    }
}
