using BM.Data.Configuration;
using BM.Data.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace BM.Data.EF
{
    public class BirthdaysContext : IdentityDbContext<AppUser>, IBirthdaysContext
    {
        public BirthdaysContext() : base("BMEntities")
        {
            Database.SetInitializer(new BirthdaysSeedData());
            Database.Initialize(true);
        }

        public DbSet<BirthdayArrangement> BirthdayArrangements { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Gift> Gifts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new BirthdayArrangementConfiguration());

            // Identity Configurations
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }
    }
}
