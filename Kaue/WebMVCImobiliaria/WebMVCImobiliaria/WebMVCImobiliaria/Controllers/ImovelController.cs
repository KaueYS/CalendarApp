using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebMVCImobiliaria.Data.Context;
using WebMVCImobiliaria.Models;
using WebMVCImobiliaria.ViewModel;

namespace WebMVCImobiliaria.Controllers
{
    [Route("/api/[controller]/[action]")]
    //[ApiController]
    public class ImovelController : Controller
    {
        private readonly AppDbContext _context;

        public ImovelController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("/[controller]/Buscar")]
        public IActionResult Index()
        {
            var consulta = from cii in _context.CLIENTEINTERESSEIMOVEIS
                           join c in _context.CLIENTES on cii.ClienteId equals c.Id
                           join i in _context.IMOVEIS on cii.ImovelId equals i.Id
                           join ci in _context.CLIENTEIMOVEIS on cii.ImovelId equals ci.ImovelId
                           join cid in _context.CLIENTES on ci.ClienteId equals cid.Id
                           
                           select new ImoveisCompativeisViewModel { Cliente  = c.Nome, Imovel = i.Nome, ClienteOferta = i.Valor, Proprietario = cid.Nome };

            return View(consulta);
        }

        [HttpGet]
        public IActionResult BuscarAPI()
        {
            var consulta = from cii in _context.CLIENTEINTERESSEIMOVEIS
                           join c in _context.CLIENTES on cii.ClienteId equals c.Id
                           join i in _context.IMOVEIS on cii.ImovelId equals i.Id
                           join ci in _context.CLIENTEIMOVEIS on cii.ImovelId equals ci.ImovelId
                           join cid in _context.CLIENTES on ci.ClienteId equals cid.Id

                           select new ImoveisCompativeisViewModel { Cliente = c.Nome, Imovel = i.Nome, ClienteOferta = i.Valor, Proprietario = cid.Nome };


            return Ok(consulta);
        }

        
    }
}
