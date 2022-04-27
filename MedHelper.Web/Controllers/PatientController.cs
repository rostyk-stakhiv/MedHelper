using MedHelper.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedHelper.Web.Controllers
{
    public class PatientController : Controller
    {
        [HttpGet("/Patient/{id}")]
        public IActionResult ViewPatient(int id)
        {
            var patient = new PatientModel() { LastName ="Petrov", FirstName="Ivan", Birthdate = DateTime.Now, Gender="Male", Id=3, 
            DiseasesId=new List<int>() { 1},Diseases = new List<DiseaseModel>() { new DiseaseModel() { Id = 1, Title = "Corona" } },
                Medicines = new List<MedicineModel>() { new MedicineModel() { Id= 1, Name = "Phizer"} },MedicinesId=new List<int>() {1},
            UserID = 1};
            ViewBag.Patient = patient;
            return View();
        }

        [HttpGet("/Patient/{id}/Edit")]
        public IActionResult EditPatient(int id)
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
    }
}
