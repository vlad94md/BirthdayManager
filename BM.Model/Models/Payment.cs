using System;

namespace BM.Model.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }

        public string UserId { get; set; }
        public AppUser User { get; set; }
    }
}