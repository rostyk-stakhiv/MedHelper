﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedHelper.DAL.Entities
{
    public partial class Medicine: BaseEntity
    {
        public string Name { get; set; }
        public int PharmacotherapeuticGroupId { get; set; }
        public List<int> ContraindicationsId { get; set; }
        public List<int> CompositionsId { get; set; }
        public virtual PharmacotherapeuticGroup Group { get; set; }
        public virtual List<Disease> Contraindications { get; set; }
        public virtual List<Composition> Compositions { get; set; }
        public virtual ICollection<MedicineInteraction> MedicineInteractions { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
