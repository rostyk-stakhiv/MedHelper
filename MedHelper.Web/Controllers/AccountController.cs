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

        [HttpPost]
        public async Task<ActionResult> ForgotPassword(ForgetPasswordViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if(user == null)
            {
                user= await _userManager.FindByNameAsync(model.Email);
            }
            if(user != null)
            {
                var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                string resetLink = Url.Action("ResetPassword",
              "Account", new
              {
                  userid = user.Id,
                  token = resetToken
              },
               protocol: HttpContext.Request.Scheme);

                SendEmail(resetLink, "Reset Password", user.Email);
                return RedirectToAction("Login");
            }
            return View();
        }


        public ActionResult ResetPassword(string userid, string token)
        {
            var model = new ResetPasswordViewModel
            {
                UserId = userid,
                Token = token
            };
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
            return RedirectToAction("Login");
        }

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult EmailChanged()
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

            await _roleManager.CreateAsync(new Role() { Name = "Doctor" });
            user.UserName = user.FirstName + user.LastName;
            var createdUser = await _userManager.CreateAsync(user, user.Password);
            await _userManager.AddToRoleAsync(user, "Doctor");
            if (!createdUser.Succeeded)
            {

                ViewBag.error = "error";
                return View();
            }

            string confirmationToken = _userManager.
                 GenerateEmailConfirmationTokenAsync(user).Result;

            string confirmationLink = Url.Action("ConfirmEmail",
              "Account", new
              {
                  userid = user.Id,
                  token = confirmationToken
              },
               protocol: HttpContext.Request.Scheme);

            SendEmail(confirmationLink, "Confirm Email", user.Email);

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
                if(!user.EmailConfirmed)
                {
                    ViewBag.error = "Email is not confirmed";
                    return View("Login");
                }
                var userRole = await _userManager.GetRolesAsync(user);
                var claims = new List<Claim>() {
                    new Claim(ClaimTypes.NameIdentifier, Convert.ToString(user.Id)),
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.Role, userRole.First()),
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
 
                var principal = new ClaimsPrincipal(identity);
  
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties()
                {
                    IsPersistent = true
                }) ;

                return RedirectToAction("Index", "Home");
            }
            return View();
        }


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
                return View("ConfirmEmail");
            }
            else
            {
                return View("Error");
            }
        }

        private void SendEmail(string text, string theme, string receiverEmail)
        {
            SmtpClient MyServer = new SmtpClient();
            MyServer.Host = "smtp.gmail.com";
            MyServer.Port = 587;
            MyServer.EnableSsl = true;

            NetworkCredential NC = new NetworkCredential();
            NC.UserName = "medhelperteam@gmail.com";
            NC.Password = "345Edc345%%%";

            MyServer.Credentials = NC;


            MailAddress from = new MailAddress("MedHelperTeam@gmail.com", "MedhelperTeam");


            MailAddress receiver = new MailAddress(receiverEmail, receiverEmail);

            MailMessage Mymessage = new MailMessage(from, receiver);
            Mymessage.Subject = theme;
            Mymessage.Body = text;

            MyServer.Send(Mymessage);
        }

    }
}
