using BM.Data.Repositories.Abstract;
using BM.Data.Repositories.Base;
using BM.Model.Models;

namespace BM.Data.Repositories.Concrete
{
    public class PaymentRepository : RepositoryBase<Payment>, IPaymentRepository
    {
        public PaymentRepository(IBirthdaysEntities context)
            : base(context) { }
    }
}