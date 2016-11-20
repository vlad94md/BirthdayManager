using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BM.Data.Repositories;
using BM.Data.Repositories.Interfaces;

namespace BM.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IPaymentRepository Payments { get; }
        IBirthdayArrangementRepository BirthdayArrangements { get; }
        IGiftRepository Gifts { get; }
        IRoleRepository Roles { get; }
        void Commit();
        void Dispose();
    }
}
