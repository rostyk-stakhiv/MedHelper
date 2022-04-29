using System.Collections.Generic;

namespace MedHelper_API.Responses
{
    public class DoctorResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        
        // public List<PatientResponse>? Patients { get; set; }
    }
}