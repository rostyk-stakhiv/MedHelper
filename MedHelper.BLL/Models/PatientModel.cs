using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedHelper.DAL.Enums;

namespace MedHelper.BLL.Models
{
    public partial class PatientModel : BaseModel
    {
        public PatientModel()
        {
            PatientDiseases = new HashSet<PatientDiseaseModel>();
            PatientMedicines = new HashSet<PatientMedicineModel>();
        }

        public int PatientID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        [EnumDataType(typeof(Gender))]
        public string Gender { get; set; }

        public int UserID { get; set; }
        public DateTime Birthdate { get; set; }
        public virtual UserModel User { get; set; }
        public virtual ICollection<PatientDiseaseModel> PatientDiseases { get; set; }
        public virtual ICollection<PatientMedicineModel> PatientMedicines { get; set; }
    }
}