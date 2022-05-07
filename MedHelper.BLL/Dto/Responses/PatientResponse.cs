using System;
using System.Collections.Generic;

namespace MedHelper.BLL.Dto.Responses
{
    public class PatientResponse
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Gender { get; set; }
        public DateTime Birthdate { get; set; }

        public List<DiseaseResponse> Diseases { get; set; }
        public List<MedicineResponse> Medicines { get; set; }


        public List<MedicineResponse>? AllMedicines { get; set; }
        public string? search { get; set; }
    }
}