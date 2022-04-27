using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedHelper.DAL.Entities
{
    public partial class User : BaseEntity
    {
        public User()
        {
            this.Patients = new HashSet<Patient>();
            this.Medicines = new HashSet<Medicine>();
        }

        public int UserID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public int RoleID { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
        public virtual ICollection<Medicine> Medicines { get; set; }
    }
}