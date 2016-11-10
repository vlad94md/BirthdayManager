using BM.Data.Configuration;
using BM.Model;
using BM.Model.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BM.Data
{
    public class BirthdaysEntities : IdentityDbContext<AppUser>
    {
        public BirthdaysEntities() : base("BMEntities")
        {
            Database.SetInitializer(new BirthdaysSeedData());
            Database.Initialize(true);
        }

        public DbSet<BirthdayArrangement> BirthdayArrangements { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Gift> Gifts { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());

            modelBuilder.Entity<AppUser>()
                .HasMany(t => t.Subscriptions)
                .WithMany(t => t.Сongratulators);

            modelBuilder.Entity<BirthdayArrangement>()
                .HasMany(t => t.Сongratulators)
                .WithMany(t => t.Subscriptions);

            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }
    }
}
