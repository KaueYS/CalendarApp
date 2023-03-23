using Contatos.Data;
using Contatos.Models;
using Microsoft.EntityFrameworkCore;

namespace Contatos.Repositorio;

public class ContatoRepositorio : IContatoRepositorio
{
    private readonly AppDbContext _context;

    public ContatoRepositorio(AppDbContext context)
    {
        _context = context;
    }

    public ContatoModel Adicionar(ContatoModel contato)
    {
        _context.CONTATOS.Add(contato);
        _context.SaveChanges();
        return contato;
    }

    public bool Apagar(int id)
    {
        ContatoModel contatosdb = ListarPorId(id);
        if (contatosdb is null) throw new Exception("Erro, NULO");

        _context.CONTATOS.Remove(contatosdb);
        _context.SaveChanges();
        return true;
    }

    public ContatoModel Atualizar(ContatoModel contato)
    {
        ContatoModel contatosdb = ListarPorId(contato.Id);
        if (contatosdb is null)
        {
            Results.NotFound();
        }
        contatosdb.Nome = contato.Nome;
        contatosdb.Email = contato.Email;
        contatosdb.Telefone = contato.Telefone;

        _context.CONTATOS.Update(contatosdb);
        _context.SaveChanges();
        return contatosdb;

    }

    public List<ContatoModel> GetContatoList()
    {
        return _context.CONTATOS.ToList();
    }

    public ContatoModel ListarPorId(int id)
    {
        return _context.CONTATOS.FirstOrDefault(x => x.Id == id);
    }


}
