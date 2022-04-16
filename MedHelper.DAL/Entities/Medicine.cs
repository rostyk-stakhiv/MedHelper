using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedHelper.DAL.Entities
{
    public partial class Medicine: BaseEntity
    {
        public Medicine()
        {
            this.MedicineContraindications = new HashSet<MedicineContraindication>();
            this.MedicineCompositions = new HashSet<MedicineComposition>();
            this.MedicineInteractions = new HashSet<MedicineInteraction>();
            this.PatientMedicines = new HashSet<PatientMedicine>();
        }

        public int MedicineID { get; set; }
        public string Name { get; set; }
        public int UserID { get; set; } 
        public int PharmacotherapeuticGroupID { get; set; }


        public virtual User User { get; set; }
        public virtual PharmacotherapeuticGroup Group { get; set; }
        public virtual ICollection<MedicineContraindication> MedicineContraindications { get; set; }
        public virtual ICollection<MedicineComposition> MedicineCompositions { get; set; }
        public virtual ICollection<MedicineInteraction> MedicineInteractions { get; set; }
        public virtual ICollection<PatientMedicine> PatientMedicines { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
