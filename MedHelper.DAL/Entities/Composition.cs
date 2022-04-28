using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedHelper.DAL.Entities
{
    public partial class Composition : BaseEntity
    {
        public string Description { get; set; }

        public List<Medicine> Medicines { get; set; }
        public List<MedicineInteraction> MedicineInteractions { get; set; }
    }
}