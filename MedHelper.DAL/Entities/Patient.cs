using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedHelper.DAL.Enums;

namespace MedHelper.DAL.Entities
{
    public partial class Patient : BaseEntity
    {
        public Patient()
        {
            PatientDiseases = new HashSet<PatientDisease>();
            PatientMedicines = new HashSet<PatientMedicine>();
        }

        public int PatientID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        [EnumDataType(typeof(Gender))]
        public string Gender { get; set; }

        public int UserID { get; set; }
        public DateTime Birthdate { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<PatientDisease> PatientDiseases { get; set; }
        public virtual ICollection<PatientMedicine> PatientMedicines { get; set; }
    }
}