using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ImobiliariaAPI.Data;
using ImobiliariaAPI.Model;
using ImobiliariaAPI.ViewModel;
using ImobiliariaAPI.Migrations;
using System.Data;
using ImobiliariaAPI.DTO;

namespace ImobiliariaAPI.Controllers;

[Route("/api/[controller]/[action]")]

public class ImovelController : ControllerBase
{
    private readonly AppDbContext _context;

    public ImovelController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Imovel
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Imovel>>> GetIMOVEIS()
    {
        if (_context.IMOVEIS == null)
        {
            return NotFound();
        }
        return await _context.IMOVEIS.ToListAsync();
    }

    // GET: api/Imovel/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Imovel>> GetImovel(int id)
    {
        if (_context.IMOVEIS == null)
        {
            return NotFound();
        }
        var imovel = await _context.IMOVEIS.FindAsync(id);

        if (imovel == null)
        {
            return NotFound();
        }

        return imovel;
    }

    // PUT: api/Imovel/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutImovel(int id, ImovelViewModel model)
    {
        if (id != model.Id)
        {
            return BadRequest();
        }

        _context.Entry(model).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ImovelExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Imovel
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public IActionResult PostImovel(
        [FromBody] ImovelViewModel model)
    {
        if (_context.IMOVEIS == null)
        {
            return Problem("Entity set 'AppDbContext.IMOVEIS'  is null.");
        }
        Imovel imovel = new Imovel
        {
            Id = model.Id,
            ImovelNome = model.ImovelNome,
            Endereco = model.Endereco,
            ValorPedido = model.ValorPedido,
            CriadoEm = model.CriadoEm,
            Descricao = model.Descricao,
            ImovelParaTroca = model.ImovelParaTroca,
            ValorDisponivelParaVolta = model.ValorDisponivelParaVolta,
            ClienteId = model.ClienteId,
        };

        _context.IMOVEIS.Add(imovel);
        _context.SaveChanges();

        return CreatedAtAction("GetImovel", new { id = model.Id }, model);
    }

    // DELETE: api/Imovel/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteImovel(int id)
    {
        if (_context.IMOVEIS == null)
        {
            return NotFound();
        }
        var imovel = await _context.IMOVEIS.FindAsync(id);
        if (imovel == null)
        {
            return NotFound();
        }

        _context.IMOVEIS.Remove(imovel);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpGet]
    public IActionResult Get()
    {
        List<Imovel> imoveis = _context.IMOVEIS.ToList();
        List<Cliente> clientes = _context.CLIENTES.ToList();

        List<ImovelOrigemDestino> imoveisEncontrados = new List<ImovelOrigemDestino>();

        foreach (Imovel imovelTroca in imoveis)
        {
            foreach (var imovelProprio in imoveis)
            {
                if(imovelProprio.Id == imovelTroca.Id)
                {
                    continue;
                }
                if(imovelProprio.ImovelNome == imovelTroca.ImovelParaTroca)
                {
                    ImovelOrigemDestino imovelOrigemDestino = new ImovelOrigemDestino();
                    imovelOrigemDestino.Cliente = clientes.Find(c => c.ClienteId == imovelTroca.ClienteId);
                    imovelOrigemDestino.ImovelNome = imovelProprio.ImovelNome;
                    imoveisEncontrados.Add(imovelOrigemDestino);
                }
            }
        }      
        return Ok(imoveisEncontrados);
    }

    private bool ImovelExists(int id)
    {
        return (_context.IMOVEIS?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
