using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MedHelper.BLL.Dto.Patient;
using MedHelper.BLL.Dto.Responses;
using MedHelper.BLL.Interfaces;
using MedHelper.DAL;
using MedHelper.DAL.Entities;
using MedHelper.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedHelper.BLL.Services
{
    public class PatientService: IPatientService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PatientService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MedicineResponse>> GetAllMedicinesForPatientAsync(int userId)
        {
            var patient = await _unitOfWork.PatientRepository.GetByIdWithDetailsAsync(userId);
            var contraindications = patient.PatientDiseases.Select(x => x.DiseaseId).ToList();
            var medicines = _unitOfWork.MedicineRepository.GetAllWithDetails();
            foreach(var contraindication in contraindications)
            {
                medicines = medicines.Where(x =>
                x.MedicineContraindications.FirstOrDefault(y => y.ContraindicationId == contraindication)!=null);
            }

            return _mapper.Map<List<MedicineResponse>>(medicines);
        }

        public IEnumerable<PatientResponse> GetAll()
        {
            
            
            return _mapper.Map<List<PatientResponse>>(_unitOfWork.PatientRepository.GetAllWithDetails());
        }

        public async Task<PatientResponse> GetByIdAsync(int id)
        {
            var result = await _unitOfWork.PatientRepository.GetByIdWithDetailsAsync(id);
            
            return _mapper.Map<PatientResponse>(result);
        }

        public async Task AddAsync(CreatePatientDto model)
        {
            var patient = _mapper.Map<Patient>(model);
            await _unitOfWork.PatientRepository.AddAsync(patient);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(UpdatePatientDto model)
        {
            var patient = _mapper.Map<Patient>(model);
            _unitOfWork.PatientRepository.Update(patient);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            await _unitOfWork.PatientRepository.DeleteByIdAsync(modelId);
            await _unitOfWork.SaveAsync();
        }
    }
}
