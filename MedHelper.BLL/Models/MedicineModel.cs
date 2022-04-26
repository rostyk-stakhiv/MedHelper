﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedHelper.BLL.Models
{
    public partial class MedicineModel: BaseModel
    {
        public string Name { get; set; }
        public int PharmacotherapeuticGroupId { get; set; }
        public int[] ContraindicationsId { get; set; }
        public int[] CompositionsId { get; set; }
        public virtual PharmacotherapeuticGroupModel Group { get; set; }
        public virtual List<DiseaseModel> Contraindications { get; set; }
        public virtual List<CompositionModel> Compositions { get; set; }
        public virtual ICollection<MedicineInteractionModel> MedicineInteractions { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}