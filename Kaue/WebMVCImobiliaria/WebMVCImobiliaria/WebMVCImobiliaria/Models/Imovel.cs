using WebMVCImobiliaria.Tipos;

namespace WebMVCImobiliaria.Models
{
    public class Imovel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime CriadoEm { get; set; } = DateTime.Now;
        public decimal Valor { get; set; }
        
        public string Tipo { get; set; }
        public string Referencia { get; set; }
        public ImovelSituacao Situacao { get; set; }
    }

    
}
