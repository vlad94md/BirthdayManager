using System.Collections.Generic;
using AutoMapper;
using BM.Data.Entities;
using BM.Data.Infrastructure;
using BM.Service.Dto;
using BM.Service.Interfaces;

namespace BM.Service.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork unitOfWork;

        public PaymentService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<PaymentDto> GetPayments()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Payment, PaymentDto>());
            return Mapper.Map<IEnumerable<Payment>, List<PaymentDto>>(unitOfWork.Payments.GetAll());
        }

        public PaymentDto GetPayment(int id)
        {
            var user = unitOfWork.Payments.Get(x => x.Id == id);
            return user;
        }

        public IEnumerable<PaymentDto> GetPaymentsForUser(UserDto user)
        {
            var payments = unitOfWork.Payments.GetMany(x => x.UserId == user.Id);
            return payments;
        }

        public void AddPayment(PaymentDto payment)
        {
            unitOfWork.Payments.Add(payment);
            unitOfWork.Commit();
        }

    }
}