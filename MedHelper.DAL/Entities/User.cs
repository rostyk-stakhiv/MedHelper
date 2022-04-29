using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedHelper.DAL.Entities
{
    public partial class User : BaseEntity
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<UserRole> UserRoles { get; set; }

        public List<Patient> Patients { get; set; }
        public List<Medicine> Medicines { get; set; }
    }
}