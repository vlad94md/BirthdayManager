using AutoMapper;
using BM.Service;
using BM.DemoWeb.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.UI.WebControls;
using BM.Data.Entities;
using BM.Service.Interfaces;

namespace BM.DemoWeb.Controllers.Api
{
    public class UserController : ApiController
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public IEnumerable<UserViewModel> GetAll()
        {
            IEnumerable<AppUser> users = userService.GetUsers().ToList();

            var usersModels = Mapper.Map<IEnumerable<AppUser>, IEnumerable<UserViewModel>>(users);
            return usersModels;
        }
    }
}
