﻿using MedHelper.BLL.Dto.Doctor;
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
        public async Task<IActionResult> Index(string search)
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


            if (!String.IsNullOrEmpty(search)) 
            {
                var p = _doctorService.GetPatients(id, search);
                response.Patients = p;
            }

            return View(response);
        }


        [Authorize(Roles = "Doctor")]
        public async Task<IActionResult> Edit()
        {
            int id = int.Parse(User.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value);
            var doctor = await _doctorService.GetInfoForUpdate(id);
            return View(doctor);
        }

        [Authorize(Roles = "Doctor")]
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateDoctorDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                await _doctorService.UpdateAsync(model);
                return RedirectToAction("Index");
            }
        }
    }
}
