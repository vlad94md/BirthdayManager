using AutoMapper;
using BM.Data;
using BM.Service;
using BM.DemoWeb.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BM.Service.Interfaces;

namespace BM.DemoWeb.Controllers
{

    public class HomeController : Controller
    {
        //private readonly ICategoryService categoryService;
        //private readonly IGadgetService gadgetService;
        private readonly IUserService userService;

        public HomeController(IUserService userService)
        {
            this.userService = userService;
        }

        public ActionResult Index(string category = null)
        {
            IEnumerable<CategoryViewModel> viewModelGadgets;
            //IEnumerable<Category> categories;

            //categories = categoryService.GetCategories(category).ToList();

            //try
            //{
            //    var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();

            //    var user = new AppUser
            //    {
            //        UserName = "franko",
            //        OldUsername = "frankoold",
            //        FirstName = "Frank",
            //        LastName = "Ouimette",
            //        Email = "franko@emailservice.com",
            //        DateOfBirth = DateTime.ParseExact("2015.05.05", "yyyy.dd.MM",
            //                        System.Globalization.CultureInfo.InvariantCulture)
            //    };

            //    var result = userManager.Create(user, "Temp_123");

            //    if (result.Succeeded)
            //    {
            //        result = userManager.AddToRole(user.Id, "User");

            //        // User added successfully, you can safely use the Id now.
            //        var id = user.Id;

            //    }
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //}

            //viewModelGadgets = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(categories);
            return View();
        }

        //public ActionResult Filter(string category, string gadgetName)
        //{
        //    IEnumerable<GadgetViewModel> viewModelGadgets;
        //    IEnumerable<Gadget> gadgets;

        //    gadgets = gadgetService.GetCategoryGadgets(category, gadgetName);

        //    viewModelGadgets = Mapper.Map<IEnumerable<Gadget>, IEnumerable<GadgetViewModel>>(gadgets);

        //    return View(viewModelGadgets);
        //}

        //[HttpPost]
        //public ActionResult Create(GadgetFormViewModel newGadget)
        //{
        //    if (newGadget != null && newGadget.File != null)
        //    {
        //        var gadget = Mapper.Map<GadgetFormViewModel, Gadget>(newGadget);
        //        gadgetService.CreateGadget(gadget);

        //        string gadgetPicture = System.IO.Path.GetFileName(newGadget.File.FileName);
        //        string path = System.IO.Path.Combine(Server.MapPath("~/Content/images/"), gadgetPicture);
        //        newGadget.File.SaveAs(path);

        //        gadgetService.SaveGadget();
        //    }

        //    var category = categoryService.GetCategory(newGadget.GadgetCategory);
        //    return RedirectToAction("Index", new { category = category.Name });
        //}
    }
}