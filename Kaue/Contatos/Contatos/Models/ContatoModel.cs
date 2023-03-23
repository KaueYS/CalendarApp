using System.ComponentModel.DataAnnotations;

namespace Contatos.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Necessario digitar um nome")]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Necessario digitar um Email")]
        [EmailAddress]
        [StringLength(50)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Necessario digitar numero de telefone")]
        [StringLength(15)]
        [Phone]
        public string Telefone { get; set; }
    }
}
