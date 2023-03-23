using ClinicaWEB.Models;
using ClinicaWEB.Repository.Contract;

namespace ClinicaWEB.Repository.Service
{

    public class PacienteRepository : IPacienteRepository
    {
        public readonly IPacienteRepository _pacienteRepository;

        public PacienteRepository(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        Paciente IPacienteRepository.Delete(int id)
        {
            throw new NotImplementedException();
        }

        Paciente IPacienteRepository.GetById(int id)
        {
            throw new NotImplementedException();
        }

        List<Paciente> IPacienteRepository.GetList()
        {
            throw new NotImplementedException();
        }

        Paciente IPacienteRepository.Post(Paciente paciente)
        {
            throw new NotImplementedException();
        }

        Paciente IPacienteRepository.Put(Paciente paciente)
        {
            throw new NotImplementedException();
        }
    }
}
