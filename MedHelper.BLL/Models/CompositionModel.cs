using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedHelper.BLL.Models
{
    public partial class CompositionModel : BaseModel
    {
        public int CompositionID { get; set; }
        public string Description { get; set; }

        public virtual ICollection<MedicineCompositionModel> MedicineCompositions { get; set; }
        public virtual ICollection<MedicineInteractionModel> MedicineInteractions { get; set; }
    }
}