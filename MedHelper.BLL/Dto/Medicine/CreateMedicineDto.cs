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
        
        public string TempPharmacotherapeuticGroup { get; set; }
        public string TempMedicineContraindications { get; set; }
        public string TempMedicineCompositions { get; set; }
    }
}