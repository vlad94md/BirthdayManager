using AutoMapper;
using BM.Model;
using BM.Service;
using BM.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BM.Model.Models;

namespace BM.Web.Controllers
{

    public class HomeController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IGadgetService gadgetService;
        private readonly IUserService userService;

        public HomeController(ICategoryService categoryService, IGadgetService gadgetService,  IUserService userService)
        {
            this.categoryService = categoryService;
            this.gadgetService = gadgetService;
            this.userService = userService;
        }

        // GET: Home
        public ActionResult Index(string category = null)
        {
            IEnumerable<CategoryViewModel> viewModelGadgets;
            IEnumerable<Category> categories;

            categories = categoryService.GetCategories(category).ToList();
            IEnumerable<User> users = userService.GetUsers().ToList();


            viewModelGadgets = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(categories);
            return View(viewModelGadgets);
        }

        public ActionResult Filter(string category, string gadgetName)
        {
            IEnumerable<GadgetViewModel> viewModelGadgets;
            IEnumerable<Gadget> gadgets;

            gadgets = gadgetService.GetCategoryGadgets(category, gadgetName);

            viewModelGadgets = Mapper.Map<IEnumerable<Gadget>, IEnumerable<GadgetViewModel>>(gadgets);

            return View(viewModelGadgets);
        }

        [HttpPost]
        public ActionResult Create(GadgetFormViewModel newGadget)
        {
            if (newGadget != null && newGadget.File != null)
            {
                var gadget = Mapper.Map<GadgetFormViewModel, Gadget>(newGadget);
                gadgetService.CreateGadget(gadget);

                string gadgetPicture = System.IO.Path.GetFileName(newGadget.File.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/Content/images/"), gadgetPicture);
                newGadget.File.SaveAs(path);

                gadgetService.SaveGadget();
            }

            var category = categoryService.GetCategory(newGadget.GadgetCategory);
            return RedirectToAction("Index", new { category = category.Name });
        }
    }
}