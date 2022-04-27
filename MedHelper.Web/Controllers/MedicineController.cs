using MedHelper.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult ViewMedicine(int id)
        {
            var medicine = _medicineService.GetById(id);
            ViewBag.Medicine = medicine;
            ViewBag.Composition = medicine.MedicineCompositions.ToList();
            ViewBag.Contraindications = medicine.MedicineContraindications.ToList();
            ViewBag.Interactions = medicine.MedicineInteractions.ToList();
            return View();
        }
    }
}
