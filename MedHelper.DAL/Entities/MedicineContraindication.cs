using System;
using System.Collections.Generic;
using System.Text;

namespace MedHelper.DAL.Entities
{
    public class MedicineContraindication: BaseEntity
    {
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }

        public int ContraindicationId { get; set; }
        public Disease Contraindication { get; set; }
    }
}
