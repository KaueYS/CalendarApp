using ClinicaWEB.Models;

namespace ClinicaWEB.Repository.Contract
{
    public interface IPacienteRepository
    {
        List<Paciente> GetList();
        Paciente GetById(int id);
        Paciente Post(Paciente paciente);
        Paciente Put(Paciente paciente);
        Paciente Delete(int id);
    }
}
