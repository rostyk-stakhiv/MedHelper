using System;
using System.Collections.Generic;
using System.Text;

namespace MedHelper.DAL.Entities
{
    public class MedicineComposition: BaseEntity
    {
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }

        public int CompositionId { get; set; }
        public Composition Composition { get; set; }
    }
}
