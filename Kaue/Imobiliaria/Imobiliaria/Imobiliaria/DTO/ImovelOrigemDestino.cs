using Imobiliaria.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Imobiliaria.DTO
{
    public class ImovelOrigemDestino
    {
        [DisplayName("Vendedor")]
        public Cliente ClienteId { get; set; }

        [DisplayName("Imovel do vendendor")]
        public string NomeDoImovelVenda { get; set; }

        [DisplayName("Aceita troca por")]
        public string NomeDoImovelCompra { get; set; }

        [DisplayName("Nome do interessado")]
        public Cliente Cliente{ get; set; }
        public Cliente Nome { get; set; }
    }
}
