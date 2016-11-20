using BM.Data.EF;
using BM.Data.Entities;
using BM.Data.Repositories.Base;
using BM.Data.Repositories.Interfaces;

namespace BM.Data.Repositories.Concrete
{
    public class BirthdayArrangementRepository : RepositoryBase<BirthdayArrangement>, IBirthdayArrangementRepository
    {
        public BirthdayArrangementRepository(IBirthdaysContext context)
            : base(context) { }
    }
}