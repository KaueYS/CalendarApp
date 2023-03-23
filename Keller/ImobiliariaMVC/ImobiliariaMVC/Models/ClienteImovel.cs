namespace ImobiliariaMVC.Models
{
    public class ClienteImovel
    {
        public int ClienteImovelId { get; set; }

        public int ClienteId { get; set; }
        public int ImovelId { get; set; }

        public Cliente Cliente { get; set; }
        public Imovel Imovel { get; set; }
    }
}
