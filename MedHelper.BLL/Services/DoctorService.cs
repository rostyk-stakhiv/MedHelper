using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Interfaces;
using MedHelper.DAL;
using MedHelper.DAL.Entities;

namespace MedHelper.BLL.Services
{
    public class DoctorService: ICrud<User>
    {
        private readonly UnitOfWork _unitOfWork;

        public DoctorService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<User> GetAll()
        {
            return _unitOfWork.UserRepository.FindAll();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _unitOfWork.UserRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(User model)
        {
            await _unitOfWork.UserRepository.AddAsync(model);
        }

        public async Task UpdateAsync(User model)
        {
            await _unitOfWork.UserRepository.UpdateAsync(model);
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            await _unitOfWork.UserRepository.DeleteByIdAsync(modelId);
        }
    }
}