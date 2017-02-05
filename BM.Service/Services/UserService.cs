using System;
using AutoMapper;
using BM.Data.Entities;
using BM.Data.Infrastructure;
using BM.Service.Dto;
using BM.Service.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BM.Service.Infrastructure;
using Microsoft.AspNet.Identity;

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

        public async Task<OperationDetails> Create(UserDto userDto)
        {
            AppUser user = await unitOfWork.UserManager.FindByNameAsync(userDto.UserName);
            if (user != null)
            {
                return new OperationDetails(false, "User with such username already exists", "UserName");
            }

            Mapper.Initialize(cfg => cfg.CreateMap<UserDto, AppUser>());
            user = Mapper.Map<UserDto, AppUser>(userDto);

            user.Id = Guid.NewGuid().ToString();
            byte[] ret = Encoding.Unicode.GetBytes(user.PasswordHash);
            user.PasswordHash = Convert.ToBase64String(ret);

            try
            {
                var result = await unitOfWork.UserManager.CreateAsync(user, userDto.PasswordHash);
                if (result.Errors.Any())
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");
            }
            catch (Exception e)
            {
                return new OperationDetails(false, "User creation failed", "");
            }

            await unitOfWork.UserManager.AddToRoleAsync(user.Id, userDto.Role);
            await unitOfWork.SaveAsync();

            return new OperationDetails(true, "A new user registered with user name" + user.UserName, "");
        }

        public async Task<ClaimsIdentity> Authenticate(UserDto userDto)
        {
            ClaimsIdentity claim = null;
            AppUser user = await unitOfWork.UserManager.FindAsync(userDto.UserName, userDto.PasswordHash);

            if (user != null)
                claim = await unitOfWork.UserManager.CreateIdentityAsync(user,
                                            DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }

        public async Task SetInitialData(UserDto adminDto, List<string> roles)
        {
            foreach (string roleName in roles)
            {
                var role = await unitOfWork.RoleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new AppRole { Name = roleName };
                    await unitOfWork.RoleManager.CreateAsync(role);
                }
            }
            await Create(adminDto);
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

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}