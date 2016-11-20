using System.Collections.Generic;
using BM.Data.Entities;
using BM.Service.Dto;

namespace BM.Service.Interfaces
{
    public interface IBirthdayArrangementService
    {
        void AddUsersToArrangement(BirthdayArrangementDto arrangement, IEnumerable<UserDto> users);
        void CompleteArrangement(BirthdayArrangementDto arrangement);
        void CreateArrangement(BirthdayArrangementDto arrangement);
        BirthdayArrangementDto GetArrangement(int id);
        IEnumerable<BirthdayArrangementDto> GetArrangements();
        void RemoveUsersFromArragement(BirthdayArrangementDto arrangement, IEnumerable<UserDto> users);
    }
}