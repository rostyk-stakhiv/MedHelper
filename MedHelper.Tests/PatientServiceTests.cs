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
    public class PatientServiceTests
    {
        public static Mock<IPatientRepository> _patientRepository;
        public static Mock<IUnitOfWork> _unitOfWork;
        public static Mock<IMapper> _mapper;
       
        private PatientService _patientService;

        public PatientServiceTests()
        {
            _patientRepository = new Mock<IPatientRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _mapper = new Mock<IMapper>();
        }

        Patient patient = new Patient()
        {
            Id = 1,
            FirstName = "Test",
            LastName = "Patient",
            UserId = 1,
            Gender = "Male",
            Birthdate = new DateTime(2002, 6, 1)
        };

        Patient patient2 = new Patient()
        {
            Id = 2,
            FirstName = "Test2",
            LastName = "Patient2",
            UserId = 1,
            Gender = "Female",
            Birthdate = new DateTime(2000, 2, 13)
        };


        [Fact]
        public async Task GetByIdNull()
        {
            // arrange
            _unitOfWork.Setup(s => s.PatientRepository.GetByIdWithDetailsAsync(It.IsAny<int>())).Returns(Task.FromResult((Patient)null));
            _patientService = new PatientService(_unitOfWork.Object, _mapper.Object);

            // act
            var result = await _patientService.GetByIdAsync(1);

            // assert
            Assert.Null(null);
        }

        [Fact]
        public async Task GetByIdSuccess()
        {
            PatientResponse p = new PatientResponse()
            {
                LastName = patient.LastName,
                FirstName = patient.FirstName,
                Gender = patient.Gender,
                Birthdate = patient.Birthdate,
                Id = patient.Id
            };
            // arrange
            _unitOfWork.Setup(s => s.PatientRepository.GetByIdWithDetailsAsync(It.IsAny<int>())).Returns(Task.FromResult(patient));
            _mapper.Setup(m => m.Map<PatientResponse>(It.IsAny<object>())).Returns(p);

            _patientService = new PatientService(_unitOfWork.Object, _mapper.Object);

            // act
            var result = await _patientService.GetByIdAsync(1);

            // assert
            Assert.NotNull(result);
            Assert.Equal(p, result);
        }

        [Fact]
        public void GetAllNull()
        {
            // arrange
            _unitOfWork.Setup(s => s.PatientRepository.GetAllWithDetails()).Returns((IEnumerable<Patient>)null);
            _patientService = new PatientService(_unitOfWork.Object, _mapper.Object);

            // act
            var result = _patientService.GetAll();

            // assert
            Assert.Null(null);
        }

        [Fact]
        public void GetAllSuccess()
        {
            // arrange

            IEnumerable<Patient> patients = new List<Patient> { patient, patient2 };
            List <PatientResponse> patientResponses = new List<PatientResponse>();
            foreach (var i in patients)
            {
                patientResponses.Add(new PatientResponse()
                {
                    LastName = i.LastName,
                    FirstName = i.FirstName,
                    Gender = i.Gender,
                    Birthdate = i.Birthdate,
                    Id = i.Id
                });
            }
            _unitOfWork.Setup(s => s.PatientRepository.GetAllWithDetails()).Returns((IEnumerable<Patient>)patients);
            _mapper.Setup(m => m.Map<List<PatientResponse>>(It.IsAny<object>())).Returns(patientResponses);

            _patientService = new PatientService(_unitOfWork.Object, _mapper.Object);

            // act
            var result = _patientService.GetAll();

            // assert
            Assert.NotNull(result);
            Assert.Equal(patientResponses, result);
        }
    }
}
