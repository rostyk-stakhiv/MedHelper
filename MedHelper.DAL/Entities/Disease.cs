using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedHelper.DAL.Entities
{
    public partial class Disease : BaseEntity
    {
        public string Title { get; set; }

        public List<PatientDisease> PatientDiseases { get; set; }
        public List<MedicineContraindication> MedicineContraindications { get; set; }
    }
}