using MedHelper.BLL.Dto.Responses;
using MedHelper.BLL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedHelper.BLL.Dto.Patient
{
    public class UpdatePatientDto : CreatePatientDto
    {
        private DateTime _birthdate;

        public int Id { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        [EnumDataType(typeof(Gender))]
        public string Gender { get; set; }

        [Required]
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
    }
}