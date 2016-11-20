using BM.Data.EF;
using BM.Data.Entities;
using BM.Data.Infrastructure;
using BM.Data.Repositories.Base;
using BM.Data.Repositories.Interfaces;

namespace BM.Data.Repositories.Concrete
{
    public class UserRepository : RepositoryBase<AppUser>, IUserRepository
    {
        public UserRepository(IBirthdaysContext context)
            : base(context) { }

        public AppUser GetByUserName(string username)
        {
            return Get(x => x.UserName == username);
        }
    }
}