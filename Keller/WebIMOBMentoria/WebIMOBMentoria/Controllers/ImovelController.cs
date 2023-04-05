using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebIMOBMentoria.Data;
using WebIMOBMentoria.Models;
using WebIMOBMentoria.ViewModel;

namespace WebIMOBMentoria.Controllers
{

    public class ImovelController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ImovelController(ApplicationDbContext context)
        {
            _context = context;
        }

        //=================================================================================================================
        public IActionResult Index()
        {
            var imoveis = _context.IMOVEIS.Include(inc => inc.Cliente).ToList();

            return View(imoveis);
        }

        //=================================================================================================================
        public IActionResult Details(int? id)
        {
            var imovelDetails = _context.IMOVEIS.Include(inc => inc.Cliente).FirstOrDefault(first => first.ImovelId == id);
            if (imovelDetails == null)
            {
                return NotFound();
            }
            return View(imovelDetails);
        }

        //=================================================================================================================
        public IActionResult Create()
        {
            var cliente = _context.CLIENTES.OrderBy(_ => _.ClienteNome).AsNoTracking().ToList();
            ImovelViewModel model = new ImovelViewModel();
            model.Clientes = cliente;

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(Imovel imovel)
        {
            _context.IMOVEIS.Add(imovel);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //=================================================================================================================
        public IActionResult Edit(int? id) // Id da lista da pag
        {
            //1 consulta por ID
            //2 instanciar uma lista de clientes
            //3 Preencher a viewmodel e retornar na view


            var imovelPorId = _context.IMOVEIS.AsNoTracking().FirstOrDefault(i => i.ImovelId == id);
            List<Cliente> clientes = _context.CLIENTES.ToList();

            ImovelViewModel imovelViewModel = new ImovelViewModel
            {
                //Imovel = imovelPorId,
                ImovelId = imovelPorId.ImovelId,
                ImovelNomeVenda = imovelPorId.ImovelNomeVenda,
                ImovelNomeCompra = imovelPorId.ImovelNomeCompra,
                ValorDoImovel= imovelPorId.ValorDoImovel,
                Clientes = clientes
            };
            return View(imovelViewModel);
        }

        [HttpPost]
        public IActionResult Edit([FromForm]ImovelViewModel imovelViewModel)
        {
            Imovel imovel = new Imovel();

            imovel.ImovelId = imovelViewModel.ImovelId;
            imovel.ImovelNomeVenda= imovelViewModel.ImovelNomeVenda;
            imovel.ImovelNomeCompra = imovelViewModel.ImovelNomeCompra;
            imovel.ValorDoImovel = imovelViewModel.ValorDoImovel;
            imovel.ClienteId = imovelViewModel.ClienteId;

            _context.IMOVEIS.Update(imovel);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //=================================================================================================================
        public IActionResult Delete(int? id)
        {
            var imovelDelete = _context.IMOVEIS.Find(id);
            if (imovelDelete == null)
            {
                return NotFound();
            }
            return View(imovelDelete);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var imovelDelete = _context.IMOVEIS.Find(id);
            _context.IMOVEIS.Remove(imovelDelete);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        //=================================================================================================================
    }
}
