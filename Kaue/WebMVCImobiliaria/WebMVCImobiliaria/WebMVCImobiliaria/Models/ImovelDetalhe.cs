namespace WebMVCImobiliaria.Models
{
    public class ImovelDetalhe
    {
        public int Id { get; set; }
        public string Quarto { get; set; }
        
        public Imovel Imovel { get; set; }
        public int ImovelId { get; set; }
        
    }
}
