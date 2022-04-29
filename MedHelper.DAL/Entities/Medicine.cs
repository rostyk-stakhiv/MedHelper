using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedHelper.DAL.Entities
{
    public partial class Medicine : BaseEntity
    {
        public string Name { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int PharmacotherapeuticGroupId { get; set; }
        public PharmacotherapeuticGroup Group { get; set; }

        public List<Patient> Patients { get; set; }
        public List<Disease> Contraindications { get; set; }

        public List<Composition> Compositions { get; set; }
        public List<MedicineInteraction> MedicineInteractions { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}