using BM.Data.Infrastructure;
using BM.Model.Models;

namespace BM.Data.Repositories
{
    public class GiftRepository : RepositoryBase<Gift>, IGiftRepository
    {
        public GiftRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
    }
}