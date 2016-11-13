using BM.Data.Infrastructure;
using BM.Data.Repositories.Abstract;
using BM.Data.Repositories.Base;
using BM.Model.Models;

namespace BM.Data.Repositories.Concrete
{
    public class UserRepository : RepositoryBase<AppUser>, IUserRepository
    {
        public UserRepository(IBirthdaysEntities context)
            : base(context) { }

        public AppUser GetByUserName(string username)
        {
            return Get(x => x.UserName == username);
        }
    }
}