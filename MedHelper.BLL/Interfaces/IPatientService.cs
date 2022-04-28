using MedHelper.BLL.Models;
using MedHelper.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedHelper.BLL.Interfaces
{
    public interface IPatientService:ICrud<Patient>
    {
        public IEnumerable<Medicine> GetAllMedicines();
    }
}
