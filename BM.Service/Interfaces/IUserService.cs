using System.Collections.Generic;
using BM.Model.Models;

namespace BM.Service
{
    public interface IUserService
    {
        IEnumerable<AppUser> GetUsers();
        AppUser GetUser(int id);
        void CreateUser(AppUser user);
        void SaveUser();
    }
}