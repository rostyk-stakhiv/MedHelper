using MedHelper.BLL.Interfaces;
using MedHelper.Web.Models;
using Microsoft.AspNetCore.Mvc;
using MedHelper.BLL.Dto.Patient;
using Microsoft.AspNetCore.Authorization;

namespace MedHelper.Web.Controllers
{
    public class PatientController : Controller
    {
        private IPatientService _patientService;

        public PatientController(IPatientService patientService)
        { 
            _patientService = patientService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAsync(int id)
        {
            var patient = await _patientService.GetByIdAsync(id);
            ViewBag.Patient = patient;
            ViewBag.Medicines = patient.Medicines.ToList();
            ViewBag.Diseases = patient.Diseases.ToList();
            ViewBag.AllMedicines = await _patientService.GetAllMedicinesForPatientAsync(id);
            return View();
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
        public IActionResult Add()
        {
            var Medicines = new List<MedicineModel>() { new MedicineModel() { Id=3, Name="first"},
                new MedicineModel() { Id = 4, Name = "second" },new MedicineModel() { Id=5, Name="third"} };
            var Diseases = new List<DiseaseModel>() { new DiseaseModel() { Id = 1, Title = "one" }, new DiseaseModel() { Id = 2, Title = "two" } };
            ViewBag.Medicines = Medicines;
            ViewBag.Diseases = Diseases;
            return View();
        }
        
        [HttpPost]
        [AllowAnonymous]
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
