using System;
using System.Collections.Generic;

namespace BM.Model.Models
{
    public class BirthdayArrangement
    {
        public int BirthdayArrangementId { get; set; }
        public DateTime Date { get; set; }
        public bool IsCompleted { get; set; }

        public int GiftId { get; set; }
        public Gift Gift { get; set; }

        public int BirthdayManId { get; set; }
        public User BirthdayMan { get; set; }

        public virtual ICollection<User> Сongratulators { get; set; }
    }
}