using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

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

        public PatientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Medicine> GetAllMedicines()
        {
            return _unitOfWork.MedicineRepository.FindAll();
        }

        public IEnumerable<Patient> GetAll()
        {
            var diseases = _unitOfWork.DiseaseRepository.FindAll();
            var medicines = _unitOfWork.MedicineRepository.FindAll();
            var result = _unitOfWork.Context.Patients;
                //.Include(obj => obj.PatientDiseases)
                //.Include(obj => obj.PatientMedicines);
            
            /*foreach (var patient in result)
            {
                foreach (var data in patient.PatientDiseases)
                {
                    data.Disease = diseases.FirstOrDefault(obj => obj.DiseaseID == data.DiseaseID);
                }
                foreach (var data in patient.PatientMedicines)
                {
                    data.Medicine = medicines.FirstOrDefault(obj => obj.MedicineID == data.MedicineID);
                }
            }*/
            
            return result;
        }

        public Patient GetById(int id)
        {
            var diseases = _unitOfWork.DiseaseRepository.FindAll();
            var medicines = _unitOfWork.MedicineRepository.FindAll();
            var result = _unitOfWork.Context.Patients
                //.Include(obj => obj.PatientDiseases)
                //.Include(obj => obj.PatientMedicines)
                .FirstOrDefault(obj => obj.Id == id);
            
            /*foreach (var data in result.PatientDiseases)
            {
                data.Disease = diseases.FirstOrDefault(obj => obj.DiseaseID == data.DiseaseID);
            }
            foreach (var data in result.PatientMedicines)
            {
                data.Medicine = medicines.FirstOrDefault(obj => obj.MedicineID == data.MedicineID);
            }*/
            
            return result;
        }

        public async Task AddAsync(Patient model)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Patient model)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            await _unitOfWork.PatientRepository.DeleteByIdAsync(modelId);
        }
    }
}
