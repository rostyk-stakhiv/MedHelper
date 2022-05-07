using MedHelper.BLL.Interfaces;
using MedHelper.Web.Models;
using Microsoft.AspNetCore.Mvc;
using MedHelper.BLL.Dto.Patient;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System;
using MedHelper.BLL.Dto.Responses;

namespace MedHelper.Web.Controllers
{
    public class PatientController : Controller
    {
        private IPatientService _patientService;
        IMedicineService _medicineService;

        public PatientController(IPatientService patientService, IMedicineService medicineService)
        { 
            _patientService = patientService;
            _medicineService = medicineService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAsync(int id, string search)
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
        // [Authorize(Roles ="Doctor")]
        public IActionResult Add()
        {
            var Diseases = new List<DiseaseModel>() { new DiseaseModel() { Id = 1, Title = "one" }, new DiseaseModel() { Id = 2, Title = "two" } };
            ViewBag.Medicines = _medicineService.GetAll();
            ViewBag.Diseases = Diseases;
            return View();
        }
        
        [HttpPost]
        [AllowAnonymous]
        // [Authorize(Roles ="Admin")]
        public async Task<IActionResult> AddAsync(CreatePatientDto patient)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            
            await _patientService.AddAsync(patient);
            return Ok(); // редірект на сторінку доктора треба тут

            // return RedirectToAction("Get", new { id = createdPatient.Id });
        }
        
    }
}
