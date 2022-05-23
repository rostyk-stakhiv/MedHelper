using MedHelper.BLL.Dto.Responses;
using MedHelper.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MedHelper.BLL.Dto.Medicine;
using Microsoft.VisualBasic;

namespace MedHelper.BLL.Interfaces
{
    public interface IMedicineService
    {
        IEnumerable<MedicineResponse> GetAll(string search = null);
        IEnumerable<DiseaseResponse> GetAllDiseases();
        IEnumerable<PharmacotherapeuticGroup> GetAllPharmacotherapeuticGroups();
        IEnumerable<MedicineInteraction> GetAllMedicineInteractions();
        IEnumerable<Composition> GetAllCompositions();

        Task<MedicineResponse> GetByIdAsync(int id);
        IEnumerable<TempMedicineResponse> CreateMedicinesFromString(string medString);
        IEnumerable<DiseaseResponse> CreateDiseasesFromString(string medString);
        Task AddAsync(CreateMedicineDto model);

        //Task UpdateAsync(UpdateMedicineDto model);

        Task DeleteByIdAsync(int modelId);
    }
}
