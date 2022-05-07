using MedHelper.BLL.Dto.Responses;
using MedHelper.BLL.Interfaces;
using MedHelper.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public async Task<IActionResult> Index(string searchString)
        {
            int id = int.Parse(User.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value);
            var doctor = await _doctorService.GetByIdAsync(id);
            DoctorResponse response = new DoctorResponse()
            {
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Email = doctor.Email,
                Patients = doctor.Patients
            };


            if (!String.IsNullOrEmpty(searchString)) 
            {
                var p = _doctorService.GetPatients(id, searchString);
                response.Patients = p;
            }

            ViewBag.Message = TempData["searchString"] != null ? TempData["searchString"] : "";

            return View(response);
        }

        /*public ActionResult PatientList(string searchKey)
        {
            int id = int.Parse(User.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value);
            var p = _doctorService.GetPatients(id, searchKey);
            ViewBag.Doctor.Patients = p;
            return View();
        }*/
    }
}
