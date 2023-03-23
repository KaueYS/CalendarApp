using System.ComponentModel.DataAnnotations;

namespace ClinicaWEB.ViewModel
{
    public class PacienteViewModel
    {
        [Required(ErrorMessage = "Informe o nome do Paciente")]
        [Display(Name = "Nome do paciente")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o email do Paciente")]
        [Display(Name = "Email do paciente")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe o telefone do Paciente")]
        [Display(Name = "Telefone do paciente")]
        [Phone]
        public string Telefone { get; set; }
    }
}
