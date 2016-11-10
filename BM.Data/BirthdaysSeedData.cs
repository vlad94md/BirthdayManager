using BM.Model;
using BM.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BM.Data
{
    public class BirthdaysSeedData : DropCreateDatabaseAlways<BirthdaysEntities>
    {
        private static BirthdaysEntities context;

        protected override void Seed(BirthdaysEntities _context)
        {
            context = _context;

            if(context.Users.Any())
                return;

            GetRoles().ForEach(c => context.Roles.Add(c));
            GetUsers().ForEach(g => context.Users.Add(g));
            context.Commit();

            GetPayments().ForEach(g => context.Payments.Add(g));
            GetGifts().ForEach(g => context.Gifts.Add(g));
            GetBirthdayArrangements().ForEach(g => context.BirthdayArrangements.Add(g));

            context.Commit();
        }

        private static List<AppRole> GetRoles()
        {
            return new List<AppRole>
            {
                new AppRole {
                    Name = "user"
                },
                new AppRole {
                    Name = "admin"
                }
            };
        }

        private static List<AppUser> GetUsers()
        {
            var currentDate = DateTime.Now;
            var thisMonth = currentDate.Month;

            return new List<AppUser>
            {
                new AppUser {
                    FirstName = "Vladislav",
                    LastName = "Guleaev",
                    UserName= "vguleaev",
                    Password = "12345",
                    Balance = 100,
                    DateOfBirth = DateTime.ParseExact("1994.01." + thisMonth, "yyyy.dd.MM",
                                    System.Globalization.CultureInfo.InvariantCulture),
                },
                new AppUser {
                    FirstName = "Serghei",
                    LastName = "Tibulschii",
                    UserName = "stibulschii",
                    Password = "12345",
                    Balance = -100,
                    DateOfBirth = DateTime.ParseExact("1994.05." + thisMonth, "yyyy.dd.MM",
                                    System.Globalization.CultureInfo.InvariantCulture),
                },
                new AppUser {
                    FirstName = "Natalia",
                    LastName = "Curusi",
                    UserName = "ncurusi",
                    Password = "12345",
                    Balance = 0,
                    DateOfBirth = DateTime.ParseExact("1980.15." + thisMonth, "yyyy.dd.MM",
                                    System.Globalization.CultureInfo.InvariantCulture),
                },
                new AppUser {
                    FirstName = "Sandu",
                    LastName = "Guzun",
                    UserName = "sguzun",
                    Password = "12345",
                    Balance = 75,
                    DateOfBirth = DateTime.ParseExact("1992.20." + thisMonth, "yyyy.dd.MM",
                                    System.Globalization.CultureInfo.InvariantCulture),
                },
                new AppUser {
                    FirstName = "Alexandru",
                    LastName = "Diacov",
                    UserName = "adiacov",
                    Password = "12345",
                    Balance = 0,
                    DateOfBirth = DateTime.ParseExact("1993.25." + thisMonth, "yyyy.dd.MM",
                                    System.Globalization.CultureInfo.InvariantCulture),
                },
            };
        }

        private static List<Payment> GetPayments()
        {
            var users = context.Users.ToList();

            return new List<Payment>
            {
                new Payment {
                    UserId = users[0].Id,
                    Amount = 70,
                    Date = DateTime.Now,
                    Message = "For Natalia",
                },
                new Payment {
                    UserId = users[0].Id,
                    Amount = 70,
                    Date = DateTime.Now,
                    Message = "For Serghei",
                },
                new Payment {
                    UserId = users[0].Id,
                    Amount = 100,
                    Date = DateTime.Now,
                    Message = "For next birthdays",
                },
                new Payment {
                    UserId = users[1].Id,
                    Amount = 70,
                    Date = DateTime.Now,
                    Message = "For Natalia",
                },
                new Payment {
                    UserId = users[1].Id,
                    Amount = 100,
                    Date = DateTime.Now,
                    Message = "For Vlad",
                },
                new Payment {
                    UserId = users[2].Id,
                    Amount = 50,
                    Date = DateTime.Now,
                    Message = "For Vlad",
                },
                new Payment {
                    UserId = users[3].Id,
                    Amount = 70,
                    Date = DateTime.Now,
                    Message = "For Natalia",
                },
                new Payment {
                    UserId = users[3].Id,
                    Amount = 200,
                    Date = DateTime.Now,
                    Message = "For next bitrhtdays",
                },
                new Payment {
                    UserId = users[4].Id,
                    Amount = 70,
                    Date = DateTime.Now,
                    Message = "For Natalia",
                },
            };
        }

        private static List<Gift> GetGifts()
        {
            return new List<Gift>
            {
                new Gift {
                    Id = 1,
                    Price = 1000,
                    Name = "Books"
                },
                new Gift {
                    Id = 2,
                    Price = 2000,
                    Name = "Wathces"
                },
                new Gift {
                    Id = 3,
                    Price = 1500,
                    Name = "Tattoo sertificate"
                },
                new Gift {
                    Id = 4,
                    Price = 700,
                    Name = "Alcohol"
                }
            };
        }

        private static List<BirthdayArrangement> GetBirthdayArrangements()
        {
            var users = context.Users.ToList();

            return new List<BirthdayArrangement>
            {
                new BirthdayArrangement
                {
                    BirthdayMan = users.FirstOrDefault(x => x.UserName == "ncurusi"),
                    IsCompleted = true,
                    GiftId = 1,
                    Сongratulators = new List<AppUser>() {
                        users.FirstOrDefault(x => x.UserName == "vguleaev"),
                        users.FirstOrDefault(x => x.UserName == "stibulschii"),
                        users.FirstOrDefault(x => x.UserName == "sguzun"),
                        users.FirstOrDefault(x => x.UserName == "adiacov")
                    }
                },
                new BirthdayArrangement
                {
                    BirthdayMan = users.FirstOrDefault(x => x.UserName == "vguleaev"),
                    IsCompleted = true,
                    GiftId = 4,
                    Сongratulators = new List<AppUser>() {
                        users.FirstOrDefault(x => x.UserName == "stibulschii"),
                        users.FirstOrDefault(x => x.UserName == "ncurusi"),
                        users.FirstOrDefault(x => x.UserName == "sguzun")
                    }
                },
                new BirthdayArrangement
                {
                    BirthdayMan = users.FirstOrDefault(x => x.UserName == "sguzun"),
                    IsCompleted = false,
                    GiftId = 2,
                    Сongratulators = new List<AppUser>() { }
                },
                 new BirthdayArrangement
                {
                    BirthdayMan = users.FirstOrDefault(x => x.UserName == "adiacov"),
                    IsCompleted = false,
                    GiftId = 3,
                    Сongratulators = new List<AppUser>() {
                        users.FirstOrDefault(x => x.UserName == "vguleaev"),
                        users.FirstOrDefault(x => x.UserName == "stibulschii")
                    }
                },
            };
        }
    }
}
