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

        [Required] 
        public string TempMedicines { get; set; }
        
        [Required] 
        public string TempDiseases { get; set; }
        
        // [Required] 
        public List<MedicineResponse> Medicines { get; set; }
        
        // [Required] 
        public List<DiseaseResponse> Diseases { get; set; }
        
        public int UserId { get; set; }
        public virtual User User { get; set; } 
    }
}