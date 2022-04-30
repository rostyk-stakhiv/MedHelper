using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedHelper.BLL.Dto.Medicine
{
    public class CreateMedicineDto
    {
        [Required] 
        public string Name { get; set; }

        // public int UserId { get; set; } має передаватись в сервіс з ауза

        public int PharmacotherapeuticGroupId { get; set; }
        
        [Required]
        public List<int> MedicineContraindicationsIds { get; set; }
        public List<int> MedicineCompositionsIds { get; set; }
        public List<int> MedicineInteractionsIds { get; set; }
    }
}