using System.Collections.Generic;
namespace MedHelper.BLL.Dto.Responses
{
    public class DoctorResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        
         public List<MedHelper.DAL.Entities.Patient> Patients { get; set; }
    }
}