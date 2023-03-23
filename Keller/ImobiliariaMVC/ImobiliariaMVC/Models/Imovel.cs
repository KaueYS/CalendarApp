namespace ImobiliariaMVC.Models
{
    public class Imovel
    {
        public int ImovelId { get; set; }
        public string? NomeImovelVendendo { get; set; }
        public double Valor { get; set; }
        public string? NomeImovelComprando { get; set; }
        public double ValorDisponivel { get; set; }

        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

    }
}
