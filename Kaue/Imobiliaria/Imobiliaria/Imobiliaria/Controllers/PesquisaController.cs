using Imobiliaria.Data;
using Imobiliaria.DTO;
using Imobiliaria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Imobiliaria.Controllers;

public class PesquisaController : Controller
{
    private readonly AppDbContext _context;

    public PesquisaController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }
    [HttpGet]
    public IActionResult ListaClientes()
    {
        List<Imovel> imoveis = _context.IMOVEIS.ToList();
        List<Cliente> clientes = _context.CLIENTES.ToList();
        List<ImovelOrigemDestino> imoveisEncontrados = new List<ImovelOrigemDestino>();
        
        foreach (Imovel imovelTroca in imoveis)
        {

            foreach (Imovel imovelVenda in imoveis)
            {
                if (imovelVenda.ImovelId == imovelTroca.ImovelId)
                {
                    continue;
                }

                if (imovelVenda.NomeDoImovelVenda == imovelTroca.NomeDoImovelCompra)
                {
                    ImovelOrigemDestino imovelOrigemDestino = new ImovelOrigemDestino();
                    imovelOrigemDestino.ClienteId = clientes.Find(c => c.ClienteId == imovelVenda.ClienteId);
                    imovelOrigemDestino.NomeDoImovelCompra = imovelVenda.NomeDoImovelCompra;
                    imovelOrigemDestino.NomeDoImovelVenda = imovelVenda.NomeDoImovelVenda;
                    imovelOrigemDestino.Cliente = clientes.Find(c => c.ClienteId == imovelTroca.ClienteId);
                    imoveisEncontrados.Add(imovelOrigemDestino);
                   
                }
            }
        }
        return View(imoveisEncontrados);
    }
}
