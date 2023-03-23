using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebMVCImobiliaria.Data.Context;
using WebMVCImobiliaria.Models;
using WebMVCImobiliaria.ViewModel;

namespace WebMVCImobiliaria.Controllers
{
    [Route("/api/[controller]/[action]")]
    [ApiController]
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
                           select new ImoveisCompativeisViewModel { Cliente  = c.Nome, Imovel = i.Nome, ClienteOferta = cii.ClienteOferta, Proprietario = cid.Nome };

            return Ok(consulta);
        }

        [HttpGet]
        public IActionResult ListarImoveis()
        {
            var imoveis = _context.IMOVEIS.ToList();
            return Ok(imoveis);
        }

        [HttpPost]
        public IActionResult CadastrarImoveis(
            [FromBody] ImovelViewModel model)
        {
            Imovel imovel = new Imovel
            {
                Nome = model.Nome,
                Valor= model.Valor,
                Tipo= model.Tipo,
                Referencia= model.Referencia,
                //CriadoEm= model.CriadoEm
            };
            _context.IMOVEIS.Add(imovel);
            _context.SaveChanges();
            return Ok(imovel);
        }

        [HttpPut("{id:int}")]
        public IActionResult EditarCliente(
            [FromBody] Cliente model,
            [FromRoute] int id)
        {
            var imoveis = _context.CLIENTES.FirstOrDefault(x => x.Id == id);
            if (imoveis == null)
                NotFound(id);

            imoveis.Nome = model.Nome;
            imoveis.Documento = model.Documento;
            imoveis.Telefone = model.Telefone;
            imoveis.Email = model.Email;

            _context.CLIENTES.Update(imoveis);
            _context.SaveChanges();
            return Ok(imoveis);
        }
    }
}
