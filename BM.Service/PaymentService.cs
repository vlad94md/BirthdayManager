using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BM.Data.Infrastructure;
using BM.Model.Models;
using BM.Service.Interfaces;
using Microsoft.VisualBasic.ApplicationServices;

namespace BM.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork unitOfWork;

        public PaymentService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Payment> GetPayments()
        {
            var payments = unitOfWork.Payments.GetAll();
            return payments;
        }

        public Payment GetPayment(int id)
        {
            var user = unitOfWork.Payments.Get(x => x.Id == id);
            return user;
        }

        public IEnumerable<Payment> GetPaymentsForUser(AppUser user)
        {
            var payments = unitOfWork.Payments.GetMany(x => x.UserId == user.Id);
            return payments;
        }

        public void AddPayment(Payment payment)
        {
            unitOfWork.Payments.Add(payment);
            unitOfWork.Commit();
        }

    }
}