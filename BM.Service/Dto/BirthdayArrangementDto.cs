using System;
using System.Collections.Generic;

namespace BM.Service.Dto
{
    public class BirthdayArrangementDto
    {
        public int Id { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime Date { get; set; }

        public int GiftId { get; set; }
        public GiftDto Gift { get; set; }

        public string BirthdayManId { get; set; }
        public UserDto BirthdayMan { get; set; }

        public IEnumerable<UserDto> Сongratulators { get; set; }
    }
}
