using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedHelper.BLL.Enums;

namespace MedHelper.BLL.Models
{
    public partial class PatientModel: BaseModel
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }

        [EnumDataType(typeof(Gender))]
        public string Gender { get; set; }
        public int UserID { get; set; }
        public DateTime Birthdate { get; set; }
        public int[] DiseasesId { get; set; }
        public int[] MedicinesId { get; set; }
        public virtual UserModel User { get; set; }
        public virtual List<DiseaseModel> Diseases { get; set; }
        public virtual List<MedicineModel> Medicines { get; set; }
    }
}
