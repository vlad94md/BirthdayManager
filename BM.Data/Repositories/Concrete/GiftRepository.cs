using BM.Data.Repositories.Abstract;
using BM.Data.Repositories.Base;
using BM.Model.Models;

namespace BM.Data.Repositories.Concrete
{
    public class GiftRepository : RepositoryBase<Gift>, IGiftRepository
    {
        public GiftRepository(IBirthdaysEntities context)
            : base(context) { }
    }
}