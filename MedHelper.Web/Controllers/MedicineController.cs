using MedHelper.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using MedHelper.BLL.Dto.Medicine;
using MedHelper.BLL.Dto.Patient;
using Microsoft.AspNetCore.Authorization;
using MedHelper.BLL.Dto.Responses;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Security.Claims;
using MedHelper.DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace MedHelper.Web.Controllers
{
    public class MedicineController : Controller
    {
        IMedicineService _medicineService;
        private readonly UserManager<User> _userManager;
        public MedicineController(IMedicineService medicineService, UserManager<User> userManager)
        {
            _medicineService = medicineService;
            _userManager = userManager;
        }

        [HttpGet]
        // [Route("Medicine/{id}")]
        public async Task<IActionResult> Index(int Id)
        {
            var medicine = await _medicineService.GetByIdAsync(Id);
            TempMedicineResponse response = new TempMedicineResponse() { 
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
        [Authorize(Roles ="Admin")]
        public IActionResult Add()
        {
            ViewBag.MedicineCompositions = _medicineService.GetAllCompositions();
            ViewBag.Groups = _medicineService.GetAllPharmacotherapeuticGroups();
            ViewBag.Contraindications = _medicineService.GetAllDiseases();
            return View();
        }
        
        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> AddAsync(CreateMedicineDto medicine)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.MedicineCompositions = _medicineService.GetAllCompositions();
                ViewBag.Groups = _medicineService.GetAllPharmacotherapeuticGroups();
                ViewBag.Contraindications = _medicineService.GetAllDiseases();
                return View();
            }
            
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);
            medicine.UserId = user.Id;
            
            await _medicineService.AddAsync(medicine);
            return RedirectToAction(nameof(ViewAllMedicines));
        }

        [HttpGet]
        [Route("Medicines")]
        public ActionResult ViewAllMedicines(string search)
        {
            List<MedicineResponse> medicines =  _medicineService.GetAll(search).ToList();

            ViewMedicinesResponse response = new ViewMedicinesResponse() { Medicines = medicines};

            return View(response);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _medicineService.DeleteByIdAsync(id);
            return RedirectToAction(nameof(ViewAllMedicines));
        }

         // [HttpPost]
         // public ActionResult Delete(int id, FormCollection collection)
         // {
         //     var res = _medicineService.DeleteByIdAsync(id);
         //     if (res == null)
         //         return NotFound();
         //     return RedirectToAction(nameof(Index));
         // }
         //
         // [HttpGet]
         // public IActionResult Delete([FromRoute] int id)
         // {
         //     var res = _medicineService.DeleteByIdAsync(id);
         //     if (res == null)
         //         return NotFound();
         //     return RedirectToAction(nameof(Index));
         // }

    }
}
