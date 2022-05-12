using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MedHelper.BLL.Dto.Responses;
using MedHelper.BLL.Enums;
using MedHelper.DAL.Entities;

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
        
        public string TempMedicines { get; set; }
        public string TempDiseases { get; set; }

        public List<TempMedicineResponse> Medicines { get; set; }
        public List<DiseaseResponse> Diseases { get; set; }
        
        public int UserId { get; set; }
    }
}