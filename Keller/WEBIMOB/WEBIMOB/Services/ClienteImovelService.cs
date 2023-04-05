using WEBIMOB.Context;
using WEBIMOB.Models;

namespace WEBIMOB.Services
{
    public class ClienteImovelService
    {
        private readonly AppDbContext _context;

        public ClienteImovelService(AppDbContext context)
        {
            _context = context;
        }

        public List<ClienteImovel> ProcurarClientesImoveis()
        {
            return _context.CLIENTESIMOVEIS.ToList();
        }
    }
}
