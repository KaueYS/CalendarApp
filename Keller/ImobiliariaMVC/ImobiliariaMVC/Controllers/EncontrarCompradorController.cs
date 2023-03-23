using ImobiliariaMVC.Data;
using ImobiliariaMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ImobiliariaMVC.Controllers
{
    public class EncontrarCompradorController : Controller
    {
        private readonly AppDbContext _context;

        public EncontrarCompradorController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EncontrarComprador()
        {

            Cliente cliente = new Cliente();
            Imovel imovel = new Imovel();

            var clientesBD = _context.CLIENTES.ToList();





            return View();
        }






    }
}
