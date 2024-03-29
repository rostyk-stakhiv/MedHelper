using Xunit;
using Moq;
using System.Threading.Tasks;
using MedHelper.BLL.Services;
using MedHelper.DAL.Interfaces;
using MedHelper.DAL;
using MedHelper.DAL.Entities;
using AutoMapper;
using MedHelper.BLL.Dto.Responses;
using MedHelper.BLL.Dto.Doctor;

namespace MedHelper.Tests
{
    public class DoctorServiceTests
    {
        public static Mock<IUserRepository> _userRepository;
        public static Mock<IUnitOfWork> _unitOfWork;
        public static Mock<IMapper> _mapper;

        private DoctorService _doctorService;

        public DoctorServiceTests()
        {
            _userRepository = new Mock<IUserRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _mapper = new Mock<IMapper>();
        }

        UpdateDoctorDto update = new UpdateDoctorDto()
        {
            Id = 1,
            FirstName = "Test",
            LastName = "Doctor",
            Email = "testdoctor@gmail.com",
        };

        User doctor = new User()
        {
            Id = 1,
            FirstName = "Test",
            LastName = "Doctor",
            Email = "testdoctor@gmail.com",
            Password = "pass"
        };

        [Fact]
        public async Task GetByIdNull()
        {
            // arrange
            _unitOfWork.Setup(s => s.UserRepository.GetByIdWithDetailsAsync(It.IsAny<int>())).Returns(Task.FromResult((User)null));
            _doctorService = new DoctorService(_unitOfWork.Object, _mapper.Object);

            // act
            var result = await _doctorService.GetByIdAsync(1);

            // assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetByIdSuccess()
        {
            DoctorResponse d = new DoctorResponse()
            {
                LastName = doctor.LastName,
                FirstName = doctor.FirstName,
                Email = doctor.Email
            };
            // arrange
            _unitOfWork.Setup(s => s.UserRepository.GetByIdWithDetailsAsync(It.IsAny<int>())).Returns(Task.FromResult(doctor));
            _mapper.Setup(m => m.Map<DoctorResponse>(It.IsAny<object>())).Returns(d);

            _doctorService = new DoctorService(_unitOfWork.Object, _mapper.Object);

            // act
            var result = await _doctorService.GetByIdAsync(1);

            // assert
            Assert.NotNull(result);
            Assert.Equal(d, result);
        }

        [Fact]
        public async Task UpdateSuccess()
        {
            // arrange
            _unitOfWork.Setup(s => s.UserRepository.Update(It.IsAny<User>())).Verifiable();
            _unitOfWork.Setup(s => s.UserRepository.GetByIdAsync(It.IsAny<int>())).Returns(Task.FromResult(doctor));
            _mapper.Setup(m => m.Map(It.IsAny<UpdateDoctorDto>(), It.IsAny<User>())).Returns(doctor);

            _doctorService = new DoctorService(_unitOfWork.Object, _mapper.Object);

            // act
            await _doctorService.UpdateAsync(update);

            // assert
            _unitOfWork.Verify(x => x.UserRepository.Update(doctor));
        }
    }
}
