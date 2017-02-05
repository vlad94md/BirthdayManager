using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BM.Data.EF;
using BM.Data.Entities;
using BM.Data.Identity;
using BM.Data.Repositories;
using BM.Data.Repositories.Concrete;
using BM.Data.Repositories.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BM.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private BirthdaysContext dbContext;

        private IUserRepository userRepository;
        private IPaymentRepository paymentRepository;
        private IBirthdayArrangementRepository birthdaysRepository;
        private IGiftRepository giftRepository;
        private ApplicationUserManager userManager;
        private ApplicationRoleManager roleManager;

        public UnitOfWork()
        {
            dbContext = new BirthdaysContext();
            userManager = new ApplicationUserManager(new UserStore<AppUser>(dbContext));
            roleManager = new ApplicationRoleManager(new RoleStore<AppRole>(dbContext));
        }

        public IUserRepository Users
        {
            get { return userRepository ?? (userRepository = new UserRepository(dbContext)); }
        }

        public IPaymentRepository Payments
        {
            get { return paymentRepository ?? (paymentRepository = new PaymentRepository(dbContext)); }
        }

        public IBirthdayArrangementRepository BirthdayArrangements
        {
            get { return birthdaysRepository ?? (birthdaysRepository = new BirthdayArrangementRepository(dbContext));}
        }

        public IGiftRepository Gifts
        {
            get { return giftRepository ?? (giftRepository = new GiftRepository(dbContext)); }
        }

        public ApplicationUserManager UserManager
        {
            get { return userManager; }
        }

        public ApplicationRoleManager RoleManager
        {
            get { return roleManager; }
        }

        public void Commit()
        {
            dbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await dbContext.SaveChangesAsync();
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
