using System.ComponentModel;

namespace WebIMOBMentoria.Models
{
    public class Imovel
    {
        

        public int ImovelId { get; set; }

        [DisplayName("Venda")]
        public string ImovelNomeVenda { get; set; }

        [DisplayName("Valor")]
        public decimal ValorDoImovel { get; set; }

        [DisplayName("Interesse")]
        public string ImovelNomeCompra { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set;}

    }
}
