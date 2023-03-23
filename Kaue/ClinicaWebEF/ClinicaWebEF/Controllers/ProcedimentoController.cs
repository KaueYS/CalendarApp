using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClinicaWebEF.Context;
using ClinicaWebEF.Models;

namespace ClinicaWebEF.Controllers
{
    public class ProcedimentoController : Controller
    {
        private readonly AppDbContext _context;

        public ProcedimentoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Procedimento
        public async Task<IActionResult> Index()
        {
              return _context.PROCEDIMENTOS != null ? 
                          View(await _context.PROCEDIMENTOS.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.PROCEDIMENTOS'  is null.");
        }

        // GET: Procedimento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PROCEDIMENTOS == null)
            {
                return NotFound();
            }

            var procedimento = await _context.PROCEDIMENTOS
                .FirstOrDefaultAsync(m => m.ProcedimentoId == id);
            if (procedimento == null)
            {
                return NotFound();
            }

            return View(procedimento);
        }

        // GET: Procedimento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Procedimento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProcedimentoId,Preco,IsDone,PacienteId")] Procedimento procedimento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(procedimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(procedimento);
        }

        // GET: Procedimento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PROCEDIMENTOS == null)
            {
                return NotFound();
            }

            var procedimento = await _context.PROCEDIMENTOS.FindAsync(id);
            if (procedimento == null)
            {
                return NotFound();
            }
            return View(procedimento);
        }

        // POST: Procedimento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProcedimentoId,Preco,IsDone,PacienteId")] Procedimento procedimento)
        {
            if (id != procedimento.ProcedimentoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(procedimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcedimentoExists(procedimento.ProcedimentoId))
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
            return View(procedimento);
        }

        // GET: Procedimento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PROCEDIMENTOS == null)
            {
                return NotFound();
            }

            var procedimento = await _context.PROCEDIMENTOS
                .FirstOrDefaultAsync(m => m.ProcedimentoId == id);
            if (procedimento == null)
            {
                return NotFound();
            }

            return View(procedimento);
        }

        // POST: Procedimento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PROCEDIMENTOS == null)
            {
                return Problem("Entity set 'AppDbContext.PROCEDIMENTOS'  is null.");
            }
            var procedimento = await _context.PROCEDIMENTOS.FindAsync(id);
            if (procedimento != null)
            {
                _context.PROCEDIMENTOS.Remove(procedimento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcedimentoExists(int id)
        {
          return (_context.PROCEDIMENTOS?.Any(e => e.ProcedimentoId == id)).GetValueOrDefault();
        }
    }
}
