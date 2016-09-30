using BM.Model.Models;
using System.Data.Entity.ModelConfiguration;

namespace BM.Data.Configuration
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("Users");
            Property(g => g.Username).IsRequired().HasMaxLength(100);
            Property(g => g.FirstName).IsRequired().HasMaxLength(50);
            Property(g => g.LastName).IsRequired().HasMaxLength(50);
            Property(g => g.Password).HasMaxLength(50).IsOptional();
            Property(g => g.DateOfBirth).IsRequired();
            Property(g => g.RoleId).IsRequired();
        }
    }
}
