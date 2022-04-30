using MedHelper.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MedHelper.Web.Controllers
{
    public class MedicineController : Controller
    {
        IMedicineService _medicineService;
        public MedicineController(IMedicineService medicineService)
        {
            _medicineService = medicineService;
        }
        [HttpGet("/Medicine/{id}")]
        public async Task<IActionResult> ViewMedicine(int id)
        {
            var medicine = await _medicineService.GetByIdAsync(id);
            ViewBag.Medicine = medicine;
            ViewBag.Composition = medicine.Compositions.ToList();
            ViewBag.Contraindications = medicine.Contraindications.ToList();
            ViewBag.Interactions = medicine.MedicineInteractions.ToList();
            return View();
        }
    }
}
