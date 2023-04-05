using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using WEBIMOB.Context;
using WEBIMOB.Models;
using WEBIMOB.Services;
using WEBIMOB.ViewModel;

namespace WEBIMOB.Controllers
{
    public class EncontrarController : Controller
    {
        private readonly ClienteImovelService _clienteImovelService;

        public EncontrarController(ClienteImovelService clienteImovelService)
        {
            _clienteImovelService = clienteImovelService;
        }

        

        public IActionResult Index()
        {
            List<ImovelPermutaModel> imoveisEncontrados = new List<ImovelPermutaModel>();
            List<ClienteImovel> imoveis = _clienteImovelService.ProcurarClientesImoveis();

            foreach (ClienteImovel venda in imoveis)
            {
                foreach (ClienteImovel troca in imoveis)
                {

                    if (venda.Imovel == troca.Permuta)
                    {
                        ImovelPermutaModel imovelPermutaModel = new ImovelPermutaModel();
                        ClienteImovel cliente= new ClienteImovel();
                        
                        imovelPermutaModel.ClienteComprador = imoveis.Find(c => c.Cliente == troca.Cliente);
                        imovelPermutaModel.Imovel = venda.Imovel;
                        imovelPermutaModel.ClienteVendedor = imoveis.Find(c => c.Cliente == venda.Cliente);
                        
                        imoveisEncontrados.Add(imovelPermutaModel);
                    }
                }

            }
            return View(imoveisEncontrados);
        }
    }
}
