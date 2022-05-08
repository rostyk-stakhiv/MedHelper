using Xunit;
using Moq;
using System.Threading.Tasks;
using MedHelper.BLL.Services;
using MedHelper.DAL.Interfaces;
using MedHelper.DAL;
using MedHelper.DAL.Entities;
using AutoMapper;
using MedHelper.BLL.Dto.Responses;
using System;
using System.Collections.Generic;

namespace MedHelper.Tests
{
    public class MedicineServiceTests
    {
        public static Mock<IMedicineRepository> _medicineRepository;
        public static Mock<IUnitOfWork> _unitOfWork;
        public static Mock<IMapper> _mapper;

        private MedicineService _medicineService;

        public MedicineServiceTests()
        {
            _medicineRepository = new Mock<IMedicineRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _mapper = new Mock<IMapper>();
        }

        Medicine medicine = new Medicine()
        {
            Id = 1,
            PharmacotherapeuticGroupId = 1,
            Name = "Medicine1",
            UserId = 1
        };

        Medicine medicine2 = new Medicine()
        {
            Id = 2,
            PharmacotherapeuticGroupId = 1,
            Name = "Medicine2",
            UserId = 1
        };

        [Fact]
        public async Task GetByIdNull()
        {
            // arrange
            _unitOfWork.Setup(s => s.MedicineRepository.GetByIdWithDetailsAsync(It.IsAny<int>())).Returns(Task.FromResult((Medicine)null));
            _medicineService = new MedicineService(_unitOfWork.Object, _mapper.Object);

            // act
            var result = await _medicineService.GetByIdAsync(1);

            // assert
            Assert.Null(null);
        }

        [Fact]
        public async Task GetByIdSuccess()
        {
            MedicineResponse m = new MedicineResponse()
            {
                Id = medicine.Id,
                Name = medicine.Name,
            };
            // arrange
            _unitOfWork.Setup(s => s.MedicineRepository.GetByIdWithDetailsAsync(It.IsAny<int>())).Returns(Task.FromResult(medicine));
            _mapper.Setup(m => m.Map<MedicineResponse>(It.IsAny<object>())).Returns(m);

            _medicineService = new MedicineService(_unitOfWork.Object, _mapper.Object);

            // act
            var result = await _medicineService.GetByIdAsync(1);

            // assert
            Assert.NotNull(result);
            Assert.Equal(m, result);
        }

        [Fact]
        public void GetAllNull()
        {
            // arrange
            _unitOfWork.Setup(s => s.MedicineRepository.GetAllWithDetails(null)).Returns((IEnumerable<Medicine>)null);
            _medicineService = new MedicineService(_unitOfWork.Object, _mapper.Object);

            // act
            var result = _medicineService.GetAll();

            // assert
            Assert.Null(null);
        }

        [Fact]
        public void GetAllSuccess()
        {
            // arrange

            IEnumerable<Medicine> medicines = new List<Medicine> { medicine, medicine2 };
            List<MedicineResponse> medicineResponses = new List<MedicineResponse>();
            foreach (var i in medicines)
            {
                medicineResponses.Add(new MedicineResponse()
                {
                    Id = i.Id,
                    Name = i.Name
                });
            }
            _unitOfWork.Setup(s => s.MedicineRepository.GetAllWithDetails(null)).Returns((IEnumerable<Medicine>)medicines);
            _mapper.Setup(m => m.Map<List<MedicineResponse>>(It.IsAny<object>())).Returns(medicineResponses);

            _medicineService = new MedicineService(_unitOfWork.Object, _mapper.Object);

            // act
            var result = _medicineService.GetAll();

            // assert
            Assert.NotNull(result);
            Assert.Equal(medicineResponses, result);
        }
    }
}
