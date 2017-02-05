using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BM.Data.Identity;
using BM.Data.Repositories;
using BM.Data.Repositories.Interfaces;

namespace BM.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        ApplicationUserManager UserManager { get; }
        IUserRepository Users { get; }
        IPaymentRepository Payments { get; }
        IBirthdayArrangementRepository BirthdayArrangements { get; }
        IGiftRepository Gifts { get; }
        ApplicationRoleManager RoleManager { get; }
        void Commit();
        void Dispose();
        Task SaveAsync();
    }
}
