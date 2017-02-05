using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using BM.Data.Entities;
using BM.Service.Dto;
using BM.Service.Infrastructure;

namespace BM.Service.Interfaces
{
    public interface IUserService : IDisposable
    {
        IEnumerable<UserDto> GetUsers();
        UserDto GetUser(string username);
        Task<OperationDetails> Create(UserDto userDto);
        Task<ClaimsIdentity> Authenticate(UserDto userDto);
        Task SetInitialData(UserDto adminDto, List<string> roles);
        void CreateUser(UserDto userDto);
        void RemoveUser(UserDto userDto);
        void EditUser(UserDto userDto);
    }
}