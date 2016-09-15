using BM.Data.Configuration;
using BM.Model;
using System.Data.Entity;

namespace BM.Data
{
    public class BirthdaysEntities : DbContext
    {
        public BirthdaysEntities() : base("BMEntities") { }

        public DbSet<Gadget> Gadgets { get; set; }
        public DbSet<Category> Categories { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GadgetConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
        }
    }
}
