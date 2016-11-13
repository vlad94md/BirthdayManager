using System.Collections.Generic;
using BM.Model.Models;

namespace BM.Service.Interfaces
{
    public interface IUserService
    {
        IEnumerable<AppUser> GetUsers();
        AppUser GetUser(string username);
        void CreateUser(AppUser user);
        void RemoveUser(AppUser user);
        void EditUser(AppUser user);
    }
}