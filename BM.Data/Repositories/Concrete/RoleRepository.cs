using BM.Data.Infrastructure;
using BM.Model.Models;

namespace BM.Data.Repositories
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
    }
}