using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedHelper.BLL.Models
{
    public partial class UserModel : BaseModel
    {
        public UserModel()
        {
            this.Patients = new HashSet<PatientModel>();
            this.Medicines = new HashSet<MedicineModel>();
        }

        public int UserID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public int RoleID { get; set; }

        public virtual RoleModel Role { get; set; }
        public virtual ICollection<PatientModel> Patients { get; set; }
        public virtual ICollection<MedicineModel> Medicines { get; set; }
    }
}