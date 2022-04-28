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
    public class MedicineService: IMedicineService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MedicineService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Medicine> GetAll()
        {
            var compositions = _unitOfWork.CompositionRepository.FindAll();
            var contraindications = _unitOfWork.DiseaseRepository.FindAll();
            var interations = _unitOfWork.MedicineInteractionRepository.FindAll();
            var result =  _unitOfWork.Context.Medicines
                .Include(obj => obj.MedicineCompositions)
                .Include(obj => obj.MedicineContraindications)
                .Include(obj => obj.MedicineInteractions);
            
            foreach (var medicine in result)
            {
                foreach (var data in medicine.MedicineCompositions)
                {
                    data.Composition = compositions.FirstOrDefault(obj => obj.CompositionID == data.CompositionID);
                }
                foreach (var data in medicine.MedicineContraindications)
                {
                    data.Disease = contraindications.FirstOrDefault(obj => obj.DiseaseID == data.DiseaseID);
                }
                // foreach (var data in medicine.MedicineInteractions)
                // {
                //     data. = contraindications.FirstOrDefault(obj => obj.DiseaseID == data.DiseaseID);
                // }
            }
            
            return result;
        }

        public Medicine GetById(int id)
        {
            var compositions = _unitOfWork.CompositionRepository.FindAll();
            var contraindications = _unitOfWork.DiseaseRepository.FindAll();
            var interations = _unitOfWork.MedicineInteractionRepository.FindAll();
            var groups = _unitOfWork.PharmacotherapeuticGroupRepository.FindAll();
            var result = _unitOfWork.Context.Medicines
                .Include(obj => obj.MedicineCompositions)
                .Include(obj => obj.MedicineContraindications)
                .Include(obj => obj.MedicineInteractions)
                .FirstOrDefault(obj => obj.MedicineID == id);
            
            foreach (var data in result.MedicineCompositions)
            {
                data.Composition = compositions.FirstOrDefault(obj => obj.CompositionID == data.CompositionID);
            }
            foreach (var data in result.MedicineContraindications)
            {
                data.Disease = contraindications.FirstOrDefault(obj => obj.DiseaseID == data.DiseaseID);
            }
            foreach (var data in result.MedicineInteractions)
            {
                data.Composition = compositions.FirstOrDefault(obj => obj.CompositionID == data.CompositionID);
            }
            result.Group = groups.FirstOrDefault(x => x.PharmacotherapeuticGroupID == result.PharmacotherapeuticGroupID);
            return result;
        }

        public Task AddAsync(Medicine model)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(Medicine model)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteByIdAsync(int modelId)
        {
            throw new System.NotImplementedException();
        }
    }
}