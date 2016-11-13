using System.Collections.Generic;
using BM.Model.Models;

namespace BM.Service.Interfaces
{
    public interface IBirthdayArrangementService
    {
        void AddUsersToArrangement(BirthdayArrangement arrangement, IEnumerable<AppUser> users);
        void CompleteArrangement(BirthdayArrangement arrangement);
        void CreateArrangement(BirthdayArrangement arrangement);
        BirthdayArrangement GetArrangement(int id);
        IEnumerable<BirthdayArrangement> GetArrangements();
        void RemoveUsersFromArragement(BirthdayArrangement arrangement, IEnumerable<AppUser> users);
    }
}