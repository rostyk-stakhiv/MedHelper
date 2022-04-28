using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedHelper.Web.Models
{
    public partial class PatientMedicineModel
    {
        public int PatientMedicineID { get; set; }
        public int MedicineID { get; set; }
        public int PatientID { get; set; }

        public virtual MedicineModel Medicine { get; set; }
        public virtual PatientModel Patient { get; set; }
    }
}