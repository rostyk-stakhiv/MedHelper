using MedHelper.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using MedHelper.BLL.Dto.Medicine;
using MedHelper.BLL.Dto.Patient;
using Microsoft.AspNetCore.Authorization;

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
        public async Task<IActionResult> ViewMedicine(int id)
        {
            var medicine = await _medicineService.GetByIdAsync(id);
            ViewBag.Medicine = medicine;
            ViewBag.Composition = medicine.Compositions.ToList();
            ViewBag.Contraindications = medicine.Contraindications.ToList();
            ViewBag.Interactions = medicine.MedicineInteractions.ToList();
            return View();
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
    }
}
