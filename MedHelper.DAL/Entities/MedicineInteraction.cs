using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedHelper.DAL.Entities
{
    public partial class MedicineInteraction : BaseEntity
    {
        public string Description { get; set; }

        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }

        public int CompositionId { get; set; }
        public Composition Composition { get; set; }
    }
}