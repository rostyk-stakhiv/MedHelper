using System;
using System.Collections.Generic;
using System.Text;

namespace MedHelper.DAL.Entities
{
    public class PharmacotherapeuticGroup
    {
        public PharmacotherapeuticGroup()
        {
            this.Medicines = new HashSet<Medicine>();
        }

        public int PharmacotherapeuticGroupID { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Medicine> Medicines { get; set; }
    }
}
