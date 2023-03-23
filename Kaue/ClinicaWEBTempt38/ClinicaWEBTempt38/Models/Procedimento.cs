namespace ClinicaWEBTempt38.Models
{
    public class Procedimento
    {
        public int ProcedimentoId { get; set; }
        public string ProcedimentoNome { get; set; }
        public decimal ProcedimentoPreco { get; set; }
        public DateTime Criado { get; set; } = DateTime.Now;

    }
}
