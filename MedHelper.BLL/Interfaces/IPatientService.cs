using MedHelper.BLL.Dto.Patient;
using MedHelper.BLL.Dto.Responses;
using MedHelper.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedHelper.BLL.Interfaces
{
    public interface IPatientService
    {
        public Task<IEnumerable<MedicineResponse>> GetAllMedicinesForPatientAsync(int userId, string search);
        IEnumerable<PatientResponse> GetAll();

        Task<PatientResponse> GetByIdAsync(int id);

        Task AddAsync(CreatePatientDto model);

        Task UpdateAsync(UpdatePatientDto model);

        Task DeleteByIdAsync(int modelId);
    }
}
