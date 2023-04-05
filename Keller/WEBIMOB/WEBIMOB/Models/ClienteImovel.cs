using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBIMOB.Models
{
    public class ClienteImovel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Obrigatorio o nome do Cliente")]
        [StringLength(50)]
        [DisplayName("Proprietario")]
        public string Cliente { get; set;}

        [Required]
        [StringLength(40)]
        [EmailAddress]
        
        public string Email { get; set; }

        [Required]
        [StringLength(15)]
        [Phone]
        [DisplayName("Celular")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "Obrigatorio o nome do Imovel")]
        [StringLength(50)]
        [DisplayName("Imovel")]
        public string Imovel { get; set; }

        [StringLength(15)]
        [DisplayName("Referencia")]
        public string? Referencia { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        [DisplayName("Valor")]
        public decimal Valor { get; set; }


        [StringLength(50)]
        [DisplayName("Permuta")]
        public string? Permuta { get; set; }

        [DisplayName("Data do Cadastro")]
        public DateTime CriadoEm { get; set; }

    }
}
