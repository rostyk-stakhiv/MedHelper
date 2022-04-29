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
        public string LastName { get; set; }
        public string FirstName { get; set; }

        [EnumDataType(typeof(Gender))]
        public string Gender { get; set; }

        public DateTime Birthdate { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public List<Disease> Diseases { get; set; }
        public List<Medicine> Medicines { get; set; }
    }
}