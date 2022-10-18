using System;
using System.ComponentModel.DataAnnotations;

namespace WebMVC.Models
{
    public class IdentityLoginUserViewModel
    {
        [Required(ErrorMessage = "Obrigatório informar o E-mail")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail inválido")]
        [Display(Description = "E-mail", Prompt = "Informe seu E-mail")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Obrigatório informar a Senha")]
        [DataType(DataType.Password)]
        [Display(Description = "Senha", Prompt = "Informe sua Senha")]
        public string Password { get; set; }
    }
}