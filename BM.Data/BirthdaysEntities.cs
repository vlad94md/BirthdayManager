using BM.Data.Configuration;
using BM.Model;
using BM.Model.Models;
using System.Data.Entity;

namespace BM.Data
{
    public class BirthdaysEntities : DbContext
    {
        public BirthdaysEntities() : base("BMEntities")
        {
            Database.SetInitializer(new BirthdaysSeedData());
            Database.Initialize(true);
        }

        public DbSet<Gadget> Gadgets { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<BirthdayArrangement> BirthdayArrangements { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Gift> Gifts { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GadgetConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());

            modelBuilder.Entity<User>()
                .HasMany(t => t.BirthdaySubscriptions)
                .WithMany(t => t.Сongratulators);

            modelBuilder.Entity<BirthdayArrangement>()
                .HasMany(t => t.Сongratulators)
                .WithMany(t => t.BirthdaySubscriptions);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Birthdays)
                .WithRequired(b => b.BirthdayMan)
                .HasForeignKey(s => s.BirthdayManId)
                .WillCascadeOnDelete(false);

            //modelBuilder.Entity<BirthdayArrangement>()
            //    .HasRequired(e => e.BirthdayMan);
        }
    }
}
