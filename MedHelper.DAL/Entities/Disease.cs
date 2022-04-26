using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedHelper.DAL.Entities
{
    public partial class Disease : BaseEntity
    {
        public Disease()
        {
            this.PatientDiseases = new HashSet<PatientDisease>();
            this.MedicineContraindications = new HashSet<MedicineContraindication>();
        }

        public int DiseaseID { get; set; }
        public string Title { get; set; }

        public virtual ICollection<PatientDisease> PatientDiseases { get; set; }
        public virtual ICollection<MedicineContraindication> MedicineContraindications { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}