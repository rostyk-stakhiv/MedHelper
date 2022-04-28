using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedHelper.BLL.Models
{
    public partial class MedicineModel : BaseModel
    {
      
        public int MedicineID { get; set; }
        public string Name { get; set; }
        public int UserID { get; set; }
        public int PharmacotherapeuticGroupID { get; set; }
        public virtual UserModel User { get; set; }
        public virtual PharmacotherapeuticGroupModel Group { get; set; }
        public virtual ICollection<MedicineContraindicationModel> MedicineContraindications { get; set; }
        public virtual ICollection<MedicineCompositionModel> MedicineCompositions { get; set; }
        public virtual ICollection<MedicineInteractionModel> MedicineInteractions { get; set; }
        public virtual ICollection<PatientMedicineModel> PatientMedicines { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}