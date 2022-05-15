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
        private const string DOCTOR_PAGE = "https://localhost:7241/Doctor";
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
        [Route("Patient/{id}")]
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

        [HttpGet, ActionName("Add")]
        [Authorize]
        [Route("Patient/add")]
        public IActionResult Add()
        {
            ViewBag.Medicines = _medicineService.GetAll();
            ViewBag.Diseases = _medicineService.GetAllDiseases();
            return View();
        }
        
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddAsync(CreatePatientDto patient)
        {
            // if (!ModelState.IsValid)
            // {
            //     ViewBag.Medicines = _medicineService.GetAll();
            //     ViewBag.Diseases = _medicineService.GetAllDiseases();
            //     return View();
            // }
            
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            patient.UserId = Convert.ToInt32(userId);

            patient.Medicines = _medicineService.CreateMedicinesFromString(patient.TempMedicines).ToList();
            patient.Diseases = _medicineService.CreateDiseasesFromString(patient.TempDiseases).ToList();
            
            await _patientService.AddAsync(patient);
            return Redirect(DOCTOR_PAGE);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _patientService.DeleteByIdAsync(id);
            return Redirect(DOCTOR_PAGE);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var patient = await _patientService.GetByIdAsync(id);

            var tempMedicines = "";
            foreach (var i in patient.Medicines)
            {
                tempMedicines += i.Name + "\r\n";
            }

            var tempDiseases = "";
            foreach (var i in patient.Diseases)
            {
                tempDiseases += i.Title + "\r\n";
            }

            UpdatePatientDto update = new UpdatePatientDto()
            {
                Birthdate = patient.Birthdate,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                TempMedicines = tempMedicines,
                TempDiseases = tempDiseases,
                Gender = patient.Gender,
                Id = patient.Id
            };

            ViewBag.Medicines = _medicineService.GetAll();
            ViewBag.Diseases = _medicineService.GetAllDiseases();
            return View(update);
        }

        [HttpPost, ActionName("Edit")]
        [Authorize]
        public async Task<IActionResult> Edit(UpdatePatientDto patient)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            patient.UserId = Convert.ToInt32(userId);

            patient.Medicines = _medicineService.CreateMedicinesFromString(patient.TempMedicines).ToList();
            patient.Diseases = _medicineService.CreateDiseasesFromString(patient.TempDiseases).ToList();

            await _patientService.UpdateAsync(patient);
            return Redirect(DOCTOR_PAGE);
        }
    }
}