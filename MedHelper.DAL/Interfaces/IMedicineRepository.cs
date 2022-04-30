using MedHelper.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedHelper.DAL.Interfaces
{
    public interface IMedicineRepository:IRepository<Medicine>
    {
        IEnumerable<Medicine> GetAllWithDetails();
        Task<Medicine> GetByIdWithDetailsAsync(int id);
    }
}
