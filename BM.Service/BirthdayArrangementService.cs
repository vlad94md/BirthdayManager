using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BM.Data.Infrastructure;
using BM.Model.Models;
using BM.Service.Interfaces;
using Microsoft.VisualBasic.ApplicationServices;

namespace BM.Service
{
    public class BirthdayArrangementService : IBirthdayArrangementService
    {
        private readonly IUnitOfWork unitOfWork;

        public BirthdayArrangementService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<BirthdayArrangement> GetArrangements()
        {
            var arrangements = unitOfWork.BirthdayArrangements.GetAll();
            return arrangements;
        }

        public BirthdayArrangement GetArrangement(int id)
        {
            var arrangement = unitOfWork.BirthdayArrangements.Get(x => x.Id == id);
            return arrangement;
        }

        public void CreateArrangement(BirthdayArrangement arrangement)
        {
            unitOfWork.BirthdayArrangements.Add(arrangement);
            unitOfWork.Commit();
        }

        public void CompleteArrangement(BirthdayArrangement arrangement)
        {
            arrangement.IsCompleted = true;

            unitOfWork.BirthdayArrangements.Update(arrangement);
            unitOfWork.Commit();
        }

        public void AddUsersToArrangement(BirthdayArrangement arrangement, IEnumerable<AppUser> users)
        {
            var arr = unitOfWork.BirthdayArrangements.Get(x => x.Id == arrangement.Id);

            if (arr == null)
                return;

            var congratulators = arr.Сongratulators.ToList();

            foreach (var user in congratulators)
            {
                if (!congratulators.Contains(user))
                    congratulators.Add(user);
            }

            arrangement.Сongratulators = congratulators;
            unitOfWork.Commit();
        }

        public void RemoveUsersFromArragement(BirthdayArrangement arrangement, IEnumerable<AppUser> users)
        {
            var arr = unitOfWork.BirthdayArrangements.Get(x => x.Id == arrangement.Id);

            if (arr == null)
                return;

            var congratulators = arr.Сongratulators.ToList();

            foreach (var user in congratulators)
            {
                if (congratulators.Contains(user))
                    congratulators.Remove(user);
            }

            arrangement.Сongratulators = congratulators;
            unitOfWork.Commit();
        }

    }
}