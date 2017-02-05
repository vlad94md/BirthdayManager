using BM.Data.Identity;
using BM.Data.Infrastructure;
using BM.Service.Interfaces;
using BM.Service.Services;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace BM.Service.Identity
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(CreateUserService);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Auth/Login"),
            });
        }

        private IUserService CreateUserService()

        {
            return new UserService(new UnitOfWork());
        }
    }
}