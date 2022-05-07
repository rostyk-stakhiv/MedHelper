using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MedHelper.DAL.Enums;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MedHelper.DAL.Entities
{
    public partial class User : IdentityUser<int>
    {
        [Required(ErrorMessage = "Please enter LastName.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter FirstFame.")]
        public string FirstName { get; set; }
        public string Password { get; set; }

        public List<Patient> Patients { get; set; }
        public List<Medicine> Medicines { get; set; }
    }
}