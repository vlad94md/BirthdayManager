using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BM.Service.Interfaces;

namespace BM.Service.Services
{
    public class ServiceCreator : IServiceCreator
    {
        private IUserService userService;

        public ServiceCreator(IUserService userService)
        {
            this.userService = userService;
        }

        public IUserService CreateUserService(string connection)
        {
            return userService;
        }
    }
}
