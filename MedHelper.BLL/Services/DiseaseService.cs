using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Interfaces;
using MedHelper.DAL;
using MedHelper.DAL.Entities;

namespace MedHelper.BLL.Services
{
    public class DiseaseService: ICrud<Disease>
    {
        private readonly UnitOfWork _unitOfWork;

        public DiseaseService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Disease> GetAll()
        {
            return _unitOfWork.DiseaseRepository.FindAll();
        }

        public async Task<Disease> GetByIdAsync(int id)
        {
            return await _unitOfWork.DiseaseRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Disease model)
        {
            await _unitOfWork.DiseaseRepository.AddAsync(model);
        }

        public async Task UpdateAsync(Disease model)
        {
            await _unitOfWork.DiseaseRepository.UpdateAsync(model);
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            await _unitOfWork.DiseaseRepository.DeleteByIdAsync(modelId);
        }
    }
}