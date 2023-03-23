namespace ImobiliariaMVC.Models
{
    public class ClienteInteresseImovel
    {
        public int ClienteInteresseImovelId { get; set; }
        public int ClienteId { get; set; }
        public int ImovelId { get; set; }


        public decimal ValorDoImovel { get; set; }
        public decimal ValorDisponivel { get; set; }


        public Cliente Cliente { get; set; }
        public Imovel Imovel { get; set; }
    }
}
