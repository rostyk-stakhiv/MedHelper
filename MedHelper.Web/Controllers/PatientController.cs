using MedHelper.BLL.Interfaces;
using MedHelper.Web.Models;
using Microsoft.AspNetCore.Mvc;
using MedHelper.BLL.Dto.Patient;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Security.Claims;
using MedHelper.BLL.Dto.Responses;
using MedHelper.DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace MedHelper.Web.Controllers
{
    public class PatientController : Controller
    {
        private IPatientService _patientService;
        IMedicineService _medicineService;
        private readonly UserManager<User> _userManager;

        public PatientController(IPatientService patientService, IMedicineService medicineService, UserManager<User> userManager)
        { 
            _patientService = patientService;
            _medicineService = medicineService;
            _userManager = userManager;
        }
        
        [HttpGet]
        // [Route("Patient/{id}")]
        public async Task<IActionResult> Index(int id, string search)
        {
            var patient = await _patientService.GetByIdAsync(id);
            var allMedicines = await _patientService.GetAllMedicinesForPatientAsync(id, search);

            PatientResponse response = new PatientResponse() {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Birthdate = patient.Birthdate,
                Gender = patient.Gender,
                Medicines = patient.Medicines.ToList(),
                Diseases = patient.Diseases.ToList(),
                AllMedicines = allMedicines.ToList()
            };
            
            return View(response);
        }
        
        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPut]
        public IActionResult EditAsync(int id)
        {
            var patient = new PatientModel()
            {
                LastName = "Petrov",
                FirstName = "Ivan",
                Birthdate = DateTime.Now,
                Gender = "Male",
                Id = 3,
                DiseasesId = new List<int>() { 1 },
                Diseases = new List<DiseaseModel>() { new DiseaseModel() { Id = 1, Title = "Corona" } },
                Medicines = new List<MedicineModel>() { new MedicineModel() { Id = 1, Name = "Phizer" } },
                MedicinesId = new List<int>() { 1 },
                UserID = 1
            };
            var Medicines = new List<MedicineModel>() { new MedicineModel() { Id=3, Name="first"},
                new MedicineModel() { Id = 4, Name = "second" },new MedicineModel() { Id=5, Name="third"} };
            var Diseases = new List<DiseaseModel>() { new DiseaseModel() { Id = 1, Title = "one" }, new DiseaseModel() { Id = 2, Title = "two" } };
            ViewBag.Patient = patient;
            ViewBag.Medicines = Medicines;
            ViewBag.Diseases = Diseases;
            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Add()
        {
            return View();
        }
        
        // FIXME
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddAsync(CreatePatientDto patient)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);
            patient.UserId = user.Id;
            
            // preparePatient(patient);
            
            await _patientService.AddAsync(patient);
            return Redirect("https://localhost:7241/Doctor");
        }

        // private void preparePatient(CreatePatientDto patient)
        // { 
        //     var medArr = patient.TempMedicines.Split(", ");
        //     // var disArr = patient.TempDiseases.Split(", ");
        //     patient.Medicines = _medicineService.GetAll().Where(obj => medArr.Contains(obj.Name)).ToList();
        //     // patient.Diseases = _medicineService.GetAllDiseases().Where(obj => disArr.Contains(obj.Title)).ToList();
        // }
        
    }
}
