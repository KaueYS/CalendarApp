using WebIMOBMentoria.Models;

namespace WebIMOBMentoria.ViewModel
{
    public class ImovelViewModel
    {
        public Imovel Imovel  { get; set; } 
        public ICollection<Cliente> Clientes { get; set;} 
    }
}
