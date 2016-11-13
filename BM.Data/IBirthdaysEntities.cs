using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using BM.Model.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BM.Data
{
    public interface IBirthdaysEntities
    {
        DbSet<BirthdayArrangement> BirthdayArrangements { get; set; }
        DbSet<Payment> Payments { get; set; }
        DbSet<Gift> Gifts { get; set; }
        IDbSet<AppUser> Users { get; set; }
        IDbSet<IdentityRole> Roles { get; set; }
        DbSet<T> Set<T>() where T : class;
        DbSet Set(Type entityType);
        DbEntityEntry Entry(object entity);
        int SaveChanges();
        Task<int> SaveChangesAsync();
        void Dispose();
    }
}