using System.Data.Entity.ModelConfiguration;
using BM.Data.Entities;

namespace BM.Data.Configuration
{
    public class BirthdayArrangementConfiguration : EntityTypeConfiguration<BirthdayArrangement>
    {
        public BirthdayArrangementConfiguration()
        {
             HasMany(t => t.Сongratulators)
            .WithMany(t => t.Subscriptions); 
        } 
    }
}
