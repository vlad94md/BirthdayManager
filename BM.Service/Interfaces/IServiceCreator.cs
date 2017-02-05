using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Service.Interfaces
{
    public interface IServiceCreator
    {
        IUserService CreateUserService(string connection);
    }
}
