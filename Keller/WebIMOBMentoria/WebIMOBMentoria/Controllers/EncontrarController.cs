using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebIMOBMentoria.Data;
using WebIMOBMentoria.Models;
using WebIMOBMentoria.ViewModel;

namespace WebIMOBMentoria.Controllers
{
    public class EncontrarController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EncontrarController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EncontrarCompradores()
        {
            List<Imovel> imoveis = _context.IMOVEIS.ToList();
            List<Cliente> clientes = _context.CLIENTES.ToList();
            List<EncontrarCompradoresViewModel> imoveisEncontrados = new List<EncontrarCompradoresViewModel>();

            foreach (var imovelCompra in imoveis)
            {

                foreach (var imovelVenda in imoveis)
                {
                    if(imovelVenda.ImovelId == imovelCompra.ImovelId)
                    {
                        continue;
                    }

                    if(imovelVenda.ImovelNomeVenda == imovelCompra.ImovelNomeCompra)
                    {
                        EncontrarCompradoresViewModel encontrarCompradoresViewModel = new EncontrarCompradoresViewModel();

                        //encontrarCompradoresViewModel.ClienteId = clientes.Find(c => c.ClienteId == imovelVenda.ClienteId);
                        encontrarCompradoresViewModel.ClienteId = imovelVenda.ClienteId;
                        encontrarCompradoresViewModel.ImovelNomeCompra = imovelVenda.ImovelNomeCompra;
                        encontrarCompradoresViewModel.ValorDoImovel= imovelVenda.ValorDoImovel;
                        encontrarCompradoresViewModel.ImovelNomeVenda = imovelVenda.ImovelNomeVenda;

                        encontrarCompradoresViewModel.Cliente = imovelCompra.Cliente;
                        imoveisEncontrados.Add(encontrarCompradoresViewModel);

                    }
                }
            }
            return View(imoveisEncontrados);
        }
    }
}
