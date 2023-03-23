using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = " Nome Obrigatorio")]
        public string Name { get; set; }

        [Required(ErrorMessage = " Email Obrigatorio")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
