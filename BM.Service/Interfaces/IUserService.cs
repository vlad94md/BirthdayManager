using System.Collections.Generic;
using BM.Model.Models;

namespace BM.Service
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User GetUser(int id);
        void CreateUser(User user);
        void SaveUser();
    }
}