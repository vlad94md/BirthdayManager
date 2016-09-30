using System;
using System.Collections.Generic;

namespace BM.Model.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Balance { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

        public virtual ICollection<BirthdayArrangement> BirthdaySubscriptions { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<BirthdayArrangement> Birthdays { get; set; }
    }
}
