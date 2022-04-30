using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MedHelper.DAL.Entities;
using MedHelper.DAL.Enums;
using MedHelper.DAL;
using MedHelper.Web.Models;

namespace MedHelper.Web.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly MedHelperDBContext _context;

        public AuthorizationController(MedHelperDBContext context)
        {
            _context = context;
        }

        public ActionResult Register()
        {
            return View();
        }

        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User _user)
        {
            if (ModelState.IsValid)
            {
                Role r = _context.Roles.FirstOrDefault(x => x.UserRole == "Doctor");
                UserRole ur = new UserRole { Role = r, User = _user };
                var check = _context.Users.FirstOrDefault(s => s.Email == _user.Email);
                if (check == null)
                {
                    _context.Users.Add(_user);
                    _context.UserRoles.Add(ur);
                    _context.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }
            }
            return View();


        }

        public ActionResult Login()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                var data = _context.Users.Where(s => s.Email.Equals(email) && s.Password.Equals(password)).ToList();
                if (data.Count() > 0)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return View("Login");
                }
            }
            return View();
        }


        //Logout
        public ActionResult Logout()
        {
            return RedirectToAction("Login");
        }
    }
}
