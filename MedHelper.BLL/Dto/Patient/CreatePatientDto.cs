using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MedHelper.BLL.Dto.Responses;
using MedHelper.BLL.Enums;

namespace MedHelper.BLL.Dto.Patient
{
    public class CreatePatientDto
    {
        private DateTime _birthdate;
        
        [Required] 
        public string LastName { get; set; }
        
        [Required] 
        public string FirstName { get; set; }
        
        [Required] 
        [EnumDataType(typeof(Gender))]
        public string Gender { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime Birthdate
        {
            get { return _birthdate; }
            set
            {
                _birthdate = Convert.ToDateTime(value);
            }
        }
        
        public string TempMedicines { get; set; }
        public string TempDiseases { get; set; }

        public List<TempMedicineResponse> Medicines { get; set; }
        public List<DiseaseResponse> Diseases { get; set; }
        
        public int UserId { get; set; }
    }
}