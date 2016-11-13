using System.Collections.Generic;
using BM.Model.Models;

namespace BM.Service.Interfaces
{
    public interface IPaymentService
    {
        IEnumerable<Payment> GetPayments();
        Payment GetPayment(int id);
        IEnumerable<Payment> GetPaymentsForUser(AppUser user);
        void AddPayment(Payment payment);
    }
}