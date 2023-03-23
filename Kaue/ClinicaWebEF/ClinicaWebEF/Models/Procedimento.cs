namespace ClinicaWebEF.Models
{
    public class Procedimento
    {
        public int ProcedimentoId { get; set; }
        public string? Nome { get; }
        public decimal Preco { get; set; }
        
        public int PacienteId { get; set; }
    }
}
