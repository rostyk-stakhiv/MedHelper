using System;
using System.Collections.Generic;
using System.Text;

namespace MedHelper.BLL.Models
{
    public class PharmacotherapeuticGroupModel
    {
        public PharmacotherapeuticGroupModel()
        {
            this.Medicines = new HashSet<MedicineModel>();
        }

        public int PharmacotherapeuticGroupID { get; set; }
        public string Title { get; set; }

        public virtual ICollection<MedicineModel> Medicines { get; set; }
    }
}