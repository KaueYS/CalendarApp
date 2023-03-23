using ClinicaWEB.Data.Context;
using ClinicaWEB.Models;
using ClinicaWEB.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicaWEB.Controllers
{
    [ApiController]
    public class ProcedimentoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProcedimentoController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("/procedimentos")]
        public IActionResult Get()
        {
            var procedimentos = _context.PROCEDIMENTOS.AsNoTracking().ToList();
            if (procedimentos != null)
            {
                return Ok(procedimentos);
            }
            return StatusCode(404, "Nao encontrado");

        }

        [HttpGet("/procedimentos/{id:int}")]
        public IActionResult GetById(
            [FromRoute] int id)
        {
            var procedimentos = _context.PROCEDIMENTOS.AsNoTracking().FirstOrDefault(x => x.ProcedimentoId == id);
            if (procedimentos == null)
            {
                return Ok(procedimentos);
            }
            return StatusCode(404, " Nao encontrado");


        }
        [HttpPost("/procedimentos")]
        public IActionResult Post(
            [FromBody] ProcedimentoViewModel model)
        {
            var procedimento = new Procedimento()
            {
                Nome = model.Nome,
                Preco = model.Preco,
            };

            _context.PROCEDIMENTOS.Add(procedimento);
            _context.SaveChanges();
            return Created($"/procedimentos {procedimento}", procedimento);
        }

        [HttpPut("/procedimentos/{id:int}")]
        public IActionResult Put(
            [FromBody] ProcedimentoViewModel model,
            [FromRoute] int id)
        {
            var procedimentoBD = _context.PROCEDIMENTOS.FirstOrDefault(x => x.ProcedimentoId == id);
            if (procedimentoBD != null)
            {
                procedimentoBD.Nome = model.Nome;
                procedimentoBD.Preco = model.Preco;

                _context.Update(procedimentoBD);
                _context.SaveChanges();
                return Ok(procedimentoBD);
            }
            return StatusCode(400, "Nao encontrado");

        }

        [HttpDelete("/procedimentos/{id:int")]
        public IActionResult Delete(
            [FromRoute] int id)
        {
            var procedimento = _context.PROCEDIMENTOS.FirstOrDefault(x => x.ProcedimentoId == id);
            if (procedimento != null)
            {
                _context.Remove(procedimento);
                _context.SaveChanges();
                return Ok();
            }
            return StatusCode(400, "Nao pode ser deletado");

        }
    }
}
