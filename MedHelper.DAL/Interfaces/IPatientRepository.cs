using MedHelper.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedHelper.DAL.Interfaces
{
    public interface IPatientRepository:IRepository<Patient>
    {
        IEnumerable<Patient> GetAllWithDetails();
        IEnumerable<Patient> GetPatients(int id, string search);
        Task<Patient> GetByIdWithDetailsAsync(int id);
        void UpdateWithDelete(Patient patient);
    }
}
