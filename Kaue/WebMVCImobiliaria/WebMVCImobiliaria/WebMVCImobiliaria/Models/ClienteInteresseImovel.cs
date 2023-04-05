namespace WebMVCImobiliaria.Models
{
    public class ClienteInteresseImovel
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int ImovelId { get; set; }
        
        public decimal ClienteOferta { get; set; }
        

        public Cliente Cliente { get; set; }
        public Imovel Imovel { get; set; }
    }
}
