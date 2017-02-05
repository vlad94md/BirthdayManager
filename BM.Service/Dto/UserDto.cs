using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Service.Dto
{
    public class UserDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PasswordHash { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Balance { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
    }
}
