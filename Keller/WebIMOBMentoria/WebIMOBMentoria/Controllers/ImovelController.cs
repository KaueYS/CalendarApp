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

        public IActionResult Index()
        {
            var imoveis = _context.IMOVEIS.Include(obj => obj.Cliente).ToList();
            
            return View(imoveis);
        }

        public IActionResult Create() 
        {
            var cliente = _context.CLIENTES.OrderBy(_ =>_.ClienteNome).ToList();
            ImovelViewModel model = new ImovelViewModel { Clientes = cliente };
            return View(model);

            
        }

        public IActionResult Details(int? id)
        {
            var imovelDetails = _context.IMOVEIS.Include(obj => obj.Cliente).FirstOrDefault(idobj => idobj.ImovelId == id);
            if (imovelDetails == null)
            {
                return NotFound();
            }
            return View(imovelDetails);

        }
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





        [HttpPost]
        public IActionResult Create(Imovel imovel)
        {
            _context.IMOVEIS.Add(imovel);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
