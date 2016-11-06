using BM.Data.Infrastructure;
using BM.Model.Models;

namespace BM.Data.Repositories
{
    public class RoleRepository : RepositoryBase<AppRole>, IRoleRepository
    {
        public RoleRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
    }
}