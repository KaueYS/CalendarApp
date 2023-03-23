using Contatos.Models;

namespace Contatos.Repositorio
{
    public interface IContatoRepositorio
    {
        bool Apagar(int id);
        ContatoModel Atualizar(ContatoModel contato); 
        ContatoModel ListarPorId(int id);
        List<ContatoModel> GetContatoList();
        ContatoModel Adicionar(ContatoModel contato);
    }
}
