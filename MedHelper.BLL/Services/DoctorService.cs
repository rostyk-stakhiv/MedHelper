using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Interfaces;
using MedHelper.DAL;
using MedHelper.DAL.Entities;

namespace MedHelper.BLL.Services
{
    public class DoctorService: ICrud<User>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DoctorService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<User> GetAll()
        {
            return _unitOfWork.UserRepository.FindAll();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var doctor =  await _unitOfWork.UserRepository.GetByIdAsync(id);
            var patients = _unitOfWork.PatientRepository.FindAll();
            var diseases = _unitOfWork.DiseaseRepository.FindAll();
            var medicines = _unitOfWork.MedicineRepository.FindAll();

            foreach (var pId in doctor.PatientsId)
            {
                var patient = patients.FirstOrDefault(obj => obj.Id == pId);

                if (patient != null)
                {
                    foreach (var did in patient.DiseasesId)
                    {
                        var patientDisease = diseases.FirstOrDefault(obj => obj.Id == did);
                        patient.Diseases.Add(patientDisease);
                    }

                    foreach (var mid in patient.MedicinesId)
                    {
                        var patientMedicines = medicines.FirstOrDefault(obj => obj.Id == mid);
                        patient.Medicines.Add(patientMedicines);
                    }

                    doctor.Patients.Add(patient);
                }
            }

            return doctor;
        }

        public async Task AddAsync(User model)
        {
            var patients = _unitOfWork.PatientRepository.FindAll();
            var diseases = _unitOfWork.DiseaseRepository.FindAll();
            var medicines = _unitOfWork.MedicineRepository.FindAll();

            foreach (var pId in model.PatientsId)
            {
                var patient = patients.FirstOrDefault(obj => obj.Id == pId);

                if (patient != null)
                {
                    foreach (var did in patient.DiseasesId)
                    {
                        var patientDisease = diseases.FirstOrDefault(obj => obj.Id == did);
                        patient.Diseases.Add(patientDisease);
                    }

                    foreach (var mid in patient.MedicinesId)
                    {
                        var patientMedicines = medicines.FirstOrDefault(obj => obj.Id == mid);
                        patient.Medicines.Add(patientMedicines);
                    }

                    model.Patients.Add(patient);
                }
            }
            
            await _unitOfWork.UserRepository.AddAsync(model);
        }

        public async Task UpdateAsync(User model)
        {
            var patients = _unitOfWork.PatientRepository.FindAll();
            var diseases = _unitOfWork.DiseaseRepository.FindAll();
            var medicines = _unitOfWork.MedicineRepository.FindAll();

            foreach (var pId in model.PatientsId)
            {
                var patient = patients.FirstOrDefault(obj => obj.Id == pId);

                if (patient != null)
                {
                    foreach (var did in patient.DiseasesId)
                    {
                        var patientDisease = diseases.FirstOrDefault(obj => obj.Id == did);
                        patient.Diseases.Add(patientDisease);
                    }

                    foreach (var mid in patient.MedicinesId)
                    {
                        var patientMedicines = medicines.FirstOrDefault(obj => obj.Id == mid);
                        patient.Medicines.Add(patientMedicines);
                    }

                    model.Patients.Add(patient);
                }
            }
            
            await _unitOfWork.UserRepository.UpdateAsync(model);
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            await _unitOfWork.UserRepository.DeleteByIdAsync(modelId);
        }
    }
}