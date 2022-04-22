﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedHelper.DAL.Entities
{
    public partial class MedicineInteraction: BaseEntity
    {
        public string Description { get; set; }
        public int MedicineId { get; set; }
        public int CompositionId { get; set; }

        public virtual Composition Composition { get; set; }
        public virtual Medicine Medicine { get; set; }
    }
}
