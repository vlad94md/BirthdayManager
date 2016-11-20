using BM.Data.EF;
using BM.Data.Entities;
using BM.Data.Repositories.Base;
using BM.Data.Repositories.Interfaces;

namespace BM.Data.Repositories.Concrete
{
    public class GiftRepository : RepositoryBase<Gift>, IGiftRepository
    {
        public GiftRepository(IBirthdaysContext context)
            : base(context) { }
    }
}