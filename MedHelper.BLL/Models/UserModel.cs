using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedHelper.BLL.Models
{
    public partial class UserModel: BaseModel
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public int RoleId { get; set; }
        public int[] PatientsId { get; set; }
        public virtual RoleModel Role{ get; set; }
        public virtual List<PatientModel> Patients { get; set; }
    }
}
