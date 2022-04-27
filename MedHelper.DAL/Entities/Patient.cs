using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedHelper.DAL.Enums;

namespace MedHelper.DAL.Entities
{
    public partial class Patient: BaseEntity
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }

        [EnumDataType(typeof(Gender))]
        public string Gender { get; set; }
        public int UserID { get; set; }
        public DateTime Birthdate { get; set; }
        public List<int> DiseasesId { get; set; }
        public List<int> MedicinesId { get; set; }
        public virtual User User { get; set; }
        public virtual List<Disease> Diseases { get; set; }
        public virtual List<Medicine> Medicines { get; set; }
    }
}
