using MedHelper.BLL.Interfaces;
using MedHelper.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MedHelper.Web.Controllers
{
    public class DoctorController : Controller
    {

        private IDoctorService _doctorService;
        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }
        public async Task<IActionResult> Index()
        {
            var doctor = await _doctorService.GetByIdAsync(1);
            ViewBag.Doctor = doctor;
            return View();
        }
    }
}
