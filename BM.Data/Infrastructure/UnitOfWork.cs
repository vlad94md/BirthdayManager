using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BM.Data.EF;
using BM.Data.Repositories;
using BM.Data.Repositories.Concrete;
using BM.Data.Repositories.Interfaces;

namespace BM.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private IBirthdaysContext dbContext;
        private IUserRepository userRepository;
        private IPaymentRepository paymentRepository;
        private IBirthdayArrangementRepository birthdayArrangementRepository;
        private IGiftRepository giftRepository;
        private IRoleRepository roleRepository;

        public UnitOfWork(IBirthdaysContext context)
        {
            this.dbContext = context;
        }

        public IUserRepository Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(dbContext);
                return userRepository;
            }
        }

        public IPaymentRepository Payments
        {
            get
            {
                if (paymentRepository == null)
                    paymentRepository = new PaymentRepository(dbContext);
                return paymentRepository;
            }
        }

        public IBirthdayArrangementRepository BirthdayArrangements
        {
            get
            {
                if (birthdayArrangementRepository == null)
                    birthdayArrangementRepository = new BirthdayArrangementRepository(dbContext);
                return birthdayArrangementRepository;
            }
        }

        public IGiftRepository Gifts
        {
            get
            {
                if (giftRepository == null)
                    giftRepository = new GiftRepository(dbContext);
                return giftRepository;
            }
        }

        public IRoleRepository Roles
        {
            get
            {
                if (roleRepository == null)
                    roleRepository = new RoleRepository(dbContext);
                return roleRepository;
            }
        }

        public void Commit()
        {
            dbContext.SaveChanges();
        }

        private bool disposed;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
