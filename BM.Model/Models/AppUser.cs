using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BM.Model.Models
{
    public class AppUser : IdentityUser
    {
        public int AdditionalId { get; set; }
        public string OldUsername { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Balance { get; set; }

        //public int RoleId { get; set; }
        //public AppRole Role { get; set; }

        public virtual ICollection<BirthdayArrangement> BirthdaySubscriptions { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<BirthdayArrangement> Birthdays { get; set; }
    }
}
