using BM.Data.Entities;
using BM.Data.Repositories.Base;

namespace BM.Data.Repositories.Interfaces
{
    public interface IBirthdayArrangementRepository : IRepository<BirthdayArrangement>
    {
        BirthdayArrangement GetById(int id);
    }
}