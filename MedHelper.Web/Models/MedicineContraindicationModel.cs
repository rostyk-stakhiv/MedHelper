using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedHelper.Web.Models
{
    public partial class MedicineContraindicationModel
    {
        public int MedicineContraindicationID { get; set; }
        public int MedicineID { get; set; }
        public int DiseaseID { get; set; }

        public virtual DiseaseModel Disease { get; set; }
        public virtual MedicineModel Medicine { get; set; }
    }
}