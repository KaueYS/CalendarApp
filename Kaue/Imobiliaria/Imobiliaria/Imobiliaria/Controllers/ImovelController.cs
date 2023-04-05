using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Imobiliaria.Data;
using Imobiliaria.Models;

namespace Imobiliaria.Controllers
{
    public class ImovelController : Controller
    {
        private readonly AppDbContext _context;

        public ImovelController(AppDbContext context)
        {
            _context = context;
        }


        
        // GET: Imovel
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.IMOVEIS.Include(i => i.Cliente);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Imovel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.IMOVEIS == null)
            {
                return NotFound();
            }

            var imovel = await _context.IMOVEIS
                .Include(i => i.Cliente)
                .FirstOrDefaultAsync(m => m.ImovelId == id);
            if (imovel == null)
            {
                return NotFound();
            }

            return View(imovel);
        }

        // GET: Imovel/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.CLIENTES, "ClienteId", "Name");
            return View();
        }

        // POST: Imovel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ImovelId,NomeDoImovelVenda,NomeDoImovelCompra,ValorPedido,ValorDisponivel,ClienteId")] Imovel imovel)
        {
           
                _context.Add(imovel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
           
        }

        // GET: Imovel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.IMOVEIS == null)
            {
                return NotFound();
            }

            var imovel = await _context.IMOVEIS.FindAsync(id);
            if (imovel == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.CLIENTES, "ClienteId", "ClienteId", imovel.ClienteId);
            return View(imovel);
        }

        // POST: Imovel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ImovelId,NomeDoImovelVenda,NomeDoImovelCompra,ValorPedido,ValorDisponivel,ClienteId")] Imovel imovel)
        {
            if (id != imovel.ImovelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(imovel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImovelExists(imovel.ImovelId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.CLIENTES, "ClienteId", "ClienteId", imovel.ClienteId);
            return View(imovel);
        }

        // GET: Imovel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.IMOVEIS == null)
            {
                return NotFound();
            }

            var imovel = await _context.IMOVEIS
                .Include(i => i.Cliente)
                .FirstOrDefaultAsync(m => m.ImovelId == id);
            if (imovel == null)
            {
                return NotFound();
            }

            return View(imovel);
        }

        // POST: Imovel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.IMOVEIS == null)
            {
                return Problem("Entity set 'AppDbContext.IMOVEIS'  is null.");
            }
            var imovel = await _context.IMOVEIS.FindAsync(id);
            if (imovel != null)
            {
                _context.IMOVEIS.Remove(imovel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImovelExists(int id)
        {
          return (_context.IMOVEIS?.Any(e => e.ImovelId == id)).GetValueOrDefault();
        }
    }
}
