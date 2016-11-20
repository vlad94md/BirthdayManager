using BM.Data.EF;
using BM.Data.Entities;
using BM.Data.Repositories.Base;
using BM.Data.Repositories.Interfaces;

namespace BM.Data.Repositories.Concrete
{
    public class PaymentRepository : RepositoryBase<Payment>, IPaymentRepository
    {
        public PaymentRepository(IBirthdaysContext context)
            : base(context) { }
    }
}