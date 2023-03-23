namespace WebMVCImobiliaria.ViewModel
{
    public class ImovelViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime CriadoEm { get; set; } = DateTime.Now;
        public decimal Valor { get; set; }

        public string Tipo { get; set; }
        public string Referencia { get; set; }
    }
}
