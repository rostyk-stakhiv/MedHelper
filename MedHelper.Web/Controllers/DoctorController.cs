using MedHelper.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedHelper.Web.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
            var doctor = new UserModel()
            {
                Id = 1,
                FirstName = "Victor",
                LastName = "Pro",
                Email = "victor@gmail.com",
                Patients = new List<PatientModel>() { new PatientModel() { Id=1, FirstName = "Ivan", LastName = "Petrov" } },
                PatientsId = new List<int>() { 1 }
            };
            ViewBag.Doctor = doctor;
            return View();
        }
    }
}
