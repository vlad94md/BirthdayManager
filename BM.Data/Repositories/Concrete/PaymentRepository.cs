using BM.Data.EF;
using BM.Data.Entities;
using BM.Data.Repositories.Base;
using BM.Data.Repositories.Interfaces;
using System.Collections.Generic;

namespace BM.Data.Repositories.Concrete
{
    public class PaymentRepository : RepositoryBase<Payment>, IPaymentRepository
    {
        public PaymentRepository(IBirthdaysContext context)
            : base(context) { }

        public Payment GetById(int id)
        {
            return Get(x => x.Id == id);
        }

        public IEnumerable<Payment> GetManyByUserId(string id)
        {
            return GetMany(x => x.UserId == id);
        }
    }
}