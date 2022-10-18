using System.Collections.Generic;

namespace WebMVC.Models
{
    public class PatientGroupDTO
    {
        public string Text { get; set; }
        public List<PatientDTO> Children { get; set; }
    }
}
