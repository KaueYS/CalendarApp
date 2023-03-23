using System.Text.Json.Serialization;

namespace ClinicaWEB.Models
{
    public class Procedimento
    {
        public int ProcedimentoId { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        
        public int PacienteId { get; set; }
        
    }
}
