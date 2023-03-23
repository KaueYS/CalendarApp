namespace WebMVCImobiliaria.Models
{
    public class ClienteImovel
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int ImovelId { get; set; }

        public Cliente Cliente { get; set; }
        public Imovel Imovel { get; set; }

    }
}
