using ClinicaWEB.Data.Context;
using ClinicaWEB.Models;
using ClinicaWEB.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicaWEB.Controllers
{
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PacienteController(AppDbContext context)
        {
            _context = context;
        }



        [HttpGet("/pacientes")]
        public IActionResult Get()
            
        {
            var pacientes = _context.PACIENTES.AsNoTracking().ToList();
            return Ok(pacientes);
        }

        [HttpGet("/pacientes/{id:int}")]
        public IActionResult GetById(
            [FromRoute] int id)
            
        {
            var pacientes = _context.PACIENTES.AsNoTracking().FirstOrDefault(x => x.PacienteId == id);
            if(pacientes is null)
            {
                return BadRequest();
            }
            return Ok(pacientes);
        }

        [HttpPost("/pacientes")]
        public IActionResult Post(
            [FromBody] PacienteViewModel model)
            
        {
            var pacientes = new Paciente()
            {
                Email = model.Email,
                Nome = model.Nome,
                Telefone = model.Telefone,
            };
            _context.Add(pacientes);
            _context.SaveChanges();
            return Ok(pacientes);
        }

        [HttpPut("/paciente/{id:int}")]
        public IActionResult Put(
            
            [FromBody] PacienteViewModel model,
            [FromRoute] int id)
            
        {
            var pacienteBD = _context.PACIENTES.FirstOrDefault(x => x.PacienteId == id);
            pacienteBD.Nome = model.Nome;
            pacienteBD.Email= model.Email;
            pacienteBD.Telefone = model.Telefone;

            _context.Update(pacienteBD);
            _context.SaveChanges();
            return Ok(pacienteBD);
        }

        [HttpDelete("/pacientes/{id:int}")]
        public IActionResult Delete(
            [FromRoute]int id)
            
        {
            var pacienteDB = _context.PACIENTES.FirstOrDefault(a => a.PacienteId== id);
            if(pacienteDB is null) return NotFound();

            _context.Remove(pacienteDB);
            _context.SaveChanges();
            return Ok();
        }

    }
}
