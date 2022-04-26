using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Interfaces;
using MedHelper.DAL;
using MedHelper.DAL.Entities;

namespace MedHelper.BLL.Services
{
    public class PatientService: ICrud<Patient>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PatientService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<Medicine>> GetPatientMedicines(int patientId)
        {
            var patient = await _unitOfWork.PatientRepository.GetByIdAsync(patientId);

            return _unitOfWork.MedicineRepository.FindAll().Where(obj => patient.MedicinesId.Contains(obj.Id));
        }
        
        public async Task<IEnumerable<Disease>> GetPatientDiseases(int patientId)
        {
            var patient = await _unitOfWork.PatientRepository.GetByIdAsync(patientId);

            return _unitOfWork.DiseaseRepository.FindAll().Where(obj => patient.DiseasesId.Contains(obj.Id));
        }

        public IEnumerable<Patient> GetAll()
        {
            var patients =  _unitOfWork.PatientRepository.FindAll();
            var diseases = _unitOfWork.DiseaseRepository.FindAll();
            var medicines = _unitOfWork.MedicineRepository.FindAll();
            foreach (var patient in patients)
            {
                foreach (var id in patient.DiseasesId)
                {
                    var patientDisease = diseases.FirstOrDefault(obj => obj.Id == id);
                    patient.Diseases.Add(patientDisease);
                }
                
                foreach (var id in patient.MedicinesId)
                {
                    var patientMedicines = medicines.FirstOrDefault(obj => obj.Id == id);
                    patient.Medicines.Add(patientMedicines);
                }
            }

            return patients;
        }

        public async Task<Patient> GetByIdAsync(int id)
        {
            var patient = await _unitOfWork.PatientRepository.GetByIdAsync(id);
            var diseases = _unitOfWork.DiseaseRepository.FindAll();
            var medicines = _unitOfWork.MedicineRepository.FindAll();
            
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

            return patient;
        }

        public async Task AddAsync(Patient model)
        {
            var diseases = _unitOfWork.DiseaseRepository.FindAll();
            var medicines = _unitOfWork.MedicineRepository.FindAll();
            
            foreach (var did in model.DiseasesId)
            {
                var patientDisease = diseases.FirstOrDefault(obj => obj.Id == did);
                model.Diseases.Add(patientDisease);
            }
            
            foreach (var mid in model.MedicinesId)
            {
                var patientMedicines = medicines.FirstOrDefault(obj => obj.Id == mid);
                model.Medicines.Add(patientMedicines);
            }

            await _unitOfWork.PatientRepository.AddAsync(model);
        }

        public async Task UpdateAsync(Patient model)
        {
            var diseases = _unitOfWork.DiseaseRepository.FindAll();
            var medicines = _unitOfWork.MedicineRepository.FindAll();
            
            foreach (var did in model.DiseasesId)
            {
                var patientDisease = diseases.FirstOrDefault(obj => obj.Id == did);
                model.Diseases.Add(patientDisease);
            }
            
            foreach (var mid in model.MedicinesId)
            {
                var patientMedicines = medicines.FirstOrDefault(obj => obj.Id == mid);
                model.Medicines.Add(patientMedicines);
            }
            
            await _unitOfWork.PatientRepository.UpdateAsync(model);
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            await _unitOfWork.PatientRepository.DeleteByIdAsync(modelId);
        }
    }
}