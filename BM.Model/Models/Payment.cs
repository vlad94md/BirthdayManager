using System;

namespace BM.Model.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }

        public int UserId { get; set; }
        public AppUser User { get; set; }
    }
}