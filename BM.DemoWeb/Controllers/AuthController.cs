using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BM.DemoWeb.Models;
using BM.Service.Dto;
using BM.Service.Infrastructure;
using BM.Service.Interfaces;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

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

        //[HttpGet]
        //public ActionResult LogIn(string returnUrl = "/auth")
        //{
        //    var model = new LogInModel
        //    {
        //        ReturnUrl = returnUrl
        //    };

        //    return View(model);
        //}

        //[HttpPost]
        //public ActionResult LogIn(LogInModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View();
        //    }

        //    // Don't do this in production!
        //    if (model.Username == "admin" && model.Password == "admin")
        //    {
        //        var identity = new ClaimsIdentity(new[] {
        //        new Claim(ClaimTypes.Name, "Admin"),
        //        new Claim(ClaimTypes.Email, "a@b.com"),
        //        new Claim(ClaimTypes.Country, "England")
        //    },
        //            "ApplicationCookie");

        //        var ctx = Request.GetOwinContext();
        //        var authManager = ctx.Authentication;

        //        authManager.SignIn(identity);

        //        return Redirect(GetRedirectUrl(model.ReturnUrl));
        //    }

        //    // user authN failed
        //    ModelState.AddModelError("", "Invalid username or password");
        //    return View();
        //}

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

        //public ActionResult Register()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Register(RegisterModel model)
        //{
        //    await SetInitialDataAsync();
        //    if (ModelState.IsValid)
        //    {
        //        User userDto = new User
        //        {
        //            Email = model.Email,
        //            Password = model.Password,
        //            Address = model.Address,
        //            Name = model.Name,
        //            Role = "user"
        //        };
        //        OperationDetails operationDetails = await UserService.Create(userDto);
        //        if (operationDetails.Succedeed)
        //            return View("SuccessRegister");
        //        else
        //            ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
        //    }
        //    return View(model);
        //}

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