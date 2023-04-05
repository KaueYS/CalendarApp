using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WEBIMOB.Models;

namespace WEBIMOB.ViewModel
{
    public class ImovelPermutaModel
    {
        public int Id { get; set; }
        [DisplayName("Cliente Interessado")]
        public ClienteImovel ClienteComprador { get; set; }
        [DisplayName("Proprietario")]
        public ClienteImovel ClienteVendedor { get; set; }
        public int ClienteImovelId { get; set; }
        public string Imovel { get; set;}
        
    }
}
