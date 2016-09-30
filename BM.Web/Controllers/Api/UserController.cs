using AutoMapper;
using BM.Model.Models;
using BM.Service;
using BM.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace BM.Web.Controllers.Api
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
            IEnumerable<User> users = userService.GetUsers().ToList();

            var usersModels = Mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(users);
            return usersModels;
        }
    }
}
