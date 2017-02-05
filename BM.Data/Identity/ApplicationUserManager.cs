using BM.Data.EF;
using BM.Data.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace BM.Data.Identity
{
    public class ApplicationUserManager : UserManager<AppUser>
    {
        public ApplicationUserManager(IUserStore<AppUser> store): base(store)
        {}

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var manager = new ApplicationUserManager(new UserStore<AppUser>(context.Get<BirthdaysContext>()));

            return manager;
        }
    }
}