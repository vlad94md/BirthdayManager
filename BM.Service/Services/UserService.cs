using System.Collections.Generic;
using AutoMapper;
using BM.Data.Entities;
using BM.Data.Infrastructure;
using BM.Service.Dto;
using BM.Service.Interfaces;

namespace BM.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<UserDto> GetUsers()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<AppUser, UserDto>());
            return Mapper.Map<IEnumerable<AppUser>, List<UserDto>>(unitOfWork.Users.GetAll());
        }

        public UserDto GetUser(string username)
        {
            var user = unitOfWork.Users.GetByUserName(username);

            Mapper.Initialize(cfg => cfg.CreateMap<AppUser, UserDto>());
            return Mapper.Map<AppUser, UserDto>(user);
        }

        public void CreateUser(UserDto user)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<UserDto, AppUser>());
            var userModel = Mapper.Map<UserDto, AppUser>(user);

            unitOfWork.Users.Add(userModel);
            unitOfWork.Commit();
        }

        public void EditUser(UserDto user)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<UserDto, AppUser>());
            var userModel = Mapper.Map<UserDto, AppUser>(user);

            unitOfWork.Users.Update(userModel);
            unitOfWork.Commit();
        }

        public void RemoveUser(UserDto user)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<UserDto, AppUser>());
            var userModel = Mapper.Map<UserDto, AppUser>(user);

            unitOfWork.Users.Delete(userModel);
            unitOfWork.Commit();
        }
    }
}