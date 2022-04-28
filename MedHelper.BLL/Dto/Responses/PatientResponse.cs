using System.Collections.Generic;

namespace MedHelper_API.Responses
{
    public class PatientResponse
    {
        public int PatientID { get; set; }
        public string UserName { get; set; }
        public string Gender { get; set; }
        public System.DateTime Birthdate { get; set; }
        public int DoctorID { get; set; }
        public List<MedicineResponse> Medicines { get; set; }
        public List<DiseaseResponse> Diseases { get; set; }
    }
}