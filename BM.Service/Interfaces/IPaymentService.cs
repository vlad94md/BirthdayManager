using System.Collections.Generic;
using BM.Data.Entities;
using BM.Service.Dto;

namespace BM.Service.Interfaces
{
    public interface IPaymentService
    {
        IEnumerable<PaymentDto> GetPayments();
        PaymentDto GetPayment(int id);
        IEnumerable<PaymentDto> GetPaymentsForUser(UserDto userDto);
        void AddPayment(PaymentDto payment);
    }
}