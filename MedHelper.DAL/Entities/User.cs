﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedHelper.DAL.Entities
{
    public partial class User: BaseEntity
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public int RoleId { get; set; }
        public List<int> PatientsId { get; set; }
        public virtual Role Role{ get; set; }
        public virtual List<Patient> Patients { get; set; }
    }
}
