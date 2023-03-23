using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaWEB.ViewModel
{
    public class ProcedimentoViewModel
    {

        [Required(ErrorMessage = "Informe o nome do Procedimento")]
        [Display(Name = "Nome do procedimento")]
        [EmailAddress]
        public string Nome { get; }

        [Required(ErrorMessage = "Informe o preço do procedimento escolhido")]
        [Display(Name = "Preço")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Preco { get; set; }

    }
}
