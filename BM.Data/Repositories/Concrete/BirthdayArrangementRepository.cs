using BM.Data.Repositories.Abstract;
using BM.Data.Repositories.Base;
using BM.Model.Models;

namespace BM.Data.Repositories.Concrete
{
    public class BirthdayArrangementRepository : RepositoryBase<BirthdayArrangement>, IBirthdayArrangementRepository
    {
        public BirthdayArrangementRepository(IBirthdaysEntities context)
            : base(context) { }
    }
}