using BM.Data.Infrastructure;
using BM.Model.Models;

namespace BM.Data.Repositories
{
    public class UserRepository : RepositoryBase<AppUser>, IUserRepository
    {
        public UserRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
    }
}