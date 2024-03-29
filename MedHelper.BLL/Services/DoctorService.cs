﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MedHelper.BLL.Dto.Doctor;
using MedHelper.BLL.Dto.Responses;
using MedHelper.BLL.Interfaces;
using MedHelper.DAL;
using MedHelper.DAL.Entities;
using MedHelper.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedHelper.BLL.Services
{
    public class DoctorService :IDoctorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DoctorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DoctorResponse> GetByIdAsync(int id)
        {
            var doctor = await _unitOfWork.UserRepository.GetByIdWithDetailsAsync(id);

            return _mapper.Map<DoctorResponse>(doctor);
        }

        public async Task<UpdateDoctorDto> GetInfoForUpdate(int id)
        {
            var doctor = await _unitOfWork.UserRepository.GetByIdAsync(id);
            return _mapper.Map<UpdateDoctorDto>(doctor);
        }

        public async Task UpdateAsync(UpdateDoctorDto model)
        {
            var doctor = await _unitOfWork.UserRepository.GetByIdAsync(model.Id);
            doctor = _mapper.Map(model,doctor);
            _unitOfWork.UserRepository.Update(doctor);
            await _unitOfWork.SaveAsync();
        }

        public List<Patient> GetPatients(int id, string search)
        {
            var patients = _unitOfWork.PatientRepository.GetPatients(id, search);
            return patients.ToList();
        }
    }
}
