using BM.Data.Infrastructure;
using BM.Model.Models;

namespace BM.Data.Repositories
{
    public class BirthdayArrangmenetRepository : RepositoryBase<BirthdayArrangement>, IBirthdayArrangementRepository
    {
        public BirthdayArrangmenetRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
    }
}