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
using MedHelper.Web.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Mail;
using System.Net;

namespace MedHelper.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public AccountController(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        public ActionResult ResetPassword()
        {
            return View();
        }

        public ActionResult Error()
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
            await _roleManager.CreateAsync(new Role() { Name = "Doctor" });
            user.UserName = user.FirstName + user.LastName;
            var createdUser = await _userManager.CreateAsync(user, user.Password);
            await _userManager.AddToRoleAsync(user, "Doctor");
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

            string confirmationToken = _userManager.
                 GenerateEmailConfirmationTokenAsync(user).Result;

            string confirmationLink = Url.Action("ConfirmEmail",
              "Account", new
              {
                  userid = user.Id,
                  token = confirmationToken
              },
               protocol: HttpContext.Request.Scheme);

            SmtpClient MyServer = new SmtpClient();
            MyServer.Host = "smtp.gmail.com";
            MyServer.Port = 587;
            MyServer.EnableSsl = true;
            //Server Credentials
            NetworkCredential NC = new NetworkCredential();
            NC.UserName = "medhelperteam@gmail.com";
            NC.Password = "345Edc345%%%";
            //assigned credetial details to server
            MyServer.Credentials = NC;

            //create sender address
            MailAddress from = new MailAddress("MedHelperTeam@gmail.com", "MedhelperTeam");

            //create receiver address
            MailAddress receiver = new MailAddress(user.Email, user.UserName);

            MailMessage Mymessage = new MailMessage(from, receiver);
            Mymessage.Subject = "Confirm email";
            Mymessage.Body = confirmationLink;
            //sends the email
            MyServer.Send(Mymessage);

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
                var userRole = await _userManager.GetRolesAsync(user);
                var claims = new List<Claim>() {
                    new Claim(ClaimTypes.NameIdentifier, Convert.ToString(user.Id)),
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.Role, userRole.First()),
                };
                //Initialize a new instance of the ClaimsIdentity with the claims and authentication scheme    
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                //Initialize a new instance of the ClaimsPrincipal with ClaimsIdentity    
                var principal = new ClaimsPrincipal(identity);
                //SignInAsync is a Extension method for Sign in a principal for the specified scheme.    
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties()
                {
                    IsPersistent = true
                }) ;

                return RedirectToAction("Index", "Home");
            }
            return View();
        }


        //Logout
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }


        public IActionResult ConfirmEmail(string userid, string token)
        {
            var user = _userManager.FindByIdAsync(userid).Result;
            var result = _userManager.
                        ConfirmEmailAsync(user, token).Result;
            if (result.Succeeded)
            {
                ViewBag.Message = "Email confirmed successfully!";
                return View("ConfirmEmail");
            }
            else
            {
                ViewBag.Message = "Error while confirming your email!";
                return View("Error");
            }
        }

    }
}
