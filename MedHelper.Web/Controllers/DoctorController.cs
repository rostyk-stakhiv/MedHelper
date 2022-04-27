using MedHelper.BLL.Interfaces;
using MedHelper.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedHelper.Web.Controllers
{
    public class DoctorController : Controller
    {

        private IDoctorService _doctorService;
        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }
        public IActionResult Index()
        {
            var doctor = _doctorService.GetById(2);
            ViewBag.Doctor = doctor;
            return View();
        }
    }
}
