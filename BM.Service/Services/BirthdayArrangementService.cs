using AutoMapper;
using BM.Data.Entities;
using BM.Data.Infrastructure;
using BM.Service.Dto;
using BM.Service.Infrastructure;
using BM.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BM.Service.Services
{
    public class BirthdayArrangementService : IBirthdayArrangementService
    {
        private readonly IUnitOfWork unitOfWork;

        public BirthdayArrangementService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<BirthdayArrangementDto> GetArrangements()
        {
            var arrangements = unitOfWork.BirthdayArrangements.GetAll();

            Mapper.Initialize(cfg => {
                cfg.CreateMap<BirthdayArrangement, BirthdayArrangementDto>();
                cfg.CreateMap<AppUser, UserDto>();
                cfg.CreateMap<Gift, GiftDto>();
                cfg.CreateMap<Payment, PaymentDto>();
            });

            return Mapper.Map<IEnumerable<BirthdayArrangement>, List<BirthdayArrangementDto>>(arrangements);
        }

        public BirthdayArrangementDto GetArrangement(int id)
        {
            var arrangement = unitOfWork.BirthdayArrangements.GetById(id);

            return Mapper.Map<BirthdayArrangement, BirthdayArrangementDto>(arrangement);
        }

        public void CreateArrangement(BirthdayArrangementDto arrangementDto)
        {
            var arrangement = Mapper.Map<BirthdayArrangementDto, BirthdayArrangement>(arrangementDto);

            unitOfWork.BirthdayArrangements.Add(arrangement);
            unitOfWork.Commit();
        }

        public void CompleteArrangement(BirthdayArrangementDto arrangementDto)
        {
            var arrangement = Mapper.Map<BirthdayArrangementDto, BirthdayArrangement>(arrangementDto);
            arrangement.IsCompleted = true;

            unitOfWork.BirthdayArrangements.Update(arrangement);
            unitOfWork.Commit();
        }

        public void AddUsersToArrangement(BirthdayArrangementDto arrangementDto, IEnumerable<UserDto> users)
        {
            var arrangement = unitOfWork.BirthdayArrangements.GetById(arrangementDto.Id);

            if (arrangement == null)
                throw new ValidationException("Arrangement was not found", "");

            var congratulators = arrangement.Сongratulators.ToList();

            foreach (var user in congratulators)
            {
                if (!congratulators.Contains(user))
                    congratulators.Add(user);
            }

            arrangement.Сongratulators = congratulators;
            unitOfWork.BirthdayArrangements.Update(arrangement);
            unitOfWork.Commit();
        }

        public void RemoveUsersFromArragement(BirthdayArrangementDto arrangementDto, IEnumerable<UserDto> users)
        {
            var arrangement = unitOfWork.BirthdayArrangements.GetById(arrangementDto.Id);

            if (arrangement == null)
                throw new ValidationException("Arrangement was not found", "");

            var congratulators = arrangement.Сongratulators.ToList();

            foreach (var user in congratulators)
            {
                if (congratulators.Contains(user))
                    congratulators.Remove(user);
            }

            arrangement.Сongratulators = congratulators;
            unitOfWork.BirthdayArrangements.Update(arrangement);
            unitOfWork.Commit();
        }

    }
}