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

        public List<Patient> Patients { get; set; }
        public List<Medicine> MedicineContraindications { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}