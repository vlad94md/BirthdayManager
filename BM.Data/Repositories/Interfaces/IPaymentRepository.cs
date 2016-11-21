using System.Collections.Generic;
using BM.Data.Entities;
using BM.Data.Repositories.Base;

namespace BM.Data.Repositories.Interfaces
{
    public interface IPaymentRepository : IRepository<Payment>
    {
        Payment GetById(int id);
        IEnumerable<Payment> GetManyByUserId(string id);
    }
}