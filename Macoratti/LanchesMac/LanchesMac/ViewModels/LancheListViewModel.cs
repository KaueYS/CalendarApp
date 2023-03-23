using LanchesMac.Models;

namespace LanchesMac.ViewModels
{
    public class LancheListViewModel
    {
        public IEnumerable<Lanche> LanchesVM { get; set; }
        public string  CategoriaAtual { get; set; }
    }
}
