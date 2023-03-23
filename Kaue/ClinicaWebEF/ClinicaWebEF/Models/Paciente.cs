namespace ClinicaWebEF.Models
{
    public class Paciente
    {
        public int PacienteId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        
        public List<Procedimento> ProcedimentoList { get; set; }

    }
}
