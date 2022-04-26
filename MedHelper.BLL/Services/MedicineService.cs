using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Interfaces;
using MedHelper.DAL;
using MedHelper.DAL.Entities;

namespace MedHelper.BLL.Services
{
    public class MedicineService: ICrud<Medicine>
    {
        private readonly UnitOfWork _unitOfWork;

        public MedicineService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Medicine> GetAll()
        {
            return _unitOfWork.MedicineRepository.FindAll();
        }

        public async Task<Medicine> GetByIdAsync(int id)
        {
            return await _unitOfWork.MedicineRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Medicine model)
        {
            await _unitOfWork.MedicineRepository.AddAsync(model);
        }

        public async Task UpdateAsync(Medicine model)
        {
            await _unitOfWork.MedicineRepository.UpdateAsync(model);
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            await _unitOfWork.MedicineRepository.DeleteByIdAsync(modelId);
        }
    }
}