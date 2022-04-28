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
    public class DoctorService :IDoctorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DoctorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<User> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public User GetById(int id)
        {
            var doctor =  _unitOfWork.UserRepository.GetById(id);
            //doctor.Patients = _unitOfWork.Context.Patients.Where(obj => obj.UserID == id).ToList();

            return doctor;
        }

        public Task AddAsync(User model)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(User model)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteByIdAsync(int modelId)
        {
            throw new System.NotImplementedException();
        }
    }
}
