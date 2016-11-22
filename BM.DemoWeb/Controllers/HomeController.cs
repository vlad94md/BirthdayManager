using BM.Service.Interfaces;
using System.Linq;
using System.Web.Mvc;

namespace BM.DemoWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService userService;
        private readonly IBirthdayArrangementService arrangementService;


        public HomeController(IUserService userService, IBirthdayArrangementService arrangementService)
        {
            this.userService = userService;
            this.arrangementService = arrangementService;
        }

        public ActionResult Index()
        {
            var users = userService.GetUsers().ToList();
            var birthdays = arrangementService.GetArrangements().ToList();

            return View();
        }
    }
}