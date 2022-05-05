using MedHelper.BLL.Interfaces;
using MedHelper.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
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

        [Authorize(Roles ="Doctor")]
        public async Task<IActionResult> Index()
        {
            int id = int.Parse(this.User.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value);
            var doctor = await _doctorService.GetByIdAsync(id);
            ViewBag.Doctor = doctor;
            return View();
        }
    }
}
