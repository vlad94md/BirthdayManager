using AutoMapper;
using BM.Data.Entities;
using BM.Data.Infrastructure;
using BM.Service.Dto;
using BM.Service.Interfaces;
using System.Collections.Generic;

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

        public void CreateUser(UserDto userDto)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<UserDto, AppUser>());
            var user = Mapper.Map<UserDto, AppUser>(userDto);

            unitOfWork.Users.Add(user);
            unitOfWork.Commit();
        }

        public void EditUser(UserDto userDto)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<UserDto, AppUser>());
            var user = Mapper.Map<UserDto, AppUser>(userDto);

            unitOfWork.Users.Update(user);
            unitOfWork.Commit();
        }

        public void RemoveUser(UserDto userDto)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<UserDto, AppUser>());
            var user = Mapper.Map<UserDto, AppUser>(userDto);

            unitOfWork.Users.Delete(user);
            unitOfWork.Commit();
        }
    }
}