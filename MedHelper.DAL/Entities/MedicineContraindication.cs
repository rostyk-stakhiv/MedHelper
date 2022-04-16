using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedHelper.DAL.Entities
{
    public partial class MedicineContraindication
    {
        public int MedicineContraindicationID { get; set; }
        public int MedicineID { get; set; }
        public int DiseaseID { get; set; }

        public virtual Disease Disease { get; set; }
        public virtual Medicine Medicine { get; set; }
    }
}
