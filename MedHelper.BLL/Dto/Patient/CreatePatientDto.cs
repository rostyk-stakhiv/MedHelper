using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedHelper.BLL.Dto.Patient
{
    public class CreatePatientDto
    {
        [Required] 
        public string LastName { get; set; }
        
        [Required] 
        public string FirstName { get; set; }
        
        [Required] 
        public string Gender { get; set; }
        
        [Required] 
        public DateTime Birthdate { get; set; }

        [Required] 
        public List<int> MedicineIds { get; set; }
        
        [Required] 
        public List<int> DiseasesIds { get; set; }
    }
}