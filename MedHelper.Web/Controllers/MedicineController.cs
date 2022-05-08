using MedHelper.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using MedHelper.BLL.Dto.Medicine;
using MedHelper.BLL.Dto.Patient;
using Microsoft.AspNetCore.Authorization;
using MedHelper.BLL.Dto.Responses;
using System.Collections.Generic;

namespace MedHelper.Web.Controllers
{
    public class MedicineController : Controller
    {
        IMedicineService _medicineService;
        public MedicineController(IMedicineService medicineService)
        {
            _medicineService = medicineService;
        }

        [HttpGet]
        [Route("Medicine/{id}")]
        public async Task<IActionResult> Index(int Id)
        {
            var medicine = await _medicineService.GetByIdAsync(Id);
            MedicineResponse response = new MedicineResponse() { 
                Id = medicine.Id,
                Name = medicine.Name,
                Group = medicine.Group,
                Compositions = medicine.Compositions.ToList(),
                Contraindications = medicine.Contraindications.ToList(),
                MedicineInteractions = medicine.MedicineInteractions.ToList()
            };
           
            return View(response);
        }
        
        [HttpGet]
        // [Authorize(Roles ="Admin")]
        public IActionResult Add()
        {
            return View();
        }
        
        [HttpPost]
        [AllowAnonymous] // add auth
        // [Authorize(Roles ="Admin")]
        public async Task<IActionResult> AddAsync(CreateMedicineDto patient)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            
            await _medicineService.AddAsync(patient);
            return Ok(); // редірект на сторінку доктора треба тут

            // return RedirectToAction("Get", new { id = createdPatient.Id });
        }

        [HttpGet]
        [Route("Medicines")]
        public ActionResult ViewAllMedicines(string search)
        {
            List<MedicineResponse> medicines =  _medicineService.GetAll(search).ToList();

            ViewMedicinesResponse response = new ViewMedicinesResponse() { Medicines = medicines};

            return View(response);
        }

        public ActionResult ViewMedicine()
        {
            return View();
        }
    }
}
