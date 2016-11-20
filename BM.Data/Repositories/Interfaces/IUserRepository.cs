using BM.Data.Entities;
using BM.Data.Repositories.Base;

namespace BM.Data.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<AppUser>
    {
        AppUser GetByUserName(string username);
    }
}