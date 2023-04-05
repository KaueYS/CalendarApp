using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Text;
using WebMVCImobiliaria.Data.Context;
using WebMVCImobiliaria.Models;
using System;
using WebMVCImobiliaria.Tipos;

namespace WebMVCImobiliaria.Controllers;

[Route("/api/[controller]/[action]")]
public class ProcessarController : Controller
{
    private readonly AppDbContext _context;

    public ProcessarController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult Importar(IFormFile formFile)
    {
        //0 Nome do Cliente
        //1 Numero Documento
        //2 Telefone
        //3 Email
        //4 Nome do Imovel
        //5 Referencia Imovel
        //6 Tipo Imovel
        //7 Descricao Imovel
        //8 Valor
        //9 Situacao
        //10 Numero Interesse
        //11 Cliente Oferta



        List<string> linhas = new List<string>();
        Cliente cliente = null;
        Imovel imovel = null;
        ClienteInteresseImovel clienteInteresseImovel = null;

        using (StreamReader reader = new StreamReader(formFile.OpenReadStream()))
        {
            while (reader.Peek() >= 0)
            {
                linhas.Add(reader.ReadLine());
            }
        }
        _context.CLIENTEIMOVEIS.ExecuteDelete();
        _context.SaveChanges();
        _context.CLIENTEINTERESSEIMOVEIS.ExecuteDelete();
        _context.SaveChanges();

        for (int i = 0; i < linhas.Count; i++)
        {
            if (i == 0)
            {
                continue;
            }

            string[] colunas = linhas[i].Split(';');

            if (colunas[0] == "" && colunas[4] == "")
            {
                continue;
            }

            cliente = new Cliente();
            if (colunas[0] != "")
            {
                cliente.Nome = colunas[0];
                cliente.Documento = colunas[1];
                cliente.Telefone = colunas[2];
                cliente.Email = colunas[3];

                Cliente clienteEncontrado = _context.CLIENTES.AsNoTracking().FirstOrDefault(x => x.Documento == cliente.Documento);

                if (clienteEncontrado is null)
                {
                    _context.CLIENTES.Add(cliente);
                    _context.SaveChanges();
                }
                else
                {
                    cliente.Id = clienteEncontrado.Id;
                    _context.CLIENTES.Update(cliente);
                    _context.SaveChanges();
                }
            }

            imovel = new Imovel();
            if (colunas[4] != "")
            {
                imovel.Nome = colunas[4];
                imovel.Referencia = colunas[5];
                imovel.Tipo = colunas[6];
                imovel.Descricao = colunas[7];
                imovel.Valor = decimal.Parse(colunas[8], new System.Globalization.CultureInfo("pt-BR"));

                imovel.Situacao = Enum.Parse<ImovelSituacao>(colunas[9]);

                Imovel imovelEncontrado = _context.IMOVEIS.AsNoTracking().FirstOrDefault(x => x.Referencia == imovel.Referencia);

                if (imovelEncontrado is null)
                {
                    _context.IMOVEIS.Add(imovel);
                    _context.SaveChanges();
                }
                else
                {
                    imovel.Id = imovelEncontrado.Id;
                    _context.IMOVEIS.Update(imovel);
                    _context.SaveChanges();
                }
            }
            if (cliente != null && imovel != null && cliente.Id > 0 && imovel.Id > 0)
            {

                ClienteImovel clienteImovel = new ClienteImovel();
                clienteImovel.ClienteId = cliente.Id;
                clienteImovel.ImovelId = imovel.Id;

                _context.CLIENTEIMOVEIS.Add(clienteImovel);
                _context.SaveChanges();
            }
            
        }
        for (int i = 0; i < linhas.Count; i++)
        {
            if (i == 0)
            {
                continue;
            }
            string[] colunas = linhas[i].Split(';');
            
            clienteInteresseImovel = new ClienteInteresseImovel();

            //Se a coluna na posicao 10 for diferente de zero
            if (!string.IsNullOrEmpty(colunas[10]))
            {
                //Se a coluna na posicao 10 tiver o |, buscar o imovel que estao saparados pelo PIPE
                string[] imoveisReferencia = colunas[10].Split("|");
                foreach (var imovelReferencia in imoveisReferencia)
                {
                    //Buscar o valor venal do imovel (valor pedido pelo proprietario) na planilha, no campo interesse, esta o nome do imovel
                    //Buscar o valor venal do imovel pelo nome do imovel

                    List<Imovel> imoveisEncontrados = _context.IMOVEIS.AsNoTracking().Where(n => n.Nome == imovelReferencia).ToList();

                    Cliente clienteEncontrado = _context.CLIENTES.AsNoTracking().FirstOrDefault(d => d.Documento == colunas[1]);

                    foreach (var imovelEncontrado in imoveisEncontrados)
                    {
                        clienteInteresseImovel = new ClienteInteresseImovel();

                        
                        clienteInteresseImovel.ClienteId = clienteEncontrado.Id;
                        clienteInteresseImovel.ImovelId = imovelEncontrado.Id;
                        clienteInteresseImovel.ClienteOferta = decimal.Parse(colunas[8], new System.Globalization.CultureInfo("pt-BR"));

                        

                        _context.CLIENTEINTERESSEIMOVEIS.Add(clienteInteresseImovel);
                        _context.SaveChanges();
                    }

                }
                //Busca imovel pelo NomedoImovel
                //Calcular o percentual da oferta (pode ser positivo ou negativo)
                //inserir registro na tabela "ClienteInteresseImoveis"
            }
        }
            return Ok();
    }
}



