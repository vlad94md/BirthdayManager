using BM.DemoWeb.Models;
using BM.Service.Dto;
using BM.Service.Interfaces;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BM.DemoWeb.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private IUserService UserService
        {
            get { return HttpContext.GetOwinContext().GetUserManager<IUserService>(); }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LogInModel model)
        {
            await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                UserDto userDto = new UserDto { UserName = model.Username, PasswordHash = model.Password };
                ClaimsIdentity claim = await UserService.Authenticate(userDto);
                if (claim == null)
                {
                    ModelState.AddModelError("", "Wrong username or password");
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = true }, claim);
                    return Redirect(GetRedirectUrl(model.ReturnUrl));
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }


        private async Task SetInitialDataAsync()
        {
            await UserService.SetInitialData(new UserDto
            {
                UserName = "admin",
                PasswordHash = "123456",
                FirstName = "Didina",
                LastName = "Prodan",
                Role = "admin",
                DateOfBirth = DateTime.ParseExact("1993.25.10", "yyyy.dd.MM", CultureInfo.InvariantCulture)
            }, new List<string> { "user", "admin" });
        }

        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return "/";
            }

            return returnUrl;
        }
    }
}