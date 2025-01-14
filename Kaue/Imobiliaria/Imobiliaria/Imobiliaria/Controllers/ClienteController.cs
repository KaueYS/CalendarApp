﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Imobiliaria.Data;
using Imobiliaria.Models;

namespace Imobiliaria.Controllers;


public class ClienteController : Controller
{
    private readonly AppDbContext _context;

    public ClienteController(AppDbContext context)
    {
        _context = context;
    }

    // GET: Cliente
    public async Task<IActionResult> Index()
    {
          return _context.CLIENTES != null ? 
                      View(await _context.CLIENTES.ToListAsync()) :
                      Problem("Entity set 'AppDbContext.CLIENTES'  is null.");
    }

    // GET: Cliente/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || _context.CLIENTES == null)
        {
            return NotFound();
        }

        var cliente = await _context.CLIENTES
            .FirstOrDefaultAsync(m => m.ClienteId == id);
        if (cliente == null)
        {
            return NotFound();
        }

        return View(cliente);
    }

    // GET: Cliente/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Cliente/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ClienteId,Name,Telefone")] Cliente cliente)
    {
        if (ModelState.IsValid)
        {
            _context.Add(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(cliente);
    }

    // GET: Cliente/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || _context.CLIENTES == null)
        {
            return NotFound();
        }

        var cliente = await _context.CLIENTES.FindAsync(id);
        if (cliente == null)
        {
            return NotFound();
        }
        return View(cliente);
    }

    // POST: Cliente/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("ClienteId,Name,Telefone")] Cliente cliente)
    {
        if (id != cliente.ClienteId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(cliente);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(cliente.ClienteId))
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
        return View(cliente);
    }

    // GET: Cliente/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || _context.CLIENTES == null)
        {
            return NotFound();
        }

        var cliente = await _context.CLIENTES
            .FirstOrDefaultAsync(m => m.ClienteId == id);
        if (cliente == null)
        {
            return NotFound();
        }

        return View(cliente);
    }

    // POST: Cliente/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_context.CLIENTES == null)
        {
            return Problem("Entity set 'AppDbContext.CLIENTES'  is null.");
        }
        var cliente = await _context.CLIENTES.FindAsync(id);
        if (cliente != null)
        {
            _context.CLIENTES.Remove(cliente);
        }
        
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ClienteExists(int id)
    {
      return (_context.CLIENTES?.Any(e => e.ClienteId == id)).GetValueOrDefault();
    }
}
