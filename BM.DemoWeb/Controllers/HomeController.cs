using BM.Service;
using System.Linq;
using System.Web.Mvc;
using BM.Service.Interfaces;

namespace BM.DemoWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService userService;

        public HomeController(IUserService userService)
        {
            this.userService = userService;
        }

        public ActionResult Index()
        {
            var users = userService.GetUsers().ToList();
            return View();
        }
    }
}