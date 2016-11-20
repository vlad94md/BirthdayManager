using System.Data.Entity.ModelConfiguration;
using BM.Data.Entities;

namespace BM.Data.Configuration
{
    public class UserConfiguration : EntityTypeConfiguration<AppUser>
    {
        public UserConfiguration()
        {
            ToTable("Users");
            Property(g => g.FirstName).IsRequired().HasMaxLength(50);
            Property(g => g.LastName).IsRequired().HasMaxLength(50);
            Property(g => g.Password).HasMaxLength(50).IsOptional();
            Property(g => g.DateOfBirth).IsRequired();

            HasMany(t => t.Subscriptions)
            .WithMany(t => t.Сongratulators);
        }
    }
}
