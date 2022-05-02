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
        private readonly UserManager<User> _userManager;

        public AuthorizationController(MedHelperDBContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public ActionResult Register()
        {
            return View();
        }

        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(User user)
        {
            if (await _userManager.FindByEmailAsync(user.Email) != null)
            {

                ViewBag.error = "Email already exists";
                return View();
            }
            // var newUser = user
            user.UserName = user.FirstName + user.LastName;
            var createdUser = await _userManager.CreateAsync(user, user.Password);
            if (!createdUser.Succeeded)
            {

                ViewBag.error = "error";
                return View();
            }
            //Use roleManager
            //if (ModelState.IsValid)
            //{
            //    Role r = _context.Roles.FirstOrDefault(x => x.UserRole == "Doctor");
            //    UserRole ur = new UserRole { Role = r, User = _user };
            //    var check = _context.Users.FirstOrDefault(s => s.Email == _user.Email);
            //    if (check == null)
            //    {
            //        _context.Users.Add(_user);
            //        _context.UserRoles.Add(ur);
            //        _context.SaveChanges();
            //        return RedirectToAction("Index", "Home");
            //    }
            //    else
            //    {
            //        ViewBag.error = "Email already exists";
            //        return View();
            //    }
            //}
            return View("Login");


        }

        public ActionResult Login()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(string email, string password)
        {

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(email);
                bool isPasswordValid = await _userManager.CheckPasswordAsync(user, password);
                if (!isPasswordValid)
                {
                    ViewBag.error = "Login failed";
                    return View("Login");
                }
                var claims = new List<Claim>() {
                    new Claim(ClaimTypes.NameIdentifier, Convert.ToString(user.Id)),
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.Role, "use role managet to get roles:)"),
                };
                //Initialize a new instance of the ClaimsIdentity with the claims and authentication scheme    
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                //Initialize a new instance of the ClaimsPrincipal with ClaimsIdentity    
                var principal = new ClaimsPrincipal(identity);
                //SignInAsync is a Extension method for Sign in a principal for the specified scheme.    
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties()
                {
                    IsPersistent = false
                });

                return RedirectToAction("Index", "Home");
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
