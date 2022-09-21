using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    [Route("/api/[controller]/[action]")]
    public class CoreController : Controller
    {
        [HttpGet]
        public async Task<List<PatientGroupDTO>> GetPatients()
        {
            List<PatientGroupDTO> patientsGroups = new List<PatientGroupDTO>();
            PatientGroupDTO group = new PatientGroupDTO();
            group.Children = new List<PatientDTO>();

            group.Text = "Grupo A";
            
            PatientDTO patient = new PatientDTO();
            patient.Id = 1;
            patient.Text = "Alberto";
            group.Children.Add(patient);

            patient = new PatientDTO();
            patient.Id = 2;
            patient.Text = "Afonso";
            group.Children.Add(patient);


            patientsGroups.Add(group);
            
            group = new PatientGroupDTO();
            group.Children = new List<PatientDTO>();
            group.Text = "Grupo B";

            patient = new PatientDTO();
            patient.Id = 3;
            patient.Text = "Beto";
            group.Children.Add(patient);

            patientsGroups.Add(group);

            return await Task.FromResult(patientsGroups);
        }
        [HttpPost]
        public async Task SaveAppointment([FromBody]AppointmentSaveViewModel appointmentSaveViewModel)
        {

        }


    }
}
