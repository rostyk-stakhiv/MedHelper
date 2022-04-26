using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedHelper.BLL.Models
{
    public partial class DiseaseModel : BaseModel
    {

        public int DiseaseID { get; set; }
        public string Title { get; set; }

        public virtual ICollection<PatientDiseaseModel> PatientDiseases { get; set; }
        public virtual ICollection<MedicineContraindicationModel> MedicineContraindications { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}