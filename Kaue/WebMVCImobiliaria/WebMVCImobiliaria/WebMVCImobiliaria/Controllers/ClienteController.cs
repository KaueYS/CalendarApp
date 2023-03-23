using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebMVCImobiliaria.Data.Context;
using WebMVCImobiliaria.Models;
using WebMVCImobiliaria.ViewModel;

namespace WebMVCImobiliaria.Controllers
{
    [Route("/api/[controller]/[action]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClienteController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ListarCLientes()
        {
            var clientes = _context.CLIENTES.ToList();
            return Ok(clientes);
        }

        [HttpPost]
        public IActionResult CadastrarCliente(
            [FromBody] ClienteViewModel model)
        {
            Cliente cliente = new Cliente
            {
                Nome = model.Nome,
                Documento = model.Documento,
                Telefone = model.Telefone,
                Email = model.Email,
            };
            _context.CLIENTES.Add(cliente);
            _context.SaveChanges();

            return Ok(cliente);
        }

        [HttpPut("{id:int}")]
        public IActionResult EditarCliente(
            [FromBody] Cliente model,
            [FromRoute] int id)
        {
            var cliente = _context.CLIENTES.FirstOrDefault(x => x.Id == id);
            if (cliente == null)
                NotFound(id);

            cliente.Nome = model.Nome;
            cliente.Documento = model.Documento;
            cliente.Telefone = model.Telefone;
            cliente.Email = model.Email;

            _context.CLIENTES.Update(cliente);
            _context.SaveChanges();



            return Ok(cliente);
        }


    }
}
