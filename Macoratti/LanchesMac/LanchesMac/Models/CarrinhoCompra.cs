using LanchesMac.Context;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac.Models;

public class CarrinhoCompra
{
    private readonly AppDbContext _context;

    public CarrinhoCompra(AppDbContext context)
    {
        _context = context;
    }

    public string CarrinhoCompraId { get; set; }
    public List<CarrinhoCompraItemModel> CarrinhoCompraItems { get; set; }



    public static CarrinhoCompra GetCarrinho(IServiceProvider services)
    {
        //Define uma sessao, obtem um servico no banco via context
        //gera o Id do Carrinho de compras
        //atribui o ID do carrinho de compras na session 
        //retorno do carrinho com o ID na sessao iniciada

        ISession session =
            services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

        var context = services.GetRequiredService<AppDbContext>();

        string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

        session.SetString("CarrinhoId", carrinhoId);

        return new CarrinhoCompra(context)
        {
            CarrinhoCompraId = carrinhoId
        };
    }

    public void AdicionarProdutosAoCarrinho(Lanche lanche)
    {
        var carrinhoCompraItem = _context.CarrinhoCompraItens.SingleOrDefault(
            s => s.LancheCCI.LancheId == lanche.LancheId
            && s.CarrinhoCompraId == CarrinhoCompraId);

        if (carrinhoCompraItem == null)
        {
            carrinhoCompraItem = new CarrinhoCompraItemModel()
            {
                CarrinhoCompraId = CarrinhoCompraId,
                LancheCCI = lanche,
                Quantidade = 1
            };
            _context.CarrinhoCompraItens.Add(carrinhoCompraItem);
        }
        else
        {
            carrinhoCompraItem.Quantidade++;
        }

        _context.SaveChanges();
    }

    public int RemoverProdutosDoCArrinho(Lanche lanche)
    {
        var carrinhoCompraItem = _context.CarrinhoCompraItens.SingleOrDefault(
            s => s.LancheCCI.LancheId == lanche.LancheId
            && s.CarrinhoCompraId == CarrinhoCompraId);

        var quantidadeLocal = 0;

        if (carrinhoCompraItem != null)
        {
            if (carrinhoCompraItem.Quantidade > 1)
            {
                carrinhoCompraItem.Quantidade--;
                quantidadeLocal = carrinhoCompraItem.Quantidade;

            }
            else
            {
                _context.CarrinhoCompraItens.Remove(carrinhoCompraItem);
            }
        }
        _context.SaveChanges();
        return quantidadeLocal;
    }

    public List<CarrinhoCompraItemModel> GetCarrinhoCompraItem()
    {
        return CarrinhoCompraItems ??
            (CarrinhoCompraItems =
            _context.CarrinhoCompraItens
            .Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
            .Include(s => s.LancheCCI)
            .ToList());
    }

    public void LimparCarrinho()
    {
        var deletarCarrinho = _context.CarrinhoCompraItens
            .Where(car => car.CarrinhoCompraId == CarrinhoCompraId);

        _context.CarrinhoCompraItens.RemoveRange(deletarCarrinho);
    }

    public decimal GetCarrinhoTotal()
    {
        var total = _context.CarrinhoCompraItens
            .Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
            .Select(c => c.LancheCCI.Preco * c.Quantidade)
            .Sum();
        return total;
    }
}
