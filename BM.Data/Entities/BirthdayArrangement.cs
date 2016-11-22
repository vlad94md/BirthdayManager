using System;
using System.Collections.Generic;

namespace BM.Data.Entities
{
    public class BirthdayArrangement
    {
        public int Id { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime Date { get; set; }

        public int GiftId { get; set; }
        public Gift Gift { get; set; }

        public string BirthdayManId { get; set; }
        public AppUser BirthdayMan { get; set; }

        public virtual ICollection<AppUser> Сongratulators { get; set; }
    }
}