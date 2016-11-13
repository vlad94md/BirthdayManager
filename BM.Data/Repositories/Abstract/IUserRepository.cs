using BM.Data.Repositories.Base;
using BM.Model.Models;

namespace BM.Data.Repositories.Abstract
{
    public interface IUserRepository : IRepository<AppUser>
    {
        AppUser GetByUserName(string username);
    }
}