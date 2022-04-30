using AutoMapper;
using MedHelper.BLL.Interfaces;
using MedHelper.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedHelper.BLL.Services
{
    public class AuthentificationService:IAuthentificationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AuthentificationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}
