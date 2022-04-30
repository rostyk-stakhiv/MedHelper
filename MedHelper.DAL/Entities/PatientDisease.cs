using System;
using System.Collections.Generic;
using System.Text;

namespace MedHelper.DAL.Entities
{
    public class PatientDisease: BaseEntity
    {
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public int DiseaseId { get; set; }
        public Disease Disease { get; set; }
    }
}
