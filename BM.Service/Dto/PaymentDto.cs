using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Service.Dto
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }

        public string UserId { get; set; }
        public UserDto User { get; set; }
    }
}
