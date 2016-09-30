using BM.Data.Infrastructure;
using BM.Data.Repositories;
using BM.Model.Models;
using System.Collections.Generic;

namespace BM.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        //private readonly ICategoryRepository categoryRepository;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IGadgetService Members

        public IEnumerable<User> GetUsers()
        {
            var users = userRepository.GetAll();
            return users;
        }

        public User GetUser(int id)
        {
            var user = userRepository.GetById(id);
            return user;
        }

        public void CreateUser(User user)
        {
            userRepository.Add(user);
        }

        public void SaveUser()
        {
            unitOfWork.Commit();
        }

        #endregion

    }
}