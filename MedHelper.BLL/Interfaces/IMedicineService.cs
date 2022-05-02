using MedHelper.BLL.Dto.Responses;
using MedHelper.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedHelper.BLL.Interfaces
{
    public interface IMedicineService
    {
        IEnumerable<MedicineResponse> GetAll();

        Task<MedicineResponse> GetByIdAsync(int id);

        //Task AddAsync(CreateMedicineDto model);

        //Task UpdateAsync(UpdateMedicineDto model);

        Task DeleteByIdAsync(int modelId);
    }
}
