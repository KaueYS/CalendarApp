using System.ComponentModel;

namespace WebIMOBMentoria.Models
{
    public class Imovel
    {
        

        public int ImovelId { get; set; }
        public string ImovelNomeVenda { get; set; }
        public decimal ValorDoImovel { get; set; }
        public string ImovelNomeCompra { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set;}

    }
}
