using Newtonsoft.Json;
using System.ComponentModel;

namespace Imobiliaria.Models
{
    public class Imovel
    {
        public int ImovelId { get; set; }

        [DisplayName("Nome do imovel para venda")]
        public string NomeDoImovelVenda { get; set; }

        [DisplayName("Aceita permuta por")]
        public string NomeDoImovelCompra { get; set; }
        [DisplayName("Valor Pedido")]
        public double ValorPedido { get; set; }
        [DisplayName("Valor disponivel para permuta")]
        public double ValorDisponivel { get; set; }

        [JsonIgnore]
        public Cliente Cliente { get; set; }
        [JsonIgnore]
        public int ClienteId { get; set; }
        

    }
}
