using System;
using System.Collections.Generic;
using System.Text;

namespace MedHelper.DAL.Entities
{
    public class PharmacotherapeuticGroup:BaseEntity
    {
        public string Title { get; set; }

        public List<Medicine> Medicines { get; set; }
    }
}