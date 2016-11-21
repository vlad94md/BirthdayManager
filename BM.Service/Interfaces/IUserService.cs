using System.Collections.Generic;
using BM.Data.Entities;
using BM.Service.Dto;

namespace BM.Service.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetUsers();
        UserDto GetUser(string username);
        void CreateUser(UserDto userDto);
        void RemoveUser(UserDto userDto);
        void EditUser(UserDto userDto);
    }
}