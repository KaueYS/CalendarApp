using System;
using System.ComponentModel.DataAnnotations;

namespace WebMVC.Models
{
    public class IdentityLoginUserViewModel
    {
        [Required(ErrorMessage = "Obrigat�rio informar o {0}")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail inv�lido")]
        [Display(Description = "E-mail", Prompt = "Informe seu E-mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Obrigat�rio informar a {0}")]
        [DataType(DataType.Password)]
        [Display(Description = "Senha", Prompt = "Informe sua Senha")]
        public string Password { get; set; }
    }
}