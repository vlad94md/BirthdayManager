using BM.Data.Repositories.Abstract;
using BM.Data.Repositories.Base;
using BM.Model.Models;

namespace BM.Data.Repositories.Concrete
{
    public class RoleRepository : RepositoryBase<AppRole>, IRoleRepository
    {
        public RoleRepository(IBirthdaysEntities context)
            : base(context) { }
    }
}