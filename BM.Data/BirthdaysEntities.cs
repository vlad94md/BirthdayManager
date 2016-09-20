using BM.Data.Configuration;
using BM.Model;
using BM.Model.Models;
using System.Data.Entity;

namespace BM.Data
{
    public class BirthdaysEntities : DbContext
    {
        public BirthdaysEntities() : base("BMEntities") { }

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

            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<BirthdaysEntities>());

            modelBuilder.Entity<User>()
                .HasMany(t => t.BirthdayArrangements)
                .WithMany(t => t.Users);

            modelBuilder.Entity<BirthdayArrangement>()
                .HasMany(t => t.Users)
                .WithMany(t => t.BirthdayArrangements);

            //modelBuilder.Entity<BirthdayArrangement>()
            //    .HasRequired(e => e.User);
        }
    }
}
