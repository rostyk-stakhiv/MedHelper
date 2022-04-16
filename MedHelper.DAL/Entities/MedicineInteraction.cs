using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedHelper.DAL.Entities
{
    public partial class MedicineInteraction: BaseEntity
    {
        public int MedicineInteractionID { get; set; }
        public string Description { get; set; }
        public int MedicineID { get; set; }
        public int CompositionID { get; set; }

        public virtual Composition Composition { get; set; }
        public virtual Medicine Medicine { get; set; }
    }
}
