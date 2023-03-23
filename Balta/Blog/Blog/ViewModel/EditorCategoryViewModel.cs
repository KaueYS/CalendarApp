using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModel
{
    public class EditorCategoryViewModel
    {
        private const string MaxMin = "Digite um valor entre 3 a 40 caracteres";
        private const string N = "O Nome 'e Obrigatorio";
        private const string S = "O Slug 'e Obrigatorio";


        [Required(ErrorMessage = N)]
        [StringLength(40, MinimumLength =3, ErrorMessage = MaxMin)]
        public string Name { get; set; }

        [Required(ErrorMessage = S)]
        public string Slug { get; set; }
    }
}
