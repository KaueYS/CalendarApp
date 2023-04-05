using System.ComponentModel;
using WebIMOBMentoria.Models;

namespace WebIMOBMentoria.ViewModel
{
    public class ImovelViewModel
    {
        public int ImovelId { get; set; }

        [DisplayName("Venda")]
        public string ImovelNomeVenda { get; set; }

        [DisplayName("Valor")]
        public decimal ValorDoImovel { get; set; }

        [DisplayName("Interesse")]
        public string ImovelNomeCompra { get; set; }


        public int ClienteId { get; set; }
        public ICollection<Cliente> Clientes { get; set;} 
    }
}
