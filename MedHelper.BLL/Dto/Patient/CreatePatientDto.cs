using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MedHelper.BLL.Dto.Responses;
using MedHelper.BLL.Enums;

namespace MedHelper.BLL.Dto.Patient
{
    public class CreatePatientDto
    {
        [Required] 
        public string LastName { get; set; }
        
        [Required] 
        public string FirstName { get; set; }
        
        [Required] 
        [EnumDataType(typeof(Gender))]
        public string Gender { get; set; }

        [Required] 
        public DateTime Birthdate { get; set; }

        // [Required] 
        public List<MedicineResponse> Medicines { get; set; }
        
        // [Required] 
        public List<DiseaseResponse> Diseases { get; set; }
        
        [Required] 
        public List<string> TempMedicines { get; set; }
        
        [Required] 
        public List<string> TempDiseases { get; set; }
    }
}