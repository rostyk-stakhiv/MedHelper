using System;
using System.Collections.Generic;
using MedHelper.DAL.Entities;

namespace MedHelper_API.Responses
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
    }
}