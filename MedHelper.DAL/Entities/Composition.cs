﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedHelper.DAL.Entities
{
    public partial class Composition : BaseEntity
    {
        public Composition()
        {
            MedicineCompositions = new HashSet<MedicineComposition>();
            MedicineInteractions = new HashSet<MedicineInteraction>();
        }

        public int CompositionID { get; set; }
        public string Description { get; set; }

        public virtual ICollection<MedicineComposition> MedicineCompositions { get; set; }
        public virtual ICollection<MedicineInteraction> MedicineInteractions { get; set; }
    }
}