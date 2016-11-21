using AutoMapper;
using BM.Data.Entities;
using BM.Data.Infrastructure;
using BM.Service.Dto;
using BM.Service.Interfaces;
using System.Collections.Generic;

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
            var user = unitOfWork.Payments.GetById(id);

            Mapper.Initialize(cfg => cfg.CreateMap<Payment, PaymentDto>());
            return Mapper.Map<Payment, PaymentDto>(user); 
        }

        public IEnumerable<PaymentDto> GetPaymentsForUser(UserDto userDto)
        {
            var payments = unitOfWork.Payments.GetManyByUserId(userDto.Id);

            Mapper.Initialize(cfg => cfg.CreateMap<Payment, PaymentDto>());
            return Mapper.Map<IEnumerable<Payment>, List<PaymentDto>>(payments);
        }

        public void AddPayment(PaymentDto paymentDto)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Payment, PaymentDto>());
            var payment = Mapper.Map<PaymentDto, Payment>(paymentDto);

            unitOfWork.Payments.Add(payment);
            unitOfWork.Commit();
        }

    }
}