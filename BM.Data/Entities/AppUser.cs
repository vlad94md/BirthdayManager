using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BM.Data.Entities
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Balance { get; set; }

        public virtual ICollection<BirthdayArrangement> Subscriptions { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<BirthdayArrangement> Birthdays { get; set; }
    }
}
