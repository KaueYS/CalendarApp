namespace ImobiliariaAPI.ViewModel
{
    public class ImovelViewModel
    {
        public int Id { get; set; }
        public string ImovelNome { get; set; }
        public string Endereco { get; set; }
        public Double ValorPedido { get; set; }
        public DateTime CriadoEm { get; set; } 
        public string Descricao { get; set; }
        public string ImovelParaTroca { get; set; }
        public double ValorDisponivelParaVolta { get; set; }
        public int ClienteId { get; set; }
    }
}


