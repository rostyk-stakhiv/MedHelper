using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MedHelper.BLL.Dto.Medicine;
using MedHelper.BLL.Dto.Responses;
using MedHelper.BLL.Interfaces;
using MedHelper.DAL;
using MedHelper.DAL.Entities;
using MedHelper.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedHelper.BLL.Services
{
    public class MedicineService: IMedicineService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MedicineService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;  
        }

        public IEnumerable<MedicineResponse> GetAll(string search = null)
        {
            //return _mapper.Map<List<MedicineResponse>>(_unitOfWork.MedicineRepository.GetAllWithDetails(search));
            var medicines = _unitOfWork.MedicineRepository.FindAll();
            if (!String.IsNullOrEmpty(search))
            {
                medicines = medicines.Where(s => s.Name.ToLower().Contains(search.ToLower()));
            }
            return _mapper.Map<List<MedicineResponse>>(medicines.ToList());
        }
        
        public IEnumerable<TempMedicineResponse> CreateMedicinesFromString(string medString)
        {
            var medArray = medString.Split("\r\n");
            var medicines = _unitOfWork.MedicineRepository.FindAll().Where(obj => medArray.Contains(obj.Name));
            
            return _mapper.Map<List<TempMedicineResponse>>(medicines.ToList());
        }

        public IEnumerable<DiseaseResponse> CreateDiseasesFromString(string medString)
        {
            var medArray = medString.Split("\r\n");
            var medicines = _unitOfWork.DiseaseRepository.FindAll().Where(obj => medArray.Contains(obj.Title));
            
            return _mapper.Map<List<DiseaseResponse>>(medicines.ToList());
        }

        public IEnumerable<DiseaseResponse> GetAllDiseases()
        {
            return _mapper.Map<List<DiseaseResponse>>(_unitOfWork.DiseaseRepository.FindAll());
        }

        public async Task<MedicineResponse> GetByIdAsync(int id)
        {
            var result = await _unitOfWork.MedicineRepository.GetByIdWithDetailsAsync(id);
            return _mapper.Map<MedicineResponse>(result);
        }

        public async Task AddAsync(CreateMedicineDto model)
        {
            var medicine = _mapper.Map<Medicine>(model);
            await _unitOfWork.MedicineRepository.AddAsync(medicine);
            await _unitOfWork.SaveAsync();
        }

        //public async Task UpdateAsync(UpdateMedicineDto model)
        //{
        //    var patient = _mapper.Map<Patient>(model);
        //    _unitOfWork.PatientRepository.Update(patient);
        //    await _unitOfWork.SaveAsync();
        //}
        public async Task DeleteByIdAsync(int modelId)
        {
            await _unitOfWork.MedicineRepository.DeleteByIdAsync(modelId);
            await _unitOfWork.SaveAsync();
        }
    }
}