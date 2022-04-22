using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedHelper.BLL.Models
{
    public partial class MedicineCompositionModel
    {
        public int MedicineID { get; set; }
        public int CompositionID { get; set; }

        public virtual CompositionModel Composition { get; set; }
        public virtual MedicineModel Medicine { get; set; }
    }
}
