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

        public virtual ICollection<BirthdayArrangement> BirthdayArrangements { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }

    public class Role
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
    }

    public class BirthdayArrangement
    {
        public int BirthdayArrangementId { get; set; }
        public DateTime Date { get; set; }
        public bool IsPassed { get; set; }

        public int GiftId { get; set; }
        public Gift Gift { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }

    public class Gift
    {
        public int GiftId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
    }

    public class Payment
    {
        public int PaymentId { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
