using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Interfaces;
using MedHelper.DAL;
using MedHelper.DAL.Entities;

namespace MedHelper.BLL.Services
{
    public class PatientService: ICrud<Patient>
    {
        private readonly UnitOfWork _unitOfWork;

        public PatientService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Patient> GetAll()
        {
            return _unitOfWork.PatientRepository.FindAll();
        }

        public async Task<Patient> GetByIdAsync(int id)
        {
            return await _unitOfWork.PatientRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Patient model)
        {
            await _unitOfWork.PatientRepository.AddAsync(model);
        }

        public async Task UpdateAsync(Patient model)
        {
            await _unitOfWork.PatientRepository.UpdateAsync(model);
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            await _unitOfWork.PatientRepository.DeleteByIdAsync(modelId);
        }
    }
}