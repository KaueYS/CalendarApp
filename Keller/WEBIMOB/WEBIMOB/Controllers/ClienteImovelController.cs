using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WEBIMOB.Context;
using WEBIMOB.Models;

namespace WEBIMOB.Controllers
{
    public class ClienteImovelController : Controller
    {
        private readonly AppDbContext _context;

        public ClienteImovelController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ClienteImovels
        public async Task<IActionResult> Index()
        {
              return _context.CLIENTESIMOVEIS != null ? 
                          View(await _context.CLIENTESIMOVEIS.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.CLIENTESIMOVEIS'  is null.");
        }

        // GET: ClienteImovels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CLIENTESIMOVEIS == null)
            {
                return NotFound();
            }

            var clienteImovel = await _context.CLIENTESIMOVEIS
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clienteImovel == null)
            {
                return NotFound();
            }

            return View(clienteImovel);
        }

        // GET: ClienteImovels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClienteImovels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cliente,Email,Celular,Imovel,Referencia,Valor,Permuta,CriadoEm")] ClienteImovel clienteImovel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clienteImovel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clienteImovel);
        }

        // GET: ClienteImovels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CLIENTESIMOVEIS == null)
            {
                return NotFound();
            }

            var clienteImovel = await _context.CLIENTESIMOVEIS.FindAsync(id);
            if (clienteImovel == null)
            {
                return NotFound();
            }
            return View(clienteImovel);
        }

        // POST: ClienteImovels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cliente,Email,Celular,Imovel,Referencia,Valor,Permuta,CriadoEm")] ClienteImovel clienteImovel)
        {
            if (id != clienteImovel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clienteImovel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteImovelExists(clienteImovel.Id))
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
            return View(clienteImovel);
        }

        // GET: ClienteImovels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CLIENTESIMOVEIS == null)
            {
                return NotFound();
            }

            var clienteImovel = await _context.CLIENTESIMOVEIS
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clienteImovel == null)
            {
                return NotFound();
            }

            return View(clienteImovel);
        }

        // POST: ClienteImovels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CLIENTESIMOVEIS == null)
            {
                return Problem("Entity set 'AppDbContext.CLIENTESIMOVEIS'  is null.");
            }
            var clienteImovel = await _context.CLIENTESIMOVEIS.FindAsync(id);
            if (clienteImovel != null)
            {
                _context.CLIENTESIMOVEIS.Remove(clienteImovel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteImovelExists(int id)
        {
          return (_context.CLIENTESIMOVEIS?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
