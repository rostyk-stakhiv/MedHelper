using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MedHelper.DAL.Entities;

namespace MedHelper.BLL.Dto.Medicine
{
    public class CreateMedicineDto
    {
        [Required] 
        public string Name { get; set; }

        public int UserId { get; set; }
        
        [Required] 
        public string TempPharmacotherapeuticGroup { get; set; }
        
        [Required] 
        public string TempMedicineContraindications { get; set; }
        
        [Required] 
        public string TempMedicineCompositions { get; set; }
    }
}