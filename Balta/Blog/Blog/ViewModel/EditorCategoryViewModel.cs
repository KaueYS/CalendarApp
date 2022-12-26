using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModel
{
    public class EditorCategoryViewModel
    {
        [Required(ErrorMessage =" O erro e obrigatorio")]
        [StringLength(40, MinimumLength =3)]
        public string Name { get; set; }

        [Required(ErrorMessage = " O erro e obrigatorio")]
        public string Slug { get; set; }
    }
}
