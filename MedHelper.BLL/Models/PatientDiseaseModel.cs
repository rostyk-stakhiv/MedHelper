using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedHelper.BLL.Models
{
    public partial class PatientDiseaseModel
    {
        public int PatientDiseaseID { get; set; }
        public int PatientID { get; set; }
        public int DiseaseID { get; set; }

        public virtual DiseaseModel Disease { get; set; }
        public virtual PatientModel Patient { get; set; }
    }
}