using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedHelper.BLL.Models
{
    public partial class MedicineCompositionModel
    {
        public int MedicineId { get; set; }
        public int CompositionId { get; set; }

        public virtual CompositionModel Composition { get; set; }
        public virtual MedicineModel Medicine { get; set; }
    }
}
