using BM.Data.Infrastructure;
using BM.Data.Repositories;
using BM.Model.Models;
using System.Collections.Generic;
using BM.Data.Repositories.Abstract;
using BM.Service.Interfaces;

namespace BM.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<AppUser> GetUsers()
        {
            var users = unitOfWork.Users.GetAll();
            return users;
        }

        public AppUser GetUser(string username)
        {
            var user = unitOfWork.Users.GetByUserName(username);
            return user;
        }

        public void CreateUser(AppUser user)
        {
            unitOfWork.Users.Add(user);
            unitOfWork.Commit();
        }

        public void EditUser(AppUser user)
        {
            unitOfWork.Users.Update(user);
            unitOfWork.Commit();
        }

        public void RemoveUser(AppUser user)
        {
            unitOfWork.Users.Delete(user);
            unitOfWork.Commit();
        }
    }
}