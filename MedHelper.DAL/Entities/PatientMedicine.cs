using System;
using System.Collections.Generic;
using System.Text;

namespace MedHelper.DAL.Entities
{
    public class PatientMedicine: BaseEntity
    {
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
